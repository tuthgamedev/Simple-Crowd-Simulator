using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationMarker : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    [SerializeField] private Color _freeColor = Color.green;
    [SerializeField] private Color _reservedColor = Color.yellow;
    [SerializeField] private Color _occupiedColor = Color.red;

    private FormationSlot _slot;

    public void Initialize(FormationSlot slot)
    {
        _slot = slot;
    }

    private void Update()
    {
        if (_slot == null)
            return;

        switch (_slot.State)
        {
            case FormationSlotState.Free:
                _renderer.material.color = _freeColor;
                break;
            
            case FormationSlotState.Reserved:
                _renderer.material.color = _reservedColor;
                break;
            
            case FormationSlotState.Occupied:
                _renderer.material.color = _occupiedColor;
                break;
        }
        transform.position = _slot.Position + Vector3.up * 0.5f;
    }
}