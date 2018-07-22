using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

    public float rotationalSpeed;
    public float movementSpeed;
    public float range;
    int counter;
    TextMesh tcounter;
    ParticleSystem particles;
    public Animator a;

	// Use this for initialization
	void Start () {
        rotationalSpeed = 10;
        tcounter = GameObject.FindGameObjectWithTag("counter").GetComponent<TextMesh>();
        particles = GameObject.FindGameObjectWithTag("particles").GetComponent<ParticleSystem>();
        a = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        float newY = Mathf.Sin(Time.time * movementSpeed);
        transform.position = new Vector3(pos.x, newY * range, pos.z);
        transform.Rotate(Vector3.forward * rotationalSpeed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        changeCounter(1);

        if(a != null)
        {
            a.Play("Clicked");
        }
        
        // Emit 1 cookie-particle when the big cookie is clicked
        particles.Emit(1);
    }

    public void changeCounter(int Amount)
    {
        if(Amount < 0)
        {
            if(counter >= -Amount)
            {
                counter += Amount;
                tcounter.text = "" + counter;
            }
        } else
        {
            counter += Amount;
            tcounter.text = "" + counter;
        }
            
        

    }


    //transform.Translate(new Vector3(0, 1, 0) * Mathf.Sin(1) * rotationalSpeed * Time.deltaTime,Space.World);
}
