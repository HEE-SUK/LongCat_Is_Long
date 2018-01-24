using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver_Score : MonoBehaviour
{
    //좌표변수
    public Score_Cat score_Cat;
    bool get_Once = false;

    //이미지변수
    public GameObject Score_Prefab;
    public GameObject[] Score_img = new GameObject[4];
    public Sprite[] Num = new Sprite[10];
    public int[] Num_Cnt;
    int Score_Cnt = 4;
    int Current;

    void Start ()
    {
        //넣을공간 초기화
        Num_Cnt = new int[Score_Cnt];

        //오브젝트생성
        for (int i = 0; i < Score_Cnt; i++)
        {
            Score_img[i] = Instantiate(Score_Prefab, new Vector3(transform.position.x - 40 * i, transform.position.y, 0f), Quaternion.identity); 
            Score_img[i].transform.SetParent(transform);
            Score_img[i].gameObject.SetActive(false);
        }
    }
	
	void Update ()
    {
        //한번만불러오기
        if (get_Once == false)
        {
            //점수호출
            Get_Score();
            //sprite호출
            Get_Sprite();

            get_Once = true;
        }
    }


    void Get_Score()
    {
        //마지막위치
        Current = (int)score_Cat.Score;

        //자릿수분리
        for (int i = 0; i < Score_Cnt; i++)
        {
            Num_Cnt[i] = (int)(Current / Mathf.Pow(10, i)) % 10;
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
                for (int j = i; j >= 0; j--)
                {
                    Score_img[j].gameObject.SetActive(true);
                }
                break;
            }
        }
    }
}
