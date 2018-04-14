using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItem : MonoBehaviour {

    bool effectStart = false;
    RectTransform rect = null;
    float velocity = 0f;
    string charName;

	// Use this for initialization
	void Start () {
        rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (effectStart) {
            velocity += 9.8f;
            rect.anchoredPosition -= new Vector2(0, velocity) * Time.deltaTime;
            if (rect.anchoredPosition.y < -1000) {
                Destroy(gameObject);
                GameObject.Find(charName + "_Camera").GetComponent<Camera>().enabled = false;
            }
        }
	}

    public void StartEffect(string  name) {
        charName = name;
        effectStart = true;
        //Edition
        transform.SetParent(GameObject.Find("Canvas").transform);
    }
}
