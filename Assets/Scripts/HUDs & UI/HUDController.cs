using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    private const float K = 3600f;

    [SerializeField] private RectTransform tiltIndicator;
    [SerializeField] private RectTransform horizonIndicator;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private int horizonIndicatorBounds;

    private Ray ray = new Ray();
    private Transform pos2Ground;

    private void Start()
    {
        pos2Ground = new GameObject().transform;
    }
    
    private void Update()
    {
        int heightTilt = (int)playerCamera.transform.localRotation.eulerAngles.x;
        if (heightTilt > 180) heightTilt = heightTilt - 360;

        tiltIndicator.anchoredPosition = new Vector2(tiltIndicator.anchoredPosition.x, heightTilt * 2);
        horizonIndicator.anchoredPosition = new Vector2(horizonIndicator.anchoredPosition.x, HorizonToScreenHeight());
    }

    private int HorizonToScreenHeight()
    {
        Vector3 horizonFrontPos;
        float horizonDist;
        int horizonDiff;

        // get horizon distance from height
        // https://sites.math.washington.edu/~conroy/m120-general/horizon.pdf
        horizonDist = K * Mathf.Sqrt(playerCamera.transform.position.y);

        // project view position to the ground
        pos2Ground.position.Set( playerCamera.transform.position.x,
                                 0,
                                 playerCamera.transform.position.z);

        // project horizon distance from the grounded position
        ray.origin = pos2Ground.position;
        ray.direction = pos2Ground.transform.forward;
        // Debug.DrawRay(pos2Ground.position, pos2Ground.transform.forward, Color.red);
        horizonFrontPos = ray.GetPoint(horizonDist);


        // transfer projected point coordinates onto screen coordinates
        Vector3 w2s = playerCamera.WorldToScreenPoint(horizonFrontPos);

        // remap coordinates to center and constrain to screen
        if (w2s.y > playerCamera.pixelHeight - horizonIndicatorBounds)
            horizonDiff = (int)(playerCamera.pixelHeight - horizonIndicatorBounds);
        else if (w2s.y < horizonIndicatorBounds)
            horizonDiff = horizonIndicatorBounds;
        else
            horizonDiff = (int)w2s.y;
        
        return horizonDiff;
    }

    private float GetAngleFromVecs(Vector3 a, Vector3 b)
    {
        // get magnitudes
        float magA = Mathf.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z);
        float magB = Mathf.Sqrt(b.x * b.x + b.y * b.y + b.z * b.z);

        // normalize vectors
        a /= magA;
        b /= magB;

        // dot product + retrieve angle
        float angle = Mathf.Acos(a.x * b.x + a.y * b.y + a.z * b.z);

        return angle;
    }
}
