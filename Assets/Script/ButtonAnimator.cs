using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Button))]
public class ButtonAnimator : MonoBehaviour
{
    private void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(Animate);
    }

    private void Animate()
    {
        transform.DOKill(true);
        transform.DOShakeScale(0.2f, 0.2f);
    }
}
