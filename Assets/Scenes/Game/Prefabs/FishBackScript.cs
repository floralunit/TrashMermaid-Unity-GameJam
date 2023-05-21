using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBackScript : MonoBehaviour
{
    public float speed = 2f; // �������� �������� �����

    // Update is called once per frame
    void Update()
    {
        // ����������� ����� ������
        transform.position += Vector3.left * Time.deltaTime * speed;

        // ������� �����, ����� ���������� ����������� Y-�������
        if (transform.position.y <= -4 || transform.position.x <= -13)
        {
            Destroy(gameObject);
        }
    }
}
