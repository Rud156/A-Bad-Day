using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerAndMoveGroundDown : MonoBehaviour
{

    [Header("Grounds to Affect")]
    public List<GameObject> grounds;

    [Header("Stats")]
    public float movementSpeed;
    public float movementAmount;
    public bool isPositive = false;
    public bool activateOnStart = false;

    private bool stopMovement;
    private List<float> endYPosition;
    private List<bool> positionReached;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        endYPosition = new List<float>();
        positionReached = new List<bool>();

        stopMovement = !activateOnStart;

        foreach (GameObject ground in grounds)
        {
            if (isPositive)
                endYPosition.Add(ground.transform.position.y + movementAmount);
            else
                endYPosition.Add(ground.transform.position.y - movementAmount);
            positionReached.Add(false);
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (stopMovement)
            return;

        for (int i = 0; i < grounds.Count; i++)
        {
            GameObject ground = grounds[i];

            ground.transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
            float currentYPosition = ground.transform.position.y;

            if (isPositive && currentYPosition > endYPosition[i])
                positionReached[i] = true;
            else if (!isPositive && currentYPosition < endYPosition[i])
                positionReached[i] = true;
        }

        bool allCompleted = true;
        foreach (bool item in positionReached)
        {
            if (!item)
            {
                allCompleted = false;
                break;
            }
        }
        if (allCompleted)
        {
            stopMovement = true;
            Core.stopPlayerMovement = false;
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (!target || !other.CompareTag("Player"))
            return;


        stopMovement = false;
        Core.stopPlayerMovement = true;
        target.velocity = Vector3.zero;
    }
}
