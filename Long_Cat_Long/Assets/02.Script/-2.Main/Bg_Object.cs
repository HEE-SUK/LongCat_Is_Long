using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg_Object : MonoBehaviour {

    public bool Get_Scroll = false;
    
    void Start () {
		
	}
	
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            Get_Scroll = true;
        }
    }

}
