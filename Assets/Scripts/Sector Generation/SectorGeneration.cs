using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorGeneration : MonoBehaviour
{
    [SerializeField] private Mesh _textLogMesh;
    [SerializeField] private Mesh _pictureMesh;
    [SerializeField] private Material _textLogMat;
    [SerializeField] private Material _pictureMat;
    
    [SerializeField] private List<Evidence> _evidenceList = new List<Evidence>();
    [SerializeField] private Sector _currentSector;

    private void Awake()
    {
        for (int i = 0; i < _evidenceList.Count; i++)
        {
            _evidenceList[i].SectorOfOrigin = _currentSector;
            
            GameObject evidenceObject = new GameObject();
            evidenceObject.name = "New Evidence Object";
            evidenceObject.AddComponent<MeshRenderer>();
            evidenceObject.AddComponent<MeshFilter>();
            evidenceObject.AddComponent<BoxCollider>();
            evidenceObject.AddComponent<EvidenceGO>();

            EvidenceGO evidenceGO = evidenceObject.GetComponent<EvidenceGO>();
            evidenceGO.TextLogMesh = _textLogMesh;
            evidenceGO.TextLogMat = _textLogMat;
            evidenceGO.PictureMesh = _pictureMesh;
            evidenceGO.PictureMat = _pictureMat;
            evidenceGO.EvidenceData = _evidenceList[i];

            evidenceObject.transform.position = new Vector3(2 * i,0, 2 *i);
        }

    }   
}
