using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFriend : MonoBehaviour {

    public static CreateFriend i = null;
    public GameObject heart;
    public GameObject pS;

    public AudioClip sound;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        if (i == null) i = this;
	}

    Queue<GameObject> spawnQueue = new Queue<GameObject>();

    public bool AttemptFriend(GameObject target, List<GameObject> friendLine ) {
        //List<Requirement> reqs = target.GetComponent<ObjectTags>().freindRequirements;

        ////Prepare the checks by resetting the requirements
        //foreach (Requirement r in reqs) {
        //    r.remaining = r.quantity;
        //}

        //foreach (GameObject g in friendLine) {
        //    List<Tags> tags = g.GetComponent<ObjectTags>().tags;

        //    bool matchFound = false;

        //    foreach(Tags t in tags) {
        //        foreach(Requirement r in reqs) {
        //            if (t == r.requirement) {
        //                matchFound = true;
        //                r.remaining--;
        //            }
        //        }
        //    }

        //    if (!matchFound) {
        //        //No match was found, invalid Friend in the conga line
        //        break;
        //    }
        //}

        //foreach (Requirement r in reqs) {
        //    if (r.remaining != 0) return false; 
        //}

        //ANIMATE FREIND
        Instantiate(pS, target.transform.position, Quaternion.identity);
        spawnQueue.Enqueue(target);
        Invoke("InvokeSpawn", .75f);

        return true;
    }

    public void InvokeSpawn() {
        GameObject t = spawnQueue.Dequeue();

        t.transform.GetChild(0).gameObject.SetActive(true);
        t.transform.GetChild(1).gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound, 0.7F);
        audioSource.time = .8f;

        t.GetComponent<UnitData>().alive = true;
        t.GetComponent<Follower>().AttemptFollow(GetComponent<Leader>().followObject);

        GameObject h = Instantiate(heart, t.transform);
        h.GetComponent<HeartMove>().parent = t.transform;


        t = null;
    }
}