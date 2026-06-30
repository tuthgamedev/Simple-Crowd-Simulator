using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private SelectionManager _selectionManager;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleLeftClick();
        }
    }

    private void HandleLeftClick()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            NPCSelection npc = hit.collider.GetComponent<NPCSelection>();
            if (npc != null)
            {
                _selectionManager.Select(npc);
                return;
            }
        }
            _selectionManager.ClearSelection();
    }
}
