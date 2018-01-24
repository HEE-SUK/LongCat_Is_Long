using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg_Scroll : MonoBehaviour
{
    public Main_Mgr main_Mgr;
    public Pause_Game pause_Game;

    public GameObject[] Back_Prefab = new GameObject[2];
    public GameObject[] Back_Scroll = new GameObject[3];

    public Sprite[] bg_sprite = new Sprite[5];

    private bool On_Scroll = false;
    private float Scroll_Line = 3f;
    private float PageZs = 12.8f;
    private float Change_Line = 12.8f * 10;

    void Start ()
    {
        //하늘두개생성
        for(int i = 0;i<2;i++)
        {
            Back_Scroll[i] = Instantiate(Back_Prefab[0], new Vector3(0f, 12.8f*(i+1), 0f), Quaternion.identity);
            Back_Scroll[i].transform.SetParent(transform);
        }
        //변화지점 자리고정
        Back_Scroll[2] = Instantiate(Back_Prefab[1], new Vector3(0f, Change_Line, 0f), Quaternion.identity);
        Back_Scroll[2].transform.SetParent(transform);

        gameObject.SetActive(false);
    }


    void Update ()
    {
        if(main_Mgr.Game_Over==false && pause_Game.Game_Stop==false)
        {
            for (int i = 0; i < 3; i++)
            {
                Back_Scroll[i].transform.position -= new Vector3(0f, 0.04f, 0f);
            }
        }
        

        //하늘 체인지
        Change_Sky();

        //배경 스크롤
        Scroll_Sky();
        
    }

    void Scroll_Sky()
    {
        //번갈아가면서한칸씩위로
        if (Back_Scroll[0].transform.position.y <= Scroll_Line && On_Scroll == false)
        {
            Back_Scroll[1].transform.position = new Vector3(0f, Back_Scroll[0].transform.position.y + 12.8f, 0f);
            On_Scroll = true;
        }
        else if (Back_Scroll[1].transform.position.y <= Scroll_Line && On_Scroll == true)
        {
            Back_Scroll[0].transform.position = new Vector3(0f, Back_Scroll[1].transform.position.y + 12.8f, 0f);
            On_Scroll = false;
        }
        else if(Back_Scroll[2].transform.position.y <= -PageZs)
        {
            if(Back_Scroll[2].GetComponent<SpriteRenderer>().sprite == bg_sprite[4])
            {
                Back_Scroll[2].SetActive(false);
                return;
            }
            Back_Scroll[2].GetComponent<SpriteRenderer>().sprite = bg_sprite[4];
            Back_Scroll[2].transform.position = new Vector3(0f,Change_Line, 0f);
        }
    }

    
    //다음배경으로 change
    void Change_Sky()
    {
        if (Back_Scroll[2].transform.position.y <= Scroll_Line)
        {
            if(Back_Scroll[2].GetComponent<SpriteRenderer>().sprite == bg_sprite[3])
            {

                Back_Scroll[0].GetComponent<SpriteRenderer>().sprite = bg_sprite[1];
                Back_Scroll[1].GetComponent<SpriteRenderer>().sprite = bg_sprite[1];
            }
            else if(Back_Scroll[2].GetComponent<SpriteRenderer>().sprite == bg_sprite[4])
            {
                Back_Scroll[0].GetComponent<SpriteRenderer>().sprite = bg_sprite[2];
                Back_Scroll[1].GetComponent<SpriteRenderer>().sprite = bg_sprite[2];
            }
        }
    }
}
