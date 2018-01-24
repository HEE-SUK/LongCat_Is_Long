using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceBook_On : MonoBehaviour
{
    public Score_Cat score_Cat;
    public string[] str = new string[4];
	
    const string FACEBOOK_APP_ID = "704471386423691";
    const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";
    const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";

    void Start()
    {
        str[0] = "Meowwwwwwwwwwww~";
        str[1] = "The LongCat is Down~";
        str[2] = "Heeeeeeeeeeeeeing~";
        str[3] = "Yaaaaaaaaaaaaong~";
    }

    public static void ShareToFacebook(
        string linkParameter, string nameParameter, string captionParameter,
        string descriptionParameter, string pictureParameter, string redirectParameter
        )
    {
        Application.OpenURL(FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
        "&link=" + WWW.EscapeURL(linkParameter) +
        "&name=" + WWW.EscapeURL(nameParameter) +
        "&caption=" + WWW.EscapeURL(captionParameter) +
        "&description=" + WWW.EscapeURL(descriptionParameter) +
        "&picture=" + WWW.EscapeURL(pictureParameter) +
        "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
    }

    public static void ShareToTwitter(string textToDisplay, string language)
    {// language: "en", "kor", "jap"
        Application.OpenURL(TWITTER_ADDRESS +
                    "?text=" + WWW.EscapeURL(textToDisplay) +
                    "&amp;lang=" + WWW.EscapeURL(language));
    }

    public void OnBtnFaceBook()
    {
        ShareToFacebook(
            "http://sunbug.net",            // linkParameter
            "My Funny Game",                // nameParameter
            "My Caption Message",           // captionParameter
            "My Description Message",       // descriptionParameter
            "https://www.google.co.kr/images/srpr/logo11w.png", //pictureParameter
            "http://www.facebook.com"       // redirectParamter
            );
    }

    public void OnBtnTwitter()
    {
        int rand_Num = Random.Range(0, 4);
        
        ShareToTwitter(str[rand_Num] + "\nMiaong:" + (int)score_Cat.Score + "\n" +
            "#LongcatisLong #고양이게임 #우주까지 #가즈아", "kor");
    }
    
}
