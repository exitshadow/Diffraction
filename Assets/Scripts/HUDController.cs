using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField] private RectTransform tiltIndicator;
    [SerializeField] private Camera playerCamera;

    private void Update()
    {
        float height = playerCamera.transform.localRotation.eulerAngles.x;
        Debug.Log(height);
        tiltIndicator.anchoredPosition = new Vector2(tiltIndicator.anchoredPosition.x, height);
    }
}
