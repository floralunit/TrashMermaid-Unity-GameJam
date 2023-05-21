using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] fishPrefabs;// ������ �����
    public float spawnDelay = 1f; // �������� ����� ������� �����
    //public float speed = 2f; // �������� �������� �����
   // public float startY = 3f; // Y-�������, �� ������� ����� ������ ����������
    //public float minY = -3f; // ����������� Y-�������, ������� ����� ������ ������� ����� ���������

    // Start is called before the first frame update
    void Start()
    {
        // ������ ����� �����
        StartCoroutine(SpawnFish());
    }

    IEnumerator SpawnFish()
    {
        while (true)
        {
            int randFish = Random.Range(0, fishPrefabs.Length);

            // ������� ����� �����
            GameObject newFish = Instantiate(fishPrefabs[randFish], new Vector3(12f, Random.Range(-4, 6), 0), Quaternion.identity);

            // ��������
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
