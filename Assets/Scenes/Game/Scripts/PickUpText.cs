using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpText : MonoBehaviour
{
    //Text text;

    public static PickUpText Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //text = GetComponent<Text>();
    }

    void Update()
    {
        //text.text = "������� E, ����� ���������!";
    }
}
