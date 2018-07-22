using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyer : MonoBehaviour {
    public int speed;
    public GameObject spawn;

	// Use this for initialization
	void Start () {
        speed = 20;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionStay(Collision collisionInfo)
    {
        collisionInfo.gameObject.transform.position = collisionInfo.gameObject.transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * speed;
        collisionInfo.rigidbody.useGravity = false;
    }

    void OnCollisionExit(Collision coll)
    {
        coll.rigidbody.useGravity = true;
    }

    public void spawnBox()
    {
        Instantiate(spawn, spawn.transform.position, Quaternion.identity);
    }
}
