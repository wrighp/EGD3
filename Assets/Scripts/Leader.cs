using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour {

    public LinkedList<Follower> line = new LinkedList<Follower>();

    // Use this for initialization
    void Start () {
		
	}

    bool triggerPressed = false;

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

        /*
        if (Input.GetButtonDown("RightBumper")) {
            if (Input.GetButtonDown("LeftBumper")) {

                print("Hug");

                performHug();
            }
        }
        */
        //If triggers are both pressed fire perform hug once
        if (Input.GetAxis("RightBumper") > .25f && Input.GetAxis("LeftBumper") > .25f)
        {
            if (!triggerPressed)
            {
                print("Hug");
                triggerPressed = true;
                performHug();
            }
        }
        else
        {
            triggerPressed = false;
        }

    }

    private void performHug() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + new Vector3(0, .5f, 1.5f), 3f);
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

    //public class ExampleClass : MonoBehaviour {
    //    void OnDrawGizmosSelected() {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawWireSphere(transform.position + new Vector3(0, .5f, 5f), 5f);
    //    }
    //}
}
