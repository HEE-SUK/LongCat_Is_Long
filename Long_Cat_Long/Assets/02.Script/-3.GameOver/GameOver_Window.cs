using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver_Window : MonoBehaviour
{
    public GameOVer_Ads ads;
    public GameObject GameOver_prefab;
    public Sprite[] Num = new Sprite[4];

	void Start ()
    {
        Get_gameover();
        gameObject.SetActive(false);
	}

    void Get_gameover()
    {
        int rand_Num = Random.Range(0, 4);
        GameOver_prefab.GetComponent<Image>().sprite = Num[rand_Num];
        GameOver_prefab.GetComponent<Image>().SetNativeSize();
    }

    public void Set_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //if (PlayerPrefs.GetInt("Ads_Cnt")==1)
        //{
        //    PlayerPrefs.SetInt("Ads_Cnt", 0);
        //    ads.ShowRewardedVideo();
        //}
        //else
        //{
        //    PlayerPrefs.SetInt("Ads_Cnt", 1);
        //}
    }

}
