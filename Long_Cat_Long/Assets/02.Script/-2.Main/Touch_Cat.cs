using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Cat : MonoBehaviour
{
    //Mgr변수
    public Main_Mgr main_Mgr;
    public Pause_Game pause_Game;
    //이동 인수
    private bool Direction =false;
    private float Dir_speed = 0.07f;

    //게임시작 인수 bool
    private Animator ani;
    void Start()
    {
        //비활성화
        ani = GetComponent<Animator>();        
        gameObject.SetActive(false);
    }

    void Update()
    {
        //대기시간
        if (main_Mgr.Timer >= 150)
        {
            //게임시작
            if (main_Mgr.Game_Over == false && pause_Game.Game_Stop==false)
            {
                Change_Move();
            }
        }
        //애옹이이동범위제한
        MoveLimit();
    }
    

    //애옹이 늘어남 제어
    void Change_Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //터치소리
            gameObject.GetComponent<AudioSource>().Play();
            //방향전환
            Direction = !Direction;
        }
        //왼쪽으로
        if (Direction == false)
        {
            transform.position += new Vector3(-Dir_speed, 0f, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        //오른쪽으로
        else
        {
            transform.position += new Vector3(Dir_speed, 0f, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    //방해물과 충돌
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Huddle")
        {
            ani.SetBool("Game_Over", true);
            main_Mgr.Game_Over = true;
            //bGameOver = true;
        }
    }

    //애옹이 최대이동범위제한
    void MoveLimit()
    {
        Vector3 temp;
        temp.x = Mathf.Clamp(transform.position.x, -2.5f, 2.5f);
        temp.y = Mathf.Clamp(transform.position.y, -10f, 10f);
        temp.z = Mathf.Clamp(transform.position.z, -10f, 10f);
        transform.position = temp;
    }
    
}
