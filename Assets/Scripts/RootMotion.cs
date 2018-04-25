using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class RootMotion : MonoBehaviour {

    public float speedMod = 1f;

    void OnAnimatorMove() {
        Animator animator = GetComponent<Animator>();

        if (animator) {
            Vector3 newPosition = transform.position;
            newPosition += animator.GetFloat("MoveSpeed") * Time.deltaTime * transform.forward * speedMod;
            transform.position = newPosition;
        }
    }
}
