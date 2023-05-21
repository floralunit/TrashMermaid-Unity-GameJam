using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float startTime = 300f; // ����� � ��������
    private float currentTime;
    public Text timerText;

    void Start()
    {
        currentTime = startTime;
        timerText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(currentTime / 60); // ���������� �����
        float seconds = Mathf.FloorToInt(currentTime % 60); // ���������� ������

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // �������������� �������

        if (currentTime <= 0)
        {
            var changeScene = new SceneChanger();

            changeScene.ChangeScene("GameOver");
        }
    }
}
