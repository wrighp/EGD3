using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float speed = 10f;

    void Update() {
        // Slowly rotate the object arond its X axis at 1 degree/second.
        transform.Rotate(Time.deltaTime * speed, 0, 0);
    }
}
