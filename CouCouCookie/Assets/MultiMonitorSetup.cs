using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiMonitorSetup : MonoBehaviour
{
    public float Scale;
    public Vector2 Offset;
    public bool NeedsMapping;

    private Material _material;
    private void Start()
    {
        _material = this.gameObject.GetComponent<MeshRenderer>().material;
    }
    void Update()
    {
        _material.SetVector("_ScreenOffset", Offset);
        _material.SetFloat("_ScreenScale", Scale);
        _material.SetFloat("_NeedsMapping", NeedsMapping ? 1.0f : 0.0f);
    }
}
