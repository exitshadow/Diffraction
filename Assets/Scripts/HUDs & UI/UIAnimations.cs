using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimations : MonoBehaviour
{
    [SerializeField] private GameObject topContainer, bottomContainer, examinationBox;
    [SerializeField] private float time = 4f;
    [SerializeField] private float delay = 2f;

    public void UnfoldToRight(GameObject gameO, bool hasDelay)
    {
        float width = gameO.GetComponent<RectTransform>().rect.width;
        gameO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);

        gameO.SetActive(true);
        
        if (!hasDelay) delay = 0;

        LeanTween.value(gameO, 0, width, time)
            .setEaseOutExpo()
            .setOnUpdate((value) => {
                gameO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value);
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
