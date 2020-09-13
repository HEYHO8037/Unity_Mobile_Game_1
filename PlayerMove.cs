using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer render;

    private float middle; // 화면 분할 지정
    private Vector2 Touchpos; // 화면 좌표값
    private float direction; // 차량 방향전환
    private float speed = 2f; // 차량 속도
    private float steeringPower = 2f; // 회전속도
    private float steeringAmount; // 회전힘
    private int Health = 2;
    private bool isUnBeatTime = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Touchpos = Input.GetTouch(0).position;
            middle = Screen.width / 2;
        }
    }

    private void FixedUpdate()
    {
        //보는방향 디렉션 지정
        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        if (Input.touchCount > 0 && Touchpos.x < middle && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            //오랜기간 터치시 회전속도 증가
            steeringAmount = 0.1f;
            //터치 시 각도 수정(좌측)
            rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;
            rb.AddRelativeForce(Vector2.up * speed);
            rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * 1f / 2);
            //지속적인 터치시 회전속도 증가
            steeringAmount += 0.2f;
            if (Touchpos.x < middle && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                steeringAmount = 0f;
            }
        }
        else if (Input.touchCount > 0 && Touchpos.x > middle && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            steeringAmount = -0.1f;
            //터치시 각도 수정(우측)
            rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;
            rb.AddRelativeForce(Vector2.up * speed);
            rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * -1f / 2);
            steeringAmount -= 0.2f;
            if (Touchpos.x < middle && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                steeringAmount = 0f;
            }
        }
        else
        {
            rb.AddRelativeForce(Vector2.up * (speed / 2));
        }

        if (Health == 0)
        {
            Destroy(this.gameObject);
                
        }
    }
    //충돌 시 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Health -= 1;
            if (Health > 1)
            {
                isUnBeatTime = true;
                StartCoroutine("UnBeatTime"); // 코루틴 실행
            }
        }
    }

    //충돌 시 무적시간 부여 함수
    IEnumerator UnBeatTime()
    {
        int countTime = 0;
        while (countTime < 10)
        {
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        isUnBeatTime = false;

        yield return null;

    }

}


