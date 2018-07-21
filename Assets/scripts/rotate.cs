using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

    public float rotationalSpeed;
    public float movementSpeed;
    public float range;

	// Use this for initialization
	void Start () {
        rotationalSpeed = 10;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        float newY = Mathf.Sin(Time.time * movementSpeed);
        transform.position = new Vector3(pos.x, newY * range, pos.z);
        transform.Rotate(Vector3.forward * rotationalSpeed * Time.deltaTime);
	}


    //transform.Translate(new Vector3(0, 1, 0) * Mathf.Sin(1) * rotationalSpeed * Time.deltaTime,Space.World);
}
