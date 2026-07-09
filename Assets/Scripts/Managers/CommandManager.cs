using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private List<NPCSelection> _lastCommandGroup = new List<NPCSelection>();
    private Vector3 _lastDestination;
    private bool _hasDestination = false;

    [Header("Formation")]
    [SerializeField] private FormationType _currentFormation = FormationType.Rectangle;
    [SerializeField] private float _formationSpacing = 2f;

    [Header("Reference")]
    [SerializeField] private SelectionManager _selectionManager;
    [SerializeField] private bool showDebug = false;
    [SerializeField] private FormationPannelUI formationPanelUI;

   public void MoveSelectedNPCs(Vector3 destination)
   {
        _lastDestination = destination;
        _hasDestination = true;

        List<NPCSelection> selected = new List<NPCSelection>(_selectionManager.SelectedNPCs);
        _lastCommandGroup = new List<NPCSelection>(selected);
        
        MoveGroup(selected, destination);
    }

    public void SetFormation(FormationType formation)
    {
        if (_selectionManager == null || !_selectionManager.HasSelection)
            return;
        _currentFormation =formation;
        Debug.Log($"Formation Changed : {formation}");

        if (!_hasDestination)
            return;
        List<NPCSelection> selected = new List<NPCSelection>(_selectionManager.SelectedNPCs);
        selected.RemoveAll(npc => npc == null);

        if (selected.Count == 0)
            return;

        
        if (_lastCommandGroup.Count == 0)
            return;

        Vector3 center = CalculateGroupCenter(selected);
        MoveGroup(selected, _lastDestination);
    }

    private void ReformLastGroup()
    {
        List<NPCSelection> selected = new List<NPCSelection>(_lastCommandGroup);
        selected.RemoveAll(npc => npc == null);

        if (selected.Count == 0)
            return;

        Vector3 center = CalculateGroupCenter(selected);
        MoveGroup(selected, _lastDestination);
    }

    private void MoveGroup(List<NPCSelection> selected, Vector3 destination)
    {
        int npcCount = selected.Count;

        if (npcCount == 0)
        {
            Debug.Log("Tidak ada NPC yang dipilih.");
            return;
        }

        Debug.Log($"Move Command -> {npcCount} NPC");

        Vector3 center = Vector3.zero;

        foreach (NPCSelection npc in selected)
        {
            center += npc.transform.position;
        }

        center /= npcCount;

        Vector3 forward = destination - center;
        forward.y = 0f;

        if (forward.sqrMagnitude < 0.01f)
        {
            forward = Vector3.forward;
        }
        else
        {
            forward.Normalize();
        }

        int slotCount = 
            FormationUtility.GetIdealSlotCount(
                _currentFormation,
                npcCount
            );

        formationPanelUI.UpdatePanel(
            _currentFormation,
            npcCount,
            slotCount
        );
        
        Debug.Log($"NPC : {npcCount}");
        Debug.Log($"Ideal Slot : {slotCount}");
        
        List<FormationSlot> slots = 
        FormationGenerator.GenerateFormation(
            _currentFormation,
            destination,
            forward,
            slotCount,
            _formationSpacing
        );

        FormationVisualizer.Instance.SetSlots(slots);

        List<(NPCSelection npc, FormationSlot slot)> assignments =
        FormationAssigner.AssignRelative(
            selected, 
            slots,
            center,
            forward
        );

        foreach (var assignment in assignments)
        {
            NPCMovement movement = assignment.npc.GetComponent<NPCMovement>();
            
            if (movement == null)
            continue;
            
            assignment.slot.Reserve(movement);
            movement.SetTargetSlot(assignment.slot);
            movement.MoveTo(assignment.slot.Position);

            if (showDebug)
            {
                Debug.Log($"{assignment.npc.name} -> {assignment.slot.Position}");
            }
        }
        
        StartCoroutine(WaitUntilFormationComplete(selected));
   }

   private IEnumerator WaitUntilFormationComplete(List<NPCSelection> selected)
    {
        bool completed = false;

        while(!completed)
        {    
            completed = true;

            foreach (var npc in selected)
            {
                NPCMovement movement =npc.GetComponent<NPCMovement>();

                if (movement.CurrentState != NPCState.Idle)
                {
                    completed = false;
                    break;
                }
            }

            yield return null;
        }
        FormationVisualizer.Instance.HideMarkers();
    }

    private Vector3 CalculateGroupCenter(List<NPCSelection> group)
    {
        Vector3 center = Vector3.zero;

        foreach(NPCSelection npc in group)
        {
            center += npc.transform.position;
        }
        return center / group.Count;
    }
}
