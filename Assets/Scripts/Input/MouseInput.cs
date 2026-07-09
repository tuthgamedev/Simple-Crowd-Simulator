using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private CommandManager _commandManager;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private SelectionInput _selectionInput;
    private bool _leftMouseStartedOnUI;
    private bool CanProcessGameplayInput()
    {
        if (InputManager.Instance == null)
        {
            Debug.LogError("InputManager belum ada di Scene.");
            return false;
        }

        return !InputManager.Instance.IsPointerOverUI();
    }

    private void Update()
    {
        Debug.Log("Mouse Update");
        //Begin Drag (Hold Left Click)
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left");
            _leftMouseStartedOnUI = !CanProcessGameplayInput();

            if (!_leftMouseStartedOnUI)
            {
                Debug.Log("Begin Drag");
                _selectionInput.BeginDrag();
            }
        }

        if (_leftMouseStartedOnUI)
        {
            if (Input.GetMouseButtonUp(0))
            {
                _leftMouseStartedOnUI = false;
            }

            return;
        }

        //update drag
        if (_selectionInput != null && _selectionInput.IsDragging && Input.GetMouseButton(0))
        {
            _selectionInput.UpdateDrag();
        }

        //End Drag (Realese Hold Left Click)
        if (_selectionInput != null && _selectionInput.IsDragging && Input.GetMouseButtonUp(0))
        {
            Debug.Log("End Drag");  
            _selectionInput.EndDrag();
        }
 
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right");
            if (CanProcessGameplayInput())
            {
                HandleRightClick();
            }
        }
    }

    private void HandleRightClick()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundLayer))
            return;

        _commandManager.MoveSelectedNPCs(hit.point);
    }
}
