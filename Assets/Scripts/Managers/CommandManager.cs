using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    [SerializeField] public CommandManager _commandManager;
   [SerializeField] private SelectionManager _selectionManager;

   public void MoveSelectedNPCs(Vector3 destination)
   {
      if (_selectionManager.SelectedNPCs.Count == 0)
        {
            Debug.Log("Tidak ada NPC yang dipilih.");
            return;
        }

        Debug.Log($"Move Command -> {_selectionManager.SelectedNPCs.Count} NPC");

        foreach (NPCSelection npc in _selectionManager.SelectedNPCs)
        {
            NPCMovement movement = npc.GetComponent<NPCMovement>();

            if (movement == null)
                continue;

            movement.MoveTo(destination);
        }
   }
}
