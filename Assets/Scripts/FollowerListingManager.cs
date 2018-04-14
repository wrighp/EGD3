using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FollowerListingManager : MonoBehaviour {

    public GameObject followerImage;
    public static FollowerListingManager i = null;

    public void Start() {
        if (i == null) {
            i = this;
        }
    }

    public void AddFriend(GameObject gO) {
        GameObject g = Instantiate(followerImage, transform);
        g.name = gO.name+"_RenderImage";
        GameObject.Find(gO.name + "_Camera").GetComponent<Camera>().enabled = true;
        g.GetComponent<RawImage>().texture = Resources.Load<RenderTexture>("RenderTexture/"+gO.name);
    }

    public void RemoveFriend(GameObject gO)  {
        GameObject.Find(gO.name + "_Camera").GetComponent<Camera>().enabled = false;
        Destroy(GameObject.Find(gO.name + "_RenderImage"));
    }
}
