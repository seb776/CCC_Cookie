using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateChairWeird : MonoBehaviour
{
    public float Frequency;
    public float Speed;
    void Start()
    {
        
    }

    void Update()
    {
        int i = 0;
        foreach (Transform t in this.gameObject.transform)
        {
            float coef = Mathf.Sin(Time.realtimeSinceStartup*Speed + (float)i*Frequency);
            t.gameObject.SetActive(coef < 0.0f);
            i++;
        }
    }
}
