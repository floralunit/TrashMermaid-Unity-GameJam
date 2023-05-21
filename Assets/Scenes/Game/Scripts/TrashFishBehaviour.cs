using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    private bool isEating;
    private bool canEat;

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
        isEating = false;
        canEat = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isEating && canEat)
        {
            StartCoroutine(Eating());
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mermaid" && MermaidMovement.Instance.hasTrash && !isEating)
        {
            // TrashTextScript.TrashItem += 1;

            PickUpText.Instance.gameObject.SetActive(true);
            PickUpText.Instance.text.text = "Нажмите F, чтобы отдать мусор треш рыбе!";
            canEat = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mermaid")
        {
            PickUpText.Instance.gameObject.SetActive(false);
            canEat = false;
        }
    }
    public IEnumerator Eating()
    {
        isEating = true;
        Destroy(MermaidMovement.Instance.trash.gameObject);
        MermaidMovement.Instance.hasTrash = false;
        MermaidMovement.Instance.trash = null;
        yield return new WaitForSeconds(10f);
        isEating = false;
        wayPoint = transform.position;
        TrashTextScript.TrashItemCount -= 1;
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
