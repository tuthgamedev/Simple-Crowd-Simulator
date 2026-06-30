using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSelection : MonoBehaviour
{
    [Header("Visual")]
    [SerializeField] private MeshRenderer _meshrenderer;
    [SerializeField] private Material _normalMaterial;
    [SerializeField] private Material _selectedMaterial;
    private bool _isSelected;

    private void Awake()
    {
        if (_meshrenderer == null)
        {
            _meshrenderer = GetComponentInChildren<MeshRenderer>();
        }
        UpdateVisual();
    }

    public void Select()
    {
        _isSelected = true;
        UpdateVisual();
        Debug.Log($"{gameObject.name} has been selected.");
    }

    public void Deselect()
    {
        _isSelected = false;
        UpdateVisual();
        Debug.Log($"{gameObject.name} has been deselected.");
    }

    private void UpdateVisual()
    {
        if (_meshrenderer == null)
            return;
            _meshrenderer.material = _isSelected
            ? _selectedMaterial 
            : _normalMaterial;
        
    }
}
