using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class NormalizedDistanceObject : MonoBehaviour {

    public Transform targetTransform;
    public float scale = 1f;

    Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (targetTransform != null)
        {
            targetTransform.position = Vector3.Lerp(targetTransform.position, transform.position + rigidbody.velocity * scale, .5f);
        }
	}
}
