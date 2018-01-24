using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Game : MonoBehaviour
{
    public GameObject UnPause;
    public bool Game_Stop =false;

    void Start()
    {
        UnPause.SetActive(false);
        //gameObject.SetActive(false);
    }

    public void OnButton_Pause()
    {
        UnPause.SetActive(!UnPause.activeSelf);
    }

    public void Get_Stop()
    {
        Game_Stop = !Game_Stop;

        if(Game_Stop==true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
