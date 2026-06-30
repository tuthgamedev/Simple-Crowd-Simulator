using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private SelectionManager _selectionManager;
    [SerializeField] private SelectionBoxUI _selectionBoxUI;

    private Vector2 _dragStartPosition;
    private bool _isDragging;

    [SerializeField] private float _dragThreshold = 10f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrag();
        }

        if (Input.GetMouseButton(0))
        {
            UpdateDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

    private void StartDrag()
    {
        _dragStartPosition = Input.mousePosition;
        _isDragging = true;

        _selectionBoxUI.Show(_dragStartPosition);
    }

    private void UpdateDrag()
    {
        if (!_isDragging)
            return;

        float distance = Vector2.Distance(_dragStartPosition, Input.mousePosition);

        if (distance < _dragThreshold)
            return;

        _selectionBoxUI.UpdateBox(
            _dragStartPosition,
            Input.mousePosition);
    }
    
    private void EndDrag()
    {
        if (!_isDragging)
            return;

        _isDragging = false;

        float distance = Vector2.Distance(_dragStartPosition, Input.mousePosition);

        //=== SINGLE CLICK ===
        if (distance <_dragThreshold)
        {
            HandleLeftClick();
            _selectionBoxUI.Hide();
            return;
        }

        //=== BOX SELECTION ===

        Vector2 start = _dragStartPosition;
        Vector2 end = Input.mousePosition;

        float minX = Mathf.Min(start.x, end.x);
        float minY = Mathf.Min(start.y, end.y);

        float width = Mathf.Abs(start.x - end.x);
        float height = Mathf.Abs(start.y - end.y);

        Rect selectionRect = new Rect(minX, minY, width, height);

        _selectionManager.SelectInRectangle(selectionRect);

        _selectionBoxUI.Hide();
    }

    private void HandleLeftClick()
    {
        if (_mainCamera == null || _selectionManager == null)
        {
            Debug.LogError("MouseInput : Camera atau SelectionManager belum diisi.");
            return;
        }

        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            NPCSelection npc = hit.collider.GetComponent<NPCSelection>();

            if (npc != null)
            {
                _selectionManager.SelectSingle(npc);
                return;
            }
        }

        _selectionManager.ClearSelection();
    }
}
