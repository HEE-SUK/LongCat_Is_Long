using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_Cat : MonoBehaviour
{
    //불러오는 클래스
    public Main_Mgr main_Mgr;
    public Pause_Game pause_Game;
    //따라갈 head인수
    public Transform target;
    
    //바디갯수배열
    public GameObject Body_Prefab;
    private GameObject[] Bodys;
    private int arryMax = 50;

    //속도변수
    private float F_speed = 0.07f;//따라가는속도
    private float F_dist = 0.071f;//body간 격차

    void Start ()
    {
        //바디배열생성후 프리팹삽입
        Bodys = new GameObject[arryMax];
        for (int i = 0; i < arryMax; i++)
        {
            Bodys[i] = Instantiate(Body_Prefab, new Vector3(target.position.x, target.position.y, 0f), Quaternion.identity);
            Bodys[i].transform.parent = transform;
        }
        gameObject.SetActive(false);
    }
	
	void Update ()
    {
        if(main_Mgr.Game_Over==false && pause_Game.Game_Stop==false)
        {
            //아래이동
            Move_Down();

            //좌우이동
            Move_Dir();

        }
    }

    void Move_Down()
    {
        for (int i = 0; i < arryMax; i++)
        {
            //지정위치에서 정지
            if (Bodys[i].transform.position.y < target.transform.position.y-(F_dist * i))
                Bodys[i].transform.position -= new Vector3(0f, 0f, 0f);
            //그전까진 Down
            else
                Bodys[i].transform.position -= new Vector3(0f, F_speed, 0f); 
        }
    }

    void Move_Dir()
    {
        for(int i=0;i<arryMax;i++)
        {
            Vector3 Cat_Pos;
            //타겟변동
            if (i == 0)
                Cat_Pos = new Vector3(target.position.x, Bodys[i].transform.position.y, 0f);
            else
                Cat_Pos = new Vector3(Bodys[i - 1].transform.position.x, Bodys[i].transform.position.y, 0f);
            
            //타겟추적
            Bodys[i].transform.position = Vector3.Lerp(Bodys[i].transform.position, Cat_Pos, 0.7f);
            //방향전환
            Bodys[i].transform.localScale = target.localScale;
        }
    }
}
