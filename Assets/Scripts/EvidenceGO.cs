using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Collider))]
public class EvidenceGO : MonoBehaviour
{
    private MeshFilter _meshFilter;
    private Renderer _renderer;

    public Mesh TextLogMesh;
    public Mesh PictureMesh;
    public Material TextLogMat;
    public Material PictureMat;

    [SerializeField] private Evidence _evidenceData;
    public Evidence EvidenceData { get { return _evidenceData; } set {_evidenceData = value; } }

    // todo
    //  refactor code so there is a big MeshSet or a similar function
    //  so the SectorGeneration script doesn’t have to attribute
    //  meshes and stuff with a very long list of instructions

    // not sure i need this actually
    public EvidenceGO(Evidence passedEvidence, Sector sectorOfOrigin)
    {
        print("EvidenceGO constructor method is called");
        _evidenceData = passedEvidence;
        _evidenceData.SectorOfOrigin = sectorOfOrigin;
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
            _meshFilter.sharedMesh = PictureMesh;
            _renderer.sharedMaterial = PictureMat;
        }
        else if (dataCastTL != null)
        {
            print($"{_evidenceData.name} is of type TextLog");
            _meshFilter.sharedMesh = TextLogMesh;
            _renderer.sharedMaterial = TextLogMat;

        }


    }
}
