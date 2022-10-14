using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Diffraction Assets/Evidence/Text Log")]
public sealed class TextLog : Evidence
{
    [TextArea]
    [SerializeField] private string _logContent;
    
}
