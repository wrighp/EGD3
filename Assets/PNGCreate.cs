using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNGCreate : MonoBehaviour {

    RenderTexture[] rTs;

	// Use this for initialization
	void Start () {
        rTs = Resources.LoadAll<RenderTexture>("RenderTexture");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.L)) {
            
            foreach (RenderTexture rt in rTs) {
                print(rt.name);
                RenderTexture currentActiveRT = RenderTexture.active;
                RenderTexture.active = rt;
                Texture2D tex = new Texture2D(rt.width, rt.height);
                tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
                var bytes = tex.EncodeToPNG();
                System.IO.File.WriteAllBytes("\\Users\\Stiggy\\Desktop\\"+rt.name+".png", bytes);
                UnityEngine.Object.Destroy(tex);
                RenderTexture.active = currentActiveRT;
            }
        }

	}
}
