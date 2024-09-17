using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleSplash : MonoBehaviour
{
    public Material SplashMaterial;
    void Start()
    {
        SplashMaterial.SetFloat("_AnimationProgress", 0.0f);
        StartCoroutine(DoSplash());
    }
    IEnumerator DoSplash()
    {
        yield return new WaitForSeconds(1);
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
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainScene"));
    }

}
