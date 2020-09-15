using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar_Spawn : MonoBehaviour
{
    Vector3[] positions = new Vector3[5];

    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private bool isSpawn = false;

    private float spawnDelay = 2f; // 스폰 시간 조정
    private float spawnTimer = 0f;



    private void CreatePositions() // 카메라 앞 생성 포지션 만들기
    {
        float viewPosY = 1.6f; //  y축 설정(상하 조정)
        float gapX = 1f / 6f; // x축 갭 설정(사이드 조정)
        float viewPosX = 0f; // x축 설정(초기값 0  for문으로 지정)

        for(int i=0; i < positions.Length; i++)
        {
            viewPosX = gapX + gapX * i;

            Vector3 viewPos = new Vector3(viewPosX, viewPosY, 0);
            Vector3 Worldpos = Camera.main.ViewportToWorldPoint(viewPos);

            Worldpos.z = 0f;

            positions[i] = Worldpos;

        }
    }

    private void SpawnEnemy() // 적생성
    {
        if(isSpawn == true)
        {
            if(spawnTimer >  spawnDelay) 
            {
                int rand = Random.Range(0, positions.Length);
                Instantiate(enemy, positions[rand], Quaternion.identity);
                spawnTimer = 0f;
            }
            spawnTimer += Time.deltaTime;
        }
    }



    private void Update()
    {

        CreatePositions();
        SpawnEnemy();
        if (player == false)
        {
            Destroy(this.gameObject);
        }
    }


}