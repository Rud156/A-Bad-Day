using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastObjectJump : MonoBehaviour
{
    [Header("Requied Attributes")]
    public float moveSpeed;
    public float jumpAboveHeight;
    public float maxJumpCount;
    public GameObject touchParticles;


    private float currentJumpCount;
    private float startYPosition;
    private float endYPosition;
    private bool goUp;

    void Start()
    {
        startYPosition = gameObject.transform.localPosition.y;
        endYPosition = startYPosition + jumpAboveHeight;
        goUp = true;
    }


    void Update()
    {
        if (currentJumpCount >= maxJumpCount)
            return;

        if (goUp)
            gameObject.transform.localPosition += Vector3.up * moveSpeed;
        else
            gameObject.transform.localPosition += Vector3.down * moveSpeed;
    }

    void LateUpdate()
    {
        if (gameObject.transform.localPosition.y >= endYPosition)
            goUp = false;
        else if (gameObject.transform.localPosition.y <= startYPosition)
        {
            goUp = true;
            currentJumpCount += 1;
        }
    }
}
