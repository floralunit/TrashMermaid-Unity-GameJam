using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashTextScript : MonoBehaviour
{
    public static int TrashItemCount = 0;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = $"���������� {TrashItemCount} ������";
    }
}
