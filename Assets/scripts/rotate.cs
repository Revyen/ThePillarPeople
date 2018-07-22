using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.XR.WSA.Persistence;
using UnityEngine.XR.WSA;
using UnityEngine.XR;

public class rotate : MonoBehaviour {

    public float rotationalSpeed;
    public float movementSpeed;
    public float range;
    public GestureRecognizer ger;
    int counter;
    TextMesh tcounter;
    ParticleSystem particles;
    public Animator a;
    GameObject button;
    GameObject conv;




    // Use this for initialization
    void Start () {
        rotationalSpeed = 10;
        tcounter = GameObject.FindGameObjectWithTag("counter").GetComponent<TextMesh>();
        particles = GameObject.FindGameObjectWithTag("particles").GetComponent<ParticleSystem>();
        a = GetComponent<Animator>();
        button = GameObject.FindGameObjectWithTag("button");
        if (XRDevice.SetTrackingSpaceType(TrackingSpaceType.RoomScale))
        {
            // RoomScale mode was set successfully.  App can now assume that y=0 in Unity world coordinate represents the floor.
            Debug.Log("Roomscale success");
        }
        else
        {
            Debug.Log("Roomscale not");
            // RoomScale mode was not set successfully.  App cannot make assumptions about where the floor plane is.
        }

        ger = new GestureRecognizer();
        //ger.SetRecognizableGestures(GestureSettings.Tap);
        //ger.SetRecognizableGestures(GestureSettings.Hold);
        ger.TappedEvent += GestureRecognizer_TappedEvent;
        ger.HoldCompletedEvent += GestureRecognizer_HoldEvent;
        ger.HoldStartedEvent += GestureRecognizer_HoldStarted;


        ger.StartCapturingGestures();
        conv = GameObject.FindGameObjectWithTag("spawner");
    }



    private void GestureRecognizer_HoldStarted(InteractionSourceKind source, Ray headRay)
    {
        button.transform.localScale = button.transform.localScale + new Vector3(0.25f,0.25f,0.25f);
    }

    private void GestureRecognizer_HoldEvent(InteractionSourceKind source, Ray headRay)
    {
        OnHoldFinished();
        button.transform.localScale = button.transform.localScale - new Vector3(0.25f, 0.25f, 0.25f);
    }

    private void GestureRecognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        OnTap();
    }

    private void OnHoldFinished()
    {
        changeCounter(-5);
    }

    private void OnTap()
    {
        changeCounter(1);

        if (a != null)
        {
            a.Play("Clicked");
        }

        // Emit 1 cookie-particle when the big cookie is clicked
        particles.Emit(1);
    }

    private void OnMouseDown()
    {
        changeCounter(1);

        if (a != null)
        {
            a.Play("Clicked");
        }

        // Emit 1 cookie-particle when the big cookie is clicked
        particles.Emit(1);
    }

    // Update is called once per frame
    void Update () {
        Vector3 pos = transform.position;
        float newY = Mathf.Sin(Time.time * movementSpeed);
        transform.position = new Vector3(pos.x, newY * range, pos.z);
        transform.Rotate(Vector3.forward * rotationalSpeed * Time.deltaTime);
	}

    public void changeCounter(int Amount)
    {
        if (Amount < 0)
        {
            if (counter >= -Amount)
            {
                counter += Amount;
                tcounter.text = "" + counter;
                conv.GetComponent<conveyer>().spawnBox();
            }
        }
        else
        {
            counter += Amount;
            tcounter.text = "" + counter;
        }
    }



    //transform.Translate(new Vector3(0, 1, 0) * Mathf.Sin(1) * rotationalSpeed * Time.deltaTime,Space.World);
}
