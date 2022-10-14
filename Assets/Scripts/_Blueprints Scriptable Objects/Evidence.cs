using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : DataBlock
{
    [SerializeField] protected Sector _sectorOfOrigin;
    [SerializeField] protected List<Evidence> _linkedEvidence;

    public Sector SectorOfOrigin { get { return _sectorOfOrigin; } }
    public List<Evidence> LinkedEvidence { get { return _linkedEvidence; } }
}
