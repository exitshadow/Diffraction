using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorGenerator : MonoBehaviour
{
    [SerializeField] private Mesh _textLogMesh;
    [SerializeField] private Mesh _pictureMesh;
    [SerializeField] private Material _textLogMat;
    [SerializeField] private Material _pictureMat;
    
    [SerializeField] private List<Evidence> _evidenceList = new List<Evidence>();
    [SerializeField] private Sector _currentSector;

    private float _remainingTime;
    public float RemainingTime { get { return _remainingTime; } }

    private void Awake()
    {
        for (int i = 0; i < _evidenceList.Count; i++)
        {
            _evidenceList[i].SectorOfOrigin = _currentSector;

            GameObject evidenceObject = CreateEvidenceObject(_evidenceList[i].name);

            EvidenceComponent evidenceComponent = evidenceObject.GetComponent<EvidenceComponent>();

            evidenceComponent.Initialize(   _evidenceList[i],
                                            _textLogMesh,
                                            _pictureMesh,
                                            _textLogMat,
                                            _pictureMat     );

            float x = Random.Range(-10, 10);
            float z = Random.Range(-10, 10);
            evidenceObject.transform.position = new Vector3(x, 0, z);

            Vector3 rot = evidenceObject.transform.eulerAngles;
            rot.y = Random.Range(0,360.0f);
            evidenceObject.transform.eulerAngles = rot;
        }

        _remainingTime = Random.Range(10 * 60, 20 * 60);
    }

    private void Update()
    {
        if (_remainingTime > 0) _remainingTime -= Time.fixedDeltaTime;
        else print("time is over");
    }

    private GameObject CreateEvidenceObject(string name)
    {
        GameObject evidenceObject = new GameObject();
            evidenceObject.name = name;
            evidenceObject.AddComponent<MeshRenderer>();
            evidenceObject.AddComponent<MeshFilter>();
            evidenceObject.AddComponent<BoxCollider>();
            evidenceObject.AddComponent<EvidenceComponent>();
        
        return evidenceObject;
    }

}
