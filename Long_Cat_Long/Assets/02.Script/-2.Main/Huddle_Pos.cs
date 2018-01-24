using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huddle_Pos : MonoBehaviour
{
    //오이불러올 변수
    public GameObject cucumer_prefab;
    public GameObject[] cucumbers;

    //위치변수
    private int arryMax = 5;
    private float Start_Pos;
    private float Gap = 10f;
    private float Left_pos = -6f;
    
    void Start ()
    {
        //넣을공간 초기화 및 시작위치
        cucumbers = new GameObject[arryMax];
        Start_Pos = transform.position.y;
        //오브젝트생성후 비활성화
        for (int i = 0; i < arryMax; i++)
        {
            float rand_pos = Random.Range(0f, 6f);
            cucumbers[i] = Instantiate(cucumer_prefab, 
                new Vector3(Left_pos + rand_pos / 2, Start_Pos + Gap * i, 0f), Quaternion.identity);
            cucumbers[i].transform.parent = transform;
        }
        gameObject.SetActive(false);
    }
    void Update()
    {
        //오이무한생성
        Get_Loop();
    }
    
    void Get_Loop()
    {
        for (int i = 0; i < arryMax; i++)
        {
            float rand_pos = Random.Range(0f, 6f);
            //일정위치 밑이면 새로 random받고 위로 올린다.
            if (cucumbers[i].transform.position.y <= -Gap)
            {
                cucumbers[i].transform.position = new Vector3(Left_pos + rand_pos / 2, 
                    cucumbers[i].transform.position.y+Gap * arryMax, 0f);
            }
        }
    }
}
