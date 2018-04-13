using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class FriendEffects : MonoBehaviour {

    PostProcessingProfile postProcessingProfile;
    RectTransform uiMaskBack;
    AudioSource[] musicPlayers;

    public float speed = 2f;
    public float maxRotation = 15f;

    // Use this for initialization
    void Start () {
        postProcessingProfile = Camera.main.GetComponent<PostProcessingBehaviour>().profile;
        uiMaskBack = GameObject.Find("HeartUI").GetComponent<RectTransform>();
        musicPlayers = GameObject.Find("MusicPlayer").GetComponents<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        float live = 0;
        float total = 0;
        foreach (UnitData ud in GameObject.FindObjectsOfType<UnitData>()) {
            if (ud.alive) {
                live++;
            }
            total++;
        }
        
        ColorGradingModel.Settings set = postProcessingProfile.colorGrading.settings;
        set.basic.saturation = Mathf.Lerp(set.basic.saturation, live / total + .25f, Time.deltaTime);
        postProcessingProfile.colorGrading.settings = set;

        Vector3 next = new Vector3(.2f + 1f * (live / total), .2f + 1f * (live/total), 0);
        //next = next * (1 + .1f * Mathf.Sin(Time.time));


        uiMaskBack.localScale = Vector3.Lerp(uiMaskBack.localScale, next , Time.deltaTime);
        uiMaskBack.rotation = Quaternion.Euler(0f, 0f, maxRotation * (Mathf.Sin(Time.time * speed)));


        for (int i = 0; i < live/3 && i < 4; ++i) {
            musicPlayers[i].volume = Mathf.Lerp(musicPlayers[i].volume,1,Time.deltaTime);
        }


    }
}
