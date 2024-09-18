using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo2 : MonoBehaviour
{
    public Material FullscreenMat;
    private void Start()
    {
        FullscreenMat.SetFloat("_Progress", 0.0f);
        var videoPlayer = this.gameObject.GetComponent<VideoPlayer>();
    }
    IEnumerator _playVideo()
    {
        var videoPlayer = this.gameObject.GetComponent<VideoPlayer>();
        videoPlayer.Play();
        yield return new WaitForSeconds(2.0f);
        float step = 1.0f / 30.0f;
        float totalDuration = 6.0f;
        float curTime = 0.0f;
        FullscreenMat.SetFloat("_Progress", 0.0f);
        while (curTime < totalDuration)
        {
            FullscreenMat.mainTexture = videoPlayer.targetTexture;
            FullscreenMat.SetFloat("_Progress", curTime / totalDuration);
            curTime += step;
            yield return new WaitForSeconds(step);
        }
        FullscreenMat.SetFloat("_Progress", 1.0f);
        yield return new WaitForSeconds(3.0f);
        FullscreenMat.SetFloat("_Progress", 0.0f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("KEEEE");
            StartCoroutine(_playVideo());
        }
    }
}
