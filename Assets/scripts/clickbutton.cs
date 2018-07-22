using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class clickbutton : MonoBehaviour {
    rotate mainCookie;

    // Use this for initialization
    void Start () {
        mainCookie = GameObject.FindGameObjectWithTag("mainCookie").GetComponent<rotate>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        mainCookie.changeCounter(-5);
        Debug.Log("Change!");
    }
}
