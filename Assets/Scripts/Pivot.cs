using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour {

    public float speed = 10f;
    public float maxRotation = 30f;
    void Update() {
        // Slowly rotate the object arond its X axis at 1 degree/second.
        transform.rotation = Quaternion.Euler(0f, maxRotation * (Mathf.Sin(Time.time * speed)), 0f);
    }
}
