using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayTVScript : MonoBehaviour
{
    void Start()
    {
        var rt = RenderTexture.GetTemporary(1024, 768);
        this.gameObject.GetComponent<VideoPlayer>().targetTexture = rt;
        this.gameObject.GetComponent<MeshRenderer>().material.mainTexture = rt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
