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
}
