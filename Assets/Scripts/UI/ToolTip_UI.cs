using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ToolTip_UI : MonoBehaviour
{
    private RectTransform _backgroundRectTransform;
    private RectTransform _rectTransform;
    [SerializeField] RectTransform _canvas;
    Vector2 anchoredPosition;

    private void Start()
    {
        _backgroundRectTransform = transform.Find("Background").GetComponent<RectTransform>();
        _rectTransform = transform.GetComponent<RectTransform>();
    }

    public void SetText(TextMeshProUGUI text, int value)
    {
        text.SetText(value.ToString());
        text.ForceMeshUpdate();
    }

    public void SetText(TextMeshProUGUI text, string value)
    {
        text.SetText(value);
        text.ForceMeshUpdate();
    }

    public void SetColor(TextMeshProUGUI text, Color color)
    {
        text.color = color;
    }

    private void Update()
    {
        anchoredPosition = Input.mousePosition / _canvas.localScale.x;
        if (anchoredPosition.x + _backgroundRectTransform.rect.width > _canvas.rect.width)
        {
            anchoredPosition.x = _canvas.rect.width - _backgroundRectTransform.rect.width;
        }
        if (anchoredPosition.y + _backgroundRectTransform.rect.height > _canvas.rect.height)
        {
            anchoredPosition.y = _canvas.rect.height - _backgroundRectTransform.rect.height;
        }
        if (anchoredPosition.x  < 0.0f)
        {
            anchoredPosition.x = 0.0f;
        }
        if (anchoredPosition.y < 0.0f)
        {
            anchoredPosition.y = 0.0f;
        }
        _rectTransform.anchoredPosition = anchoredPosition;
    }

    public void ShowToolTip()
    {
        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }
}
