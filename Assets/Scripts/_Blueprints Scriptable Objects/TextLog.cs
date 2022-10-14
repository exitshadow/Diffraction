using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TextLog : Evidence
{
    [TextArea]
    [SerializeField] private string _logContent;
    
}
