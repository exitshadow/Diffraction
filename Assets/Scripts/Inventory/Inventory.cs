using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Evidence> _evidenceList = new List<Evidence>();
    [SerializeField] private List<Sector> _sectorList = new List<Sector>();

    public List<Sector> SectorItems { get { return _sectorList; } }
    public List<Evidence> EvidenceItems { get { return _evidenceList; } }
}
