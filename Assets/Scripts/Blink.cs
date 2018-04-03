using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    Transform[] eyes = new Transform[2];
    Vector3[] eyeMaxSize = new Vector3[2];

    public float eyeBlinkTime;
    public float currentTime;

    public float eyeBlinkSpeed;
    public float eyeBlinkCurrent;

    public int eyeDirection = 1;

	// Use this for initialization
	void Start () {
        eyes[0] = transform.GetChild(0);
        eyes[1] = transform.GetChild(1);

        eyeMaxSize[0] = new Vector3(eyes[0].localScale.x, eyes[0].localScale.y,eyes[0].localScale.z);
        eyeMaxSize[1] = new Vector3(eyes[1].localScale.x, eyes[1].localScale.y, eyes[1].localScale.z);

        eyeBlinkSpeed = Random.Range(1, 4)/3f;
        eyeBlinkTime = Random.Range(5, 14);

        currentTime = 0;
        eyeBlinkCurrent = 0;
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if (currentTime > eyeBlinkTime) {
            eyeBlinkCurrent += Time.deltaTime * eyeDirection;
            eyeBlinkCurrent = Mathf.Clamp(eyeBlinkCurrent, 0, eyeBlinkSpeed);

            for (int i = 0; i < 2; i++) {
                eyes[i].localScale = new Vector3(eyeMaxSize[i].x, eyeMaxSize[i].y * (1 - (eyeBlinkCurrent / eyeBlinkSpeed)), eyeMaxSize[i].z);
            }

            if (eyeBlinkCurrent >= eyeBlinkSpeed && eyeDirection == 1) {
                print("1");
                eyeBlinkCurrent = eyeBlinkSpeed;
                eyeDirection = -1;
            }

            if (eyeBlinkCurrent == 0 && eyeDirection == -1) {
                print("2");
                eyeBlinkSpeed = Random.Range(1, 4) / 3f;
                eyeBlinkTime = Random.Range(5, 14);

                currentTime = 0;
                eyeBlinkCurrent = 0;

                eyeDirection = 1;
            }

        }
	}
}
