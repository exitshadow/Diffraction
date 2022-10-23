using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AccessStatus { Recovered, Corrupted, Accessible }
public enum DataType { Sector, DigitalObject, Picture, TextLog }

public class DataBlock : ScriptableObject
{
    [SerializeField] protected string _dataName;
    [SerializeField] private DataType _dataType;
    [SerializeField] protected float _corruptionLevel;
    [SerializeField] private AccessStatus _status = AccessStatus.Accessible;

    public string DataName { get { return _dataName; } }
    public DataType Type { get { return _dataType; } }
    public float CorruptionLevel { get { return _corruptionLevel; } }
    public AccessStatus Status { get { return _status; } }

}
