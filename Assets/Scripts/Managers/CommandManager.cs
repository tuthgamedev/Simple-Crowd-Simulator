using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    [Header("Formation")]
    [SerializeField] private float _formationSpacing = 2f;
    [Header("Reference")]
    [SerializeField] private SelectionManager _selectionManager;
    [SerializeField] private bool showDebug = false;

   public void MoveSelectedNPCs(Vector3 destination)
   {    
        List<NPCSelection> selected = new List<NPCSelection>(_selectionManager.SelectedNPCs);
        
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
        
        List<FormationSlot> slots = 
        FormationGenerator.GenerateRectangle(
            destination,
            forward,
            npcCount,
            _formationSpacing
        );

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
   }
}
