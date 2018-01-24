﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Cat : MonoBehaviour
{
    //시작변수
    public Main_Mgr main_Mgr;
    public Pause_Game pause_Game;
    public float Score = 0f;
    private float score_Per = 0.1f;

    //이미지 변수
    public GameObject Score_Prefab;
    public GameObject[] Score_img =new GameObject[4];
    public Sprite[] Num = new Sprite[10];
    public int[] Num_Cnt;
    int Score_Cnt = 4;

    void Start ()
    {
        //넣을공간 초기화
        Num_Cnt = new int[Score_Cnt];
        //오브젝트생성
        for (int i = 0; i < Score_Cnt; i++)
        {
            Score_img[i] = Instantiate(Score_Prefab, new Vector3(transform.position.x + 330 - 40 * i, transform.position.y, 0f), Quaternion.identity);
            Score_img[i].transform.SetParent(transform);
            Score_img[i].gameObject.SetActive(false);
        }
        //시작시 Unactive
        Score_img[0].gameObject.SetActive(true);
    }

    void Update()
    {
        if(pause_Game.Game_Stop==false && main_Mgr.Timer >= 100)
        {
            //점수
            Score += score_Per;
        }

        //점수가져오기
        Get_Score();
        //sprite적용
        Get_Sprite();
    }
   

    void Get_Score()
    {
        if (main_Mgr.Timer >= 100)
        {
            //자릿수분리
            for (int i = 0; i < Score_Cnt; i++)
            {
                Num_Cnt[i] = (int)(Score / Mathf.Pow(10, i)) % 10;
            }
        }
    }

    void Get_Sprite()
    {
        //이미지적용
        for (int i = 0; i < Score_Cnt; i++)
        {
            Score_img[i].GetComponent<Image>().sprite = Num[Num_Cnt[i]];
        }
        //자릿수 active
        for (int i = Score_Cnt - 1; i >= 0; i--)
        {
            if (Num_Cnt[i] > 0)
            {
                Score_img[i].gameObject.SetActive(true);
            }
        }
    }
}
