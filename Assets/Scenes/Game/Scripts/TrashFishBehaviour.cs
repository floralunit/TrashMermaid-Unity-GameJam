using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashFishBehaviour : MonoBehaviour
{
    [SerializeField]
    float range;
    [SerializeField]
    float maxDistance;

    public float speed = 2f;

    public Animator animator;

    Vector2 wayPoint;
    private Vector2 origPos, targetPos;
    private bool isEating = false;

    private string CurrentAnimaton;
    void Start()
    {
        origPos = transform.position;
        SetNewDestination();
        targetPos = wayPoint;
        if (targetPos.x > origPos.x)
        {
            ChangeAnimation("TrashFishMoveRight");
        }
        if (targetPos.x < origPos.x)
        {
            ChangeAnimation("TrashFishMoveLeft");
        }
    }

    void Update()
    {
        if (isEating == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, wayPoint) < range)
            {
                origPos = wayPoint;
                SetNewDestination();
                targetPos = wayPoint;
                if (targetPos.x > origPos.x)
                {
                    ChangeAnimation("TrashFishMoveRight");
                }
                if (targetPos.x < origPos.x)
                {
                    ChangeAnimation("TrashFishMoveLeft");
                }
            }
        }

        if (isEating == true)
        {
            if (CurrentAnimaton == "TrashFishMoveRight")
            {
                ChangeAnimation("TrashFishEatRight");
            }
            if (CurrentAnimaton == "TrashFishMoveLeft")
            {
                ChangeAnimation("TrashFishEatLeft");
            }
        }
    }


    void ChangeAnimation(string animation)
    {
        if (CurrentAnimaton == animation) return;

        animator.Play(animation);
        CurrentAnimaton = animation;
    }
    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }
}
