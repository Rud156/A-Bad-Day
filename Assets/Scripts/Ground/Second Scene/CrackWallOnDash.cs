using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackWallOnDash : MonoBehaviour
{
    [Header("Wall Stats")]
    public float minPlayerSpeed;

    [Header("Wall Break Particles")]
    public GameObject wallBreakParticles;
    public Vector3 wallBreakParticlesRotation = Vector3.zero;

    [Header("Wall Materials")]
    public Material smoothWallMaterial;
    public Material brokenWallMaterial;


    private int currentBashCount;
    private Renderer gameObjectRenderer;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        currentBashCount = 2;
        gameObjectRenderer = gameObject.GetComponent<Renderer>();
        gameObjectRenderer.material = smoothWallMaterial;
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if (!Core.wallBreakCollected)
            return;

        Rigidbody target = other.gameObject.GetComponent<Rigidbody>();
        if (!target || !other.gameObject.CompareTag("Player"))
            return;

        float collisionVelocity = other.relativeVelocity.magnitude;
        if (collisionVelocity < minPlayerSpeed)
            return;

        currentBashCount -= 1;

        if (currentBashCount <= 0)
        {
            Instantiate(wallBreakParticles,
                gameObject.transform.position, wallBreakParticles.transform.rotation);
            Destroy(gameObject);
        }
        else if (currentBashCount == 1)
        {
            gameObjectRenderer.material = brokenWallMaterial;
        }
    }
}
