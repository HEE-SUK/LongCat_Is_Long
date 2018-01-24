using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Cat : MonoBehaviour {

    //다른 스크립트호출
    public Main_Mgr main_Mgr;
    public Touch_Cat Cat;
    private Animator ani;

    void Start ()
    {
        ani = GetComponent<Animator>();
    }
	
	void Update ()
    {
        //시작
		if(main_Mgr.Game_Start==true)
        {
            ani.SetBool("Start_On_Bool", true);
        }
        else
        {
            ani.SetBool("Start_On_Bool", false);
        }

        change_dir();
    }
    
    void change_dir()
    {
        if (Cat.transform.localScale.x > 0)
        {
            transform.localScale= new Vector3(1f,1f,1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
