using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Mgr : MonoBehaviour
{
    //시작변수
    public Main_Mgr main;
    public GameObject Start_UI;
    void Start ()
    {
        //해상도 고정
        Screen.SetResolution(720, 1280, true);
    }
	
	void Update ()
    {
        //게임시작
        if(Input.GetMouseButtonDown(0))
        {
            //시작시 활성화
            main.gameObject.SetActive(true);
            //시작시 비활성화
            Start_UI.SetActive(false);
            gameObject.SetActive(false);
        }
        //시작대기
        else
        {
            // TODO: 시작대기
        }
    }
}
