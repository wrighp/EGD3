using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ScreenFade : MonoBehaviour {

    PostProcessingProfile postProcessingProfile;
    
    // Use this for initialization
	void Start () {
        postProcessingProfile = Camera.main.GetComponent<PostProcessingBehaviour>().profile;
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
    }
}
