using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Leader : MonoBehaviour {

    public LinkedList<Follower> line = new LinkedList<Follower>();

    // Use this for initialization
    void Start () {
		
	}

    public float jumpForce = 4f;
    public ForceMode jumpForceMode = ForceMode.VelocityChange;
    public float jumpTimeDelay = .25f;

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

        //Needs grounded checks
        if (Input.GetButtonDown("Jump"))
        {

            float duration = 0;
            foreach(var follower in line)
            {
                duration += jumpTimeDelay;
                StartCoroutine(FollowerJumper(follower.GetComponent<Rigidbody>(), duration));
            }
        }

    }
    //Needs grounded checks
    IEnumerator FollowerJumper(Rigidbody rigidbody, float delayTime)
    {

        yield return new WaitForSeconds(delayTime);
        //Debug.Log("Jump " + rigidbody.name);
        if (rigidbody == null)
        {
            yield break;
        }
        NavMeshAgent agent = rigidbody.GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        //agent.isStopped = true;
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpForce, rigidbody.velocity.z);
        //rigidbody.AddForce(0, jumpForce, 0, jumpForceMode);
        agent.velocity = rigidbody.velocity;

        //Or until grounded
        yield return new WaitForSeconds(.75f);

        agent.updatePosition = true;
       // agent.isStopped = false;
    }

    private void performHug() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.rotation * new Vector3(0, .5f, 1.5f), 1.5f);
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
