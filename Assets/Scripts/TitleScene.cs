using UnityEngine;
using UnityEngine.PostProcessing;

public class TitleScene : MonoBehaviour {

	// Use this for initialization
	void Start () {

        PostProcessingProfile postProcessingProfile = Camera.main.GetComponent<PostProcessingBehaviour>().profile;
        ColorGradingModel.Settings set = postProcessingProfile.colorGrading.settings;
        set.basic.saturation = 1;
        postProcessingProfile.colorGrading.settings = set;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown) {
            FadeSystem.i.PerformFadeOut("Main");
        }
	}
}
