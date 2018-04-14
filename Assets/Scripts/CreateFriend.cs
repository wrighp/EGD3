using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFriend : MonoBehaviour {

    public static CreateFriend i = null;
    public GameObject heart;
    public GameObject smoke;
    public GameObject pS;

    public AudioClip popSound;
    public AudioClip fizzleSound;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        if (i == null) i = this;
	}

    Queue<GameObject> spawnQueue = new Queue<GameObject>();

    public bool AttemptFriend(GameObject target, LinkedList<Follower> friendLine ) {
        List<Requirement> reqs = target.GetComponent<UnitData>().ot.friendRequirements;

        //Prepare the checks by resetting the requirements
        foreach (Requirement r in reqs) {
            r.remaining = r.quantity;
        }

        bool failed = false;

        foreach (Follower g in friendLine) {
            if (reqs.Count == 0) break;
            List<Tags> tags = g.GetComponent<UnitData>().ot.tags;

            bool matchFound = false;

            foreach (Tags t in tags) {
                foreach (Requirement r in reqs) {
                    if (t == r.requirement) {        
                        matchFound = true;
                        SpawnHeart(g.transform);
                        r.remaining--;
                    }
                }
            }

            if (!matchFound) {
                //No match was found, invalid Friend in the conga line
                SpawnDust(g.transform);
                failed = true;
            }
        }
        foreach (Requirement r in reqs) {
            if (r.remaining > 0) {
                audioSource = GetComponent<AudioSource>();
                audioSource.PlayOneShot(fizzleSound, 0.7F);
                audioSource.time = .8f;
                SpawnDust(target.transform);
                return false;
            }
        }

        if (failed)
            return false;

        //ANIMATE FREIND
        GameObject sys = Instantiate(pS, target.transform);
        sys.transform.parent = null;

        if (!spawnQueue.Contains(target))
            spawnQueue.Enqueue(target);

        Invoke("InvokeSpawn", .75f);

        return true;
    }

    public void InvokeSpawn() {
        GameObject t = spawnQueue.Dequeue();

        t.transform.GetChild(0).gameObject.SetActive(true);
        t.transform.GetChild(1).gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(popSound, 0.7F);
        audioSource.time = .8f;

        t.GetComponent<UnitData>().alive = true;
        t.GetComponent<Follower>().AttemptFollow(GetComponent<Leader>().followObject);
        t.GetComponent<Animator>().SetBool("Alive", true);
    }


    public void SpawnHeart(Transform t) {
        GameObject h = Instantiate(heart, t.transform);
        h.GetComponent<HeartMove>().parent = t.transform;
    }

    public void SpawnDust(Transform t) {
        GameObject h = Instantiate(smoke, t.transform);
        h.GetComponent<HeartMove>().parent = t.transform;
    }
}