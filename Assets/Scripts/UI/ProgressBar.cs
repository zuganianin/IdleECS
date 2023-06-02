using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour, IProgress
{
    [SerializeField]
    private RectTransform _rectTransform;

    private float _maxWidth;

    private void Start()
    {
        _maxWidth = this.GetComponent<RectTransform>().sizeDelta.x;
        SetProgress(0.33f);
    }

    public void SetProgress(float progress)
    {
        _rectTransform.sizeDelta = new Vector2(_maxWidth * progress, _rectTransform.sizeDelta.y);
    }
}
