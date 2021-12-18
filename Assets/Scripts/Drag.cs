using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler
{
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;

        if(rectTransform.anchoredPosition.y < 0)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 0);
        }
        else if (rectTransform.anchoredPosition.y > 332.71f)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 332.71f);
        }

        if (rectTransform.anchoredPosition.x < 0)
        {
            rectTransform.anchoredPosition = new Vector2(0, rectTransform.anchoredPosition.y);
        }
        else if (rectTransform.anchoredPosition.x > 298.43f)
        {
            rectTransform.anchoredPosition = new Vector2(298.43f, rectTransform.anchoredPosition.y);
        }
    }
}
