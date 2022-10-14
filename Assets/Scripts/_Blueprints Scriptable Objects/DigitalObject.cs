using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Diffraction Assets/Evidence/Digital Object")]
public sealed class DigitalObject : Evidence
{
    [SerializeField] private Mesh _meshStructure;
    [SerializeField] private Material _objectMat;

    public Mesh MeshStructure { get { return _meshStructure; } }
    public Material ObjectMat { get { return _objectMat; } }
}
