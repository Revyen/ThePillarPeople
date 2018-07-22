using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;

public class CookieAnchor : MonoBehaviour {

    public string AnchorName = "123456789";
    public bool Undo = false;
    // Use this for initialization
    void Start () {
        WorldAnchorManager.Instance.AttachAnchor(this.gameObject, AnchorName);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
