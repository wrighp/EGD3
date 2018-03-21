using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour {

    public LinkedList<Follower> line = new LinkedList<Follower>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Drop"))
        {
            DropLastFollower();
        }
        if (Input.GetButtonDown("DropLine"))
        {
            DropLine();
        }

        bool notHug = true;
        if (Input.GetButton("RightBumper")) {
            if (Input.GetButtonDown("LeftBumper")) {

                print("Hug");
                notHug = false;

                performHug();
            }
        }
        if (Input.GetButton("LeftBumper") && notHug) {
            if (Input.GetButtonDown("RightBumper")) {

                print("Hug");
                performHug();
            }
        }

    }

    private void performHug() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + new Vector3(0, .5f, 1.5f), 1.5f);
        int i = 0;
        while (i < hitColliders.Length) {
            Follower f = hitColliders[i].gameObject.GetComponent<Follower>();
            if (f != null) {
                f.AttemptFollow(gameObject);
            }
            i++;
        }
    }

    private void DropLastFollower()
    {
        if(line.Count <= 0)
        {
            return;
        }

        Follower last = line.Last.Value;
        last.following = false;
        last.target.target = null;
        line.RemoveLast();
    }

    private void DropLine()
    {
        while(line.Count > 0)
        {
            DropLastFollower();
        }
    }
}
