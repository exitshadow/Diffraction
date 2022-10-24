using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Diffraction Assets/Email")]
public class Email : ScriptableObject
{
    [SerializeField] private DateTime _date; // to be reworked
    [SerializeField] private string _expeditor;
    [SerializeField] private string _title;
    [TextArea(15,20)] [SerializeField] private string _content;

    [HideInInspector] public bool hasBeenRead;

    public DateTime Date { get {return _date; } }
    public string Expeditior { get { return _expeditor; } }
    public string Title { get { return _title; } }
    public string Content { get { return _content; } }
}
