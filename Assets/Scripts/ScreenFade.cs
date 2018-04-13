using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ScreenFade : MonoBehaviour {

    PostProcessingProfile postProcessingProfile;
    RectTransform uiMaskBack;

    // Use this for initialization
	void Start () {
        postProcessingProfile = Camera.main.GetComponent<PostProcessingBehaviour>().profile;
        uiMaskBack = GameObject.Find("HeartBackGroundLayer").GetComponent<RectTransform>();

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

        Vector3 next = new Vector3(0, -150f + 100f * (live/total), 0);
        next = next * (1 + .1f * Mathf.Sin(Time.time));
        print(next);
        uiMaskBack.anchoredPosition = Vector3.Lerp(uiMaskBack.anchoredPosition, next , Time.deltaTime);
    }
}
