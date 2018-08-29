using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class Window : MonoBehaviour
{
    [SerializeField]
    private bool isActiveByDefault = false;

    [SerializeField]
    private float hideDelay = 0.0f;

    [SerializeField]
    private float showDeay = 0.0f;

    private bool isActive = false;

    private CanvasGroup group;
    private CanvasGroup Group
    {
        get
        {
            if (group == null)
                group = GetComponent<CanvasGroup>();

            return group;
        }
    }

    private void Start()
    {
        if (!isActiveByDefault)
        {
            Group.alpha = 0.0f;
            Group.blocksRaycasts = false;
        }

        isActive = isActiveByDefault;
    }

    public void Show()
    {
        if (isActive)
            return;

        Group.DOKill(true);
        Group.blocksRaycasts = true;
        Group.DOFade(1.0f, 0.5f).SetUpdate(true).SetDelay(showDeay);

        isActive = true;
    }

    public void Hide()
    {
        if (!isActive)
            return;

        Group.DOKill(true);
        Group.blocksRaycasts = false;
        Group.DOFade(0, 0.5f).SetUpdate(true).SetDelay(hideDelay);

        isActive = false;
    }
}
