using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShakeCameraWhenCalled))]
public class MoveGroundDownOnLongContact : MonoBehaviour
{
    [Header("Stats")]
    public float waitForTime = 4f;
    public float fallDistance = 5f;

    [Header("Player")]
    public GameObject player;

    private bool coroutinePlayed;
    private SineWave sineWave;
    private ShakeCameraWhenCalled shakeCameraWhenCalled;

    private Coroutine startCountDownTimerCoroutine;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        sineWave = gameObject.transform.parent.GetComponent<SineWave>();
        shakeCameraWhenCalled = gameObject.GetComponent<ShakeCameraWhenCalled>();
        coroutinePlayed = false;
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        Rigidbody target = other.gameObject.GetComponent<Rigidbody>();
        if (!target || !other.gameObject.CompareTag("Player"))
            return;


        startCountDownTimerCoroutine = StartCoroutine(StartCountDownTimer());
    }

    /// <summary>
    /// OnCollisionExit is called when this collider/rigidbody has
    /// stopped touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionExit(Collision other)
    {
        Rigidbody target = other.gameObject.GetComponent<Rigidbody>();
        if (!target || !other.gameObject.CompareTag("Player"))
            return;

        if (coroutinePlayed)
            StopCoroutine(startCountDownTimerCoroutine);

    }

    IEnumerator StartCountDownTimer()
    {
        coroutinePlayed = true;
        yield return new WaitForSeconds(waitForTime);

        player.transform.SetParent(null);

        if (sineWave != null)
        {
            Vector3 currentStartPosition = sineWave.GetStartPosition();

            currentStartPosition += Vector3.down * fallDistance;

            sineWave.ReComputeStartAndEndPositions(currentStartPosition);
            shakeCameraWhenCalled.StartShaking();
        }
        else
        {
            Vector3 currentPosition = gameObject.transform.parent.position;
            currentPosition += Vector3.down * fallDistance;

            gameObject.transform.parent.position = currentPosition;
        }

        coroutinePlayed = false;
        startCountDownTimerCoroutine = StartCoroutine(StartCountDownTimer());
    }
}
