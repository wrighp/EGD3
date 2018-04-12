using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent (typeof (AICharacterControl))]
public class Follower : MonoBehaviour
{
    public float playerFollowDistance = 2.5f;
    public float followDistance = 4f;

    public bool following = false;
    public AICharacterControl target;

    // Use this for initialization
    void Start()
    {
        target = GetComponent<AICharacterControl>();
        CapsuleCollider collider = GetComponent<CapsuleCollider>();
        collider.height = GetComponent<NavMeshAgent>().height;
        collider.center = new Vector3(0, collider.height / 2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (target.target != null)
        {
            if (target.target.tag == "Player")
            {
               target.agent.stoppingDistance = playerFollowDistance;
            }
            else
            {
                target.agent.stoppingDistance = followDistance;
            }
        }
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    if(!following && collision.gameObject.name == "Player")
    //    {
    //        Leader leader = collision.gameObject.GetComponent<Leader>();
    //        Transform targ;
    //        if (leader.line.Count == 0)
    //        {
    //            targ = leader.transform;
    //        }
    //        else
    //        {
    //            targ = leader.line.Last.Value.transform;
    //        }
    //        target.target = targ;
    //        leader.line.AddLast(this);
    //        following = true;

    //        CreateFriend.i.AttemptFriend(gameObject, new List<GameObject>());
    //    }
    //}

    public void AttemptFollow(GameObject player) {
        UnitData uD = GetComponent<UnitData>();

        if (!following && uD.alive) {
            Leader leader = player.GetComponentInParent<Leader>();
            CreateFriend createFriend = player.GetComponentInParent<CreateFriend>();
            Transform targ;
            if (leader.line.Count == 0) {
                targ = player.transform;
            } else {
                targ = leader.line.Last.Value.transform;
            }
            target.target = targ;
            leader.line.AddLast(this);
            following = true;
            createFriend.SpawnHeart(this.transform);
        }

        if (!uD.alive) {
            CreateFriend.i.AttemptFriend(gameObject, GameObject.FindObjectOfType<Leader>().line);
        }

    }

}