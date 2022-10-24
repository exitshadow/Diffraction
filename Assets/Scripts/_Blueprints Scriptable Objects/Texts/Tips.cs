using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    [TextArea] [SerializeField] private List<string> _tipsList = new List<string>();

    public List<string> Content { get { return _tipsList; } }
}
