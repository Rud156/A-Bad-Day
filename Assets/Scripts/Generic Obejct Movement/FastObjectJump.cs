using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastObjectJump : MonoBehaviour
{
    [Header("Requied Attributes")]
    public float moveSpeed;
    public float jumpAboveHeight;
    public float maxJumpCount;
    public GameObject dropParticles;


    private float currentJumpCount;
    private float startYPosition;
    private float endYPosition;
    private bool goUp;
    private bool updateCalled;

    void Start()
    {
        startYPosition = gameObject.transform.localPosition.y;
        endYPosition = startYPosition + jumpAboveHeight;

        goUp = true;
        updateCalled = true;

        currentJumpCount = maxJumpCount + 1;
    }

    public void ResetAndPlayJump()
    {
        updateCalled = false;
        currentJumpCount = 0;
    }


    void Update()
    {
        if (currentJumpCount >= maxJumpCount)
            return;

        if (goUp)
            gameObject.transform.localPosition += Vector3.up * moveSpeed;
        else
            gameObject.transform.localPosition += Vector3.down * moveSpeed;

        updateCalled = true;
    }

    void LateUpdate()
    {
        if (currentJumpCount >= maxJumpCount || !updateCalled)
            return;

        if (gameObject.transform.localPosition.y >= endYPosition)
            goUp = false;
        else if (gameObject.transform.localPosition.y <= startYPosition)
        {
            goUp = true;
            currentJumpCount += 1;

            GameObject particles = Instantiate(
                dropParticles,
                gameObject.transform.position - Vector3.up * 0.25f,
                dropParticles.transform.rotation
            ) as GameObject;
            particles.transform.SetParent(gameObject.transform.parent);
            particles.transform.localScale = Vector3.one * 2;
        }
    }
}
