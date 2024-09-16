using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSplash : MonoBehaviour
{
    public Material SplashMaterial;
    void Start()
    {
        StartCoroutine(DoSplash());
    }
    IEnumerator DoSplash()
    {
        yield return new WaitForSeconds(3);
        float totalDuration = 6.0f;
        float currentTime = 0.0f;
        float framePerSecond = 30.0f;
        SplashMaterial.SetFloat("_AnimationProgress", 0.0f);

        while (currentTime < totalDuration)
        {
            currentTime += 1.0f / framePerSecond;
            yield return new WaitForSeconds(1.0f / framePerSecond);
            SplashMaterial.SetFloat("_AnimationProgress", currentTime / totalDuration);
        }
        SplashMaterial.SetFloat("_AnimationProgress", 1.0f);
    }

}
