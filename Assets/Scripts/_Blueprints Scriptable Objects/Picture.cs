using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Diffraction Assets/Evidence/Picture")]
public sealed class Picture : Evidence
{
    [SerializeField] private Texture2D _textureData;

    public Texture2D TextureData { get { return _textureData; } }
}
