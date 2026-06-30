using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSelection : MonoBehaviour
{
    [Header("Visual")]
[SerializeField] private MeshRenderer _meshRenderer;
[SerializeField] private Material _normalMaterial;
[SerializeField] private Material _selectedMaterial;

private bool _isSelected;

public bool IsSelected => _isSelected;
public Vector3 Position => transform.position;

    private void Awake()
    {
        if (_meshRenderer == null)
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
        UpdateVisual();
    }

    private void Reset()
    {
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    public void Select()
    {
        if (_isSelected)
            return;
        _isSelected = true;
        UpdateVisual();
        Debug.Log($"{gameObject.name} has been selected.");
    }

    public void Deselect()
    {
        if (!_isSelected)
            return;
        _isSelected = false;
        UpdateVisual();
        Debug.Log($"{gameObject.name} has been deselected.");
    }

    private void UpdateVisual()
    {
        if (_meshRenderer == null)
            return;

        if (_normalMaterial == null || _selectedMaterial == null)
            return;

        _meshRenderer.material =
            _isSelected
            ? _selectedMaterial
            : _normalMaterial;
        
    }
}
