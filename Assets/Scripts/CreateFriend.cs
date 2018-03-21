﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFriend : MonoBehaviour {

    public static CreateFriend i = null;

	// Use this for initialization
	void Start () {
        if (i == null) i = this;
	}

    public bool AttemptFriend(GameObject target, List<GameObject> friendLine ) {
        List<Requirement> reqs = target.GetComponent<ObjectTags>().freindRequirements;

        //Prepare the checks by resetting the requirements
        foreach (Requirement r in reqs) {
            r.remaining = r.quantity;
        }

        foreach (GameObject g in friendLine) {
            List<Tags> tags = g.GetComponent<ObjectTags>().tags;

            bool matchFound = false;

            foreach(Tags t in tags) {
                foreach(Requirement r in reqs) {
                    if (t == r.requirement) {
                        matchFound = true;
                        r.remaining--;
                    }
                }
            }

            if (!matchFound) {
                //No match was found, invalid Friend in the conga line
                break;
            }
        }

        foreach (Requirement r in reqs) {
            if (r.remaining != 0) return false; 
        }

        //ANIMATE FREIND

        return true;
    }
}