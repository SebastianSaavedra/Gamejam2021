using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraShader : MonoBehaviour
{
    private Shader outlineShader;
    private List<SnapshotFilter> filters = new List<SnapshotFilter>();

    private void Awake()
    {
        outlineShader = Shader.Find("Snapshot/EdgeDetect");
        filters.Add(new BaseFilter("Outlines", Color.white, outlineShader));
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        filters[0].OnRenderImage(src, dst);
    }
}
