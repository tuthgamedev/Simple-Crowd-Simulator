using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionBoxUI : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private RectTransform _selectionBox;

    private RectTransform _canvasRect;

    private void Awake()
    {
        _canvasRect = _canvas.GetComponent<RectTransform>();
        Hide();
    }

    public void Show(Vector2 mousePosition)
    {
        _selectionBox.gameObject.SetActive(true);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvasRect,
            mousePosition,
            null,
            out Vector2 localPoint);

        _selectionBox.anchoredPosition = localPoint;
        _selectionBox.sizeDelta = Vector2.zero;
    }

    public void UpdateBox(Vector2 startMouse, Vector2 currentMouse)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvasRect,
            startMouse,
            null,
            out Vector2 start);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvasRect,
            currentMouse,
            null,
            out Vector2 current);

        Vector2 min = Vector2.Min(start, current);
        Vector2 max = Vector2.Max(start, current);

        _selectionBox.anchoredPosition = (min + max) * 0.5f;
        _selectionBox.sizeDelta = max - min;
    }

    public void Hide()
    {
        _selectionBox.gameObject.SetActive(false);
    }
}
