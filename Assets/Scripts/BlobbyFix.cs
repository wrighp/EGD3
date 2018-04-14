using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobbyFix : MonoBehaviour {
    public Material mat;

    // Use this for initialization
    void Start()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();  // get the first Skinned mesh renderer component (only active ones!) in the objects children
        skinnedMeshRenderer.material = mat;
    }
}
