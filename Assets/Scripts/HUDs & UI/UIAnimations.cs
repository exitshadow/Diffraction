using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimations : MonoBehaviour
{
    [SerializeField] private GameObject topContainer, bottomContainer, examinationBox;
    [SerializeField] private float time = 4f;
    [SerializeField] private float delay = 2f;

    public void UnfoldToRight(GameObject animContainer, bool hasDelay)
    {
        float width = animContainer.GetComponent<RectTransform>().rect.width;
        animContainer.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);

        animContainer.SetActive(true);
        
        if (!hasDelay) delay = 0;

        LeanTween.value(animContainer, 0, width, time)
            .setOnUpdate((value) => {
                animContainer.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value);
            })
            .delay = time + delay;
    }

    private void Start()
    {
        topContainer.SetActive(false);
        bottomContainer.SetActive(false);
        examinationBox.SetActive(false);

        UnfoldToRight(topContainer, false);
        UnfoldToRight(bottomContainer, true);
    }
}
