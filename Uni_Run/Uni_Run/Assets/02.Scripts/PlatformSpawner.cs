using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; //생성할 발판의 원본 프리팹
    public int count = 3;// 생성할 발판 수

    public float timeBetSpawnMin = 1.25f; // 다음 배치까지 최솟값
    public float timeBetSpawnMax = 2.25f; // 다음 배치까지 최댓값
    public float timeBetSpawn; // 다음배치까지의 시간 간격

    public float yMin = -3.5f; //배치할 위치의 최소 Y 값
    public float yMax = 1.5f; // 배치할 위치의 최대의 Y 값
    private float xPos = 20f; // 배치할 위치의 x값


    private GameObject[] platforms; //미리 생성한 발판들
    private int currentIndex = 0; // 사용할 현재 순번의 발판

    private Vector2 poolPosition = new Vector2(0, -25); // 초반에 생성한 발판을 화면 밖에 숨겨둘 위치
    private float lastSpwnTime; // 마지막 배치 시점.

   
    void Start()
    {
        platforms = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);// identity
        }
        lastSpwnTime = 0f;
        timeBetSpawn =  0f;
    }
    
    

    
    void Update()
    {
        if (Gamemanager.instance.isGameover)
        {
            return;

        }
        if (Time.time >= lastSpwnTime + timeBetSpawn)
        {
            lastSpwnTime = Time.time;

            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            float yPos = Random.Range(yMin, yMax);

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);
            currentIndex++;

            if(currentIndex >= count)
            {
                currentIndex = 0;
            }


        }
    }
}
