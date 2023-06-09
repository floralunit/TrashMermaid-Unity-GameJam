using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashItemScript : MonoBehaviour
{
    [SerializeField]
    float range;
    [SerializeField]
    float maxDistance;

    public float speed = 0.3f;


    private bool pickUpAllowed;

    Vector2 wayPoint;

    void Start()
    {
        SetNewDestination();
        PickUpText.Instance.gameObject.SetActive(false);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }

        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E) && MermaidMovement.Instance.trash == null)
        {
            PickUp();
        }

    }

    void PickUp()
    {
        MermaidMovement.Instance.hasTrash = true;
        MermaidMovement.Instance.trash = this.gameObject;
        this.gameObject.SetActive(false);
    }


    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Mermaid")
    //    {
    //        // TrashTextScript.TrashItem += 1;

    //        PickUpText.Instance.gameObject.SetActive(true);
    //        pickUpAllowed = true;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Mermaid")
    //    {
    //        PickUpText.Instance.gameObject.SetActive(false);
    //        pickUpAllowed = false;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mermaid" && !MermaidMovement.Instance.hasTrash)
        {
            PickUpText.Instance.gameObject.SetActive(true);
            PickUpText.Instance.text.text = "������� E, ����� ���������!";
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mermaid")
        {
            PickUpText.Instance.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }
}
