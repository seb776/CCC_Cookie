using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPodium : MonoBehaviour
{
    private RenderTexture _renderTexture;
    void Start()
    {
        var vidPlayer = this.gameObject.GetComponent<VideoPlayer>();
        vidPlayer.renderMode = VideoRenderMode.RenderTexture;
        vidPlayer.isLooping = true;
        vidPlayer.SetDirectAudioVolume(0, 0.0f);
        vidPlayer.Play();
        _renderTexture = RenderTexture.GetTemporary(480, 360);
        vidPlayer.targetTexture = _renderTexture;
        var mat = this.gameObject.GetComponent<MeshRenderer>().material;
        mat.SetTexture("_MainTex", _renderTexture);
        mat.SetFloat("_NeedsMapping", this.gameObject.name == "TV.003" ? 1.0f : 0.0f);

    }

    void Update()
    {
        
    }
}
