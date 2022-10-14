using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Collider))]
public class EvidenceComponent : MonoBehaviour
{
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private Renderer _renderer;

    [SerializeField] private Mesh _textLogMesh;
    [SerializeField] private Mesh _pictureMesh;
    [SerializeField] private Material _textLogMat;
    [SerializeField] private Material _pictureMat;

    [SerializeField] private Evidence _evidenceData;
    public Evidence EvidenceData { get { return _evidenceData; } }

    public void Initialize( Evidence passedEvidence,
                            Mesh textLogMesh,
                            Mesh pictureMesh,
                            Material textLogMat,
                            Material pictureMat     )
    {
        _evidenceData = passedEvidence;
        _textLogMesh = textLogMesh;
        _pictureMesh = pictureMesh;
        _textLogMat = textLogMat;
        _pictureMat = pictureMat;
    } 

    private void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _renderer = GetComponent<Renderer>();

        // if evidence is a digital object, replace the mesh assigned in the prefab
        DigitalObject dataCastDO = _evidenceData as DigitalObject;
        Picture dataCastPic = _evidenceData as Picture;
        TextLog dataCastTL = _evidenceData as TextLog;

        if (dataCastDO != null)
        {
            print($"{_evidenceData.name} is of type DigitalObject");
            _meshFilter.sharedMesh = dataCastDO.MeshStructure;
            _renderer.sharedMaterial = dataCastDO.ObjectMat;
        }
        else if (dataCastPic != null)
        {
            print($"{_evidenceData.name} is of type Picture");
            _meshFilter.sharedMesh = _pictureMesh;
            _renderer.sharedMaterial = _pictureMat;
        }
        else if (dataCastTL != null)
        {
            print($"{_evidenceData.name} is of type TextLog");
            _meshFilter.sharedMesh = _textLogMesh;
            _renderer.sharedMaterial = _textLogMat;

        }
    }
}
