using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class DataMoshEffect : MonoBehaviour
{
    [SerializeField] private Material DataMoshMat;

    private void Start()
    {
        // set depth textures to generate motion vectors
        this.GetComponent<Camera>().depthTextureMode = DepthTextureMode.MotionVectors;
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, DataMoshMat);
    }
}
