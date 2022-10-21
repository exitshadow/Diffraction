using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimations : MonoBehaviour
{
    [SerializeField] private GameObject topContainer, bottomContainer, examinationBox;
    [SerializeField] private float time = 4f;

    public void UnfoldToRight(GameObject gameO)
    {
        gameO.SetActive(true);
        LeanTween.value(gameO, 0, gameO.GetComponent<RectTransform>().rect.width, time)
            .setEaseOutExpo()
            .setOnUpdate((value) => {
                gameO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value);
            });
    }

    private void Start()
    {
        topContainer.SetActive(false);
        bottomContainer.SetActive(false);
        examinationBox.SetActive(false);

        UnfoldToRight(topContainer);
        UnfoldToRight(bottomContainer);
    }
}
