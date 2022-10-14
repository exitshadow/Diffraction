using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Sector : DataBlock
{
    [SerializeField] private List<Evidence> _evidenceInSector;

    public List<Evidence> EvidenceInSector
    {
        get { return _evidenceInSector; }
        set { _evidenceInSector = value; }
    }
}
