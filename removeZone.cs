using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class removeZone : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText;

    [SerializeField]
    private GameObject Player;

    private float timer;
    protected int score;

    private void Update() // 시간에 따라 점수 부여
    {
        if (Player == true)
        {
            timer += Time.deltaTime;

            if (timer > 1f)
            {

                score += 5;
                ScoreText.text = "SCORE : " + score.ToString(); //점수 반영


                timer = 0; //타이머 리셋
            }
        }
        else if(Player == false)
        {
            ScoreText.text = "Score : " + score.ToString();
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy") // 적 차량 통과시 추가점수 부여
        {
            Destroy(collision.gameObject);
            score += 100;
            ScoreText.text = "SCORE : " + score.ToString();
        }

        if(collision.gameObject.tag == "Item")
        {
            Destroy(collision.gameObject);
        }
    }
}
