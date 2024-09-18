using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayTVScript : MonoBehaviour
{
    const float SCALE = 1.0f/5.0f;

    public Vector2 Offset;
    private Material _material;
    void Start()
    {
        var goVideoPlayer = GameObject.Find("VideoPlayerMultiScreen");
        _material = this.gameObject.GetComponent<MeshRenderer>().material;
        _material.mainTexture =  goVideoPlayer.GetComponent<VideoPlayer>().targetTexture;//goVideoPlayer.GetComponent<HolderTexture>().Texture;//
        _material.SetFloat("_ScreenScale",  SCALE);
        _material.SetFloat("_NeedsMapping", this.gameObject.name == "TV.003" ? 1.0f : 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        _material.SetVector("_ScreenOffset", Offset);
    }
}
