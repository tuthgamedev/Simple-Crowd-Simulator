using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationVisualizer : MonoBehaviour
{
    public static FormationVisualizer Instance { get; private set; }
    [SerializeField] private float _slotRadius = 20f;
    [SerializeField] private GameObject _markerPrefab;
    private readonly List<GameObject> _markers = new List<GameObject>();
    private List<FormationSlot> _slots = new List<FormationSlot>();
    public IReadOnlyList<FormationSlot> Slots => _slots;

    private void Awake()
    {
        Debug.Log("FormationVisualizer Awake");

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSlots(List<FormationSlot> slots)
    {
        Debug.Log("SetSlots Dipanggil");
        Debug.Log(slots.Count);

        foreach (GameObject marker in _markers)
        {
            if (marker != null)
            {
                Destroy(marker);
            }
        }
        _markers.Clear();

        _slots = slots;
        foreach (FormationSlot slot in _slots)
        {
            GameObject marker = Instantiate(
                _markerPrefab, 
                slot.Position + Vector3.up * 0.5f, 
                _markerPrefab.transform.rotation, 
                transform
                );

            FormationMarker markerComponent = marker.GetComponent<FormationMarker>();
            if (markerComponent != null)
                {
                    markerComponent.Initialize(slot);
                }

            _markers.Add(marker);
        }
    }

    private void OnDrawGizmos()
    {
        if (_slots == null)
            return;

        foreach (FormationSlot slot in _slots)
        {
            switch (slot.State)
            {
                case FormationSlotState.Free:
                    Gizmos.color = Color.green;
                    break;
                
                case FormationSlotState.Reserved:
                    Gizmos.color = Color.yellow;
                    break;
                
                case FormationSlotState.Occupied:
                    Gizmos.color = Color.red;
                    break;
            }

            Debug.DrawLine(
                slot.Position, 
                slot.Position + Vector3.up * 5f, 
                Gizmos.color
                );

            Gizmos.DrawSphere(slot.Position +Vector3.up * 0.3f, _slotRadius);
        }
    }
}
