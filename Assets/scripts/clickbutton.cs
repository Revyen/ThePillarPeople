using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class clickbutton : MonoBehaviour {
    rotate mainCookie;
    GameObject conv;

    // Use this for initialization
    void Start () {
        mainCookie = GameObject.FindGameObjectWithTag("mainCookie").GetComponent<rotate>();
        conv = GameObject.FindGameObjectWithTag("spawner");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        mainCookie.changeCounter(-5);
        conv.GetComponent<conveyer>().spawnBox();
        Debug.Log("Change!");
    }
}
