using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpOnPlayer : MonoBehaviour
{

    [Header("Player To Target")]
    public GameObject player;

    [Header("Jump Stats")]
    public int minLaunchAngle = 30;
    public int maxLaunchAngle = 60;

    [Header("Force Stats")]
    public float radius = 5f;
    public float power = 10f;

    [Header("Effects")]
    public GameObject landEffect;
    public float heightBelowEnemyCenter = 1.5f;

    private Rigidbody target;

    // Use this for initialization
    void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
        EnemyStats.isJumping = false;
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {

        if (!EnemyStats.isJumping)
            return;

        if (!other.gameObject.CompareTag("LastGround") && !other.gameObject.CompareTag("Player"))
            return;

        Vector3 explosionPosition = gameObject.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null && collider.gameObject.CompareTag("Player"))
                rb.AddExplosionForce(power, explosionPosition, radius, 3f, ForceMode.Impulse);
        }

        Vector3 instantiationPosition = new Vector3(gameObject.transform.position.x,
           gameObject.transform.position.y - heightBelowEnemyCenter, gameObject.transform.position.z);
        GameObject effect = Instantiate(landEffect, instantiationPosition,
            landEffect.transform.rotation);
        effect.transform.SetParent(gameObject.transform.parent);
        ParticleSystem instantiatedParticles = effect.GetComponent<ParticleSystem>();
        ParticleSystem.CollisionModule collision = instantiatedParticles.collision;
        collision.SetPlane(0, player.transform);

        EnemyStats.isJumping = false;
        target.isKinematic = true;
    }

    public void TriggerJump()
    {
        target.isKinematic = false;

        if (EnemyStats.isJumping)
            return;

        EnemyStats.isJumping = true;

        int randomAngle = Random.Range(minLaunchAngle, maxLaunchAngle);
        target.velocity = BallisticVelocity(randomAngle);
    }

    private Vector3 BallisticVelocity(float launchAngle)
    {
        Vector3 dir = player.transform.position - gameObject.transform.position;  // get target direction
        float h = dir.y;  // get height difference
        dir.y = 0;  // retain only the horizontal direction
        float dist = dir.magnitude;  // get horizontal distance
        float a = launchAngle * Mathf.Deg2Rad;  // convert angle to radians
        dir.y = dist * Mathf.Tan(a);  // set dir to the elevation angle
        dist += h / Mathf.Tan(a);  // correct for small height differences

        // Calculate the velocity magnitude
        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return vel * dir.normalized;
    }
}
