using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DigitalObject : Evidence
{
    [SerializeField] private GameObject _meshStructure;

    public GameObject MeshStructure { get { return _meshStructure; } set { _meshStructure = value; } }
}
