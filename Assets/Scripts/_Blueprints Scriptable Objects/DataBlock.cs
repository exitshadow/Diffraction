using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBlock : ScriptableObject
{
    [SerializeField] protected string _dataName;
    [SerializeField] protected float _corruptionLevel;
    
    public string DataName { get { return _dataName; } }
    public float CorruptionLevel { get { return _corruptionLevel; } }

}
