using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(menuName = "Diffraction Assets/Sector")]
public sealed class Sector : DataBlock
{
    [SerializeField] private List<Evidence> _evidenceInSector;
    [SerializeField] private float _remainingTime;

    public List<Evidence> EvidenceInSector
    {
        get { return _evidenceInSector; }
        set { _evidenceInSector = value; }
    }

    public float RemainingTime { get { return _remainingTime; } }

}
