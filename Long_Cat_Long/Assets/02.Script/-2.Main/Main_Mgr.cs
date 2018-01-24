using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Mgr : MonoBehaviour
{
    //게임시작 및 종료
    public bool Game_Over;
    public bool Game_Start;

    //불러오는 오브젝트
    public Camera MainCamera;
    public Start_Cat start_Cat;
    public GameOver_Window gameOver_Window;
    public Touch_Cat touch_Cat;
    public Body_Cat body_Cat;
    public Pause_Game pause_Game;
    public Huddle_Pos huddle_Pos;
    public Bg_Scroll bg_Scroll;

    public GameObject bg_01;
    public GameObject main_Wnd;

    //배경속도변수
    private float Bg1_Speed = 0.07f;
    //private float Bg2_Speed = 0.06f;

    //대기시간 초기화
    public int Timer = 0;

    void Start ()
    {
        Game_Start = false;
        //메인화면에서만 active
        gameObject.SetActive(false);

        main_Wnd.SetActive(false);
    }
	
	void Update ()
    {
        if (Game_Start==false)
        {
            //시작시 한번만 활성화 호출
            main_Wnd.SetActive(true);
            touch_Cat.gameObject.SetActive(true);      
            pause_Game.gameObject.SetActive(true);
            bg_Scroll.gameObject.SetActive(true);
            huddle_Pos.gameObject.SetActive(true);
            Game_Start = true;
        }
        
        //게임시작
        Get_Main();
        
    }

    void Get_Main()
    {
        //게임실행
        if (Game_Over == false&& pause_Game.Game_Stop == false)
        {
            //대기시간후 이동
            if (Timer >= 100)
            {
                body_Cat.gameObject.SetActive(true);
                start_Cat.transform.position -= new Vector3(0f, Bg1_Speed , 0f);
                huddle_Pos.transform.position -= new Vector3(0f, Bg1_Speed + 0.05f, 0f);
                //bg_Scroll.transform.position -= new Vector3(0f, Bg2_Speed, 0f);
                bg_01.transform.position -= new Vector3(0f, Bg1_Speed , 0f);
            }
        }
        //게임오버
        else if(Game_Over == true)
        {
            main_Wnd.SetActive(false);
            pause_Game.gameObject.SetActive(false);
            gameOver_Window.gameObject.SetActive(true);
            MainCamera.GetComponent<AudioSource>().volume = 0;
        }
        //딜레이
        if (Timer <= 150)
            Timer++;

    }
    
}
