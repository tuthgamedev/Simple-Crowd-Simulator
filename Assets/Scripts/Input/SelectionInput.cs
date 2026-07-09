using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionInput : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private SelectionManager _selectionManager;
    [SerializeField] private SelectionBoxUI _selectionBoxUI;
    [SerializeField] private LayerMask _npcLayer;

    [SerializeField] private float _dragThreshold = 10f;

    private bool _isDragging;
    private Vector2 _dragStartPosition;

    public bool IsDragging => _isDragging;

    public void BeginDrag()
    {
        if (_mainCamera == null || _selectionManager == null || _selectionBoxUI == null)
        {
            Debug.LogError("Selection Input belum lengkap di Inspector.");
            return;
        }
        _dragStartPosition = Input.mousePosition;
        _isDragging = true;

        _selectionBoxUI.Show(_dragStartPosition);
    }

    public void UpdateDrag()
    {
        if (!_isDragging)
            return;

        float distance = Vector2.Distance(_dragStartPosition, Input.mousePosition);

        if (distance < _dragThreshold)
            return;

        _selectionBoxUI.UpdateBox(_dragStartPosition, Input.mousePosition);
    }

    public void EndDrag()
    {
        if (!_isDragging)
            return;

        _isDragging = false;

        float distance = Vector2.Distance(_dragStartPosition, Input.mousePosition);

        if (distance < _dragThreshold)
        {
            SingleSelection();
            _selectionBoxUI.Hide();
            return;
        }

        BoxSelection();
        _selectionBoxUI.Hide();
    }

    private void SingleSelection()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _npcLayer))
        {
            NPCSelection npc = hit.collider.GetComponentInParent<NPCSelection>();

            if (npc != null)
            {
                _selectionManager.SelectSingle(npc);
                return;
            }
        }      

            _selectionManager.ClearSelection();
    }

    private void BoxSelection()
    {
        Vector2 end = Input.mousePosition;

        Rect rect = new Rect(
            Mathf.Min(_dragStartPosition.x, end.x),
            Mathf.Min(_dragStartPosition.y, end.y),
            Mathf.Abs(_dragStartPosition.x - end.x),
            Mathf.Abs(_dragStartPosition.y - end.y));

        _selectionManager.SelectInRectangle(rect);
    }
}