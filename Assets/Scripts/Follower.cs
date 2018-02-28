using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Follower : MonoBehaviour
{

    public bool following = false;
    AICharacterControl target;

    // Use this for initialization
    void Start()
    {
        target = GetComponent<AICharacterControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if(!following && collision.gameObject.name == "Player")
        {
            Leader leader = collision.gameObject.GetComponent<Leader>();
            Transform targ;
            if (leader.line.Count == 0)
            {
                targ = leader.transform;
            }
            else
            {
                targ = leader.line.Last.Value.transform;
            }
            target.target = targ;
            leader.line.AddLast(this);
            following = true;
        }
    }
}