using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMove : MonoBehaviour {

    public float lerpSpeed = .5f;
    public float lerpPosition = 0;

    public float transformOffset = 2f;
    public float scaleMax = 2f;

    Vector3 position;
    SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        lerpPosition += Time.deltaTime;

        transform.position = Vector3.Lerp(position, position + Vector3.up * transformOffset, lerpPosition * lerpSpeed);
        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * scaleMax, lerpPosition * lerpSpeed);
        sr.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, lerpPosition * lerpSpeed));

        if(lerpPosition * lerpSpeed > 1) {
            Destroy(gameObject);
            //TODO: PLAY NOISE HERE
        }
	}
}
