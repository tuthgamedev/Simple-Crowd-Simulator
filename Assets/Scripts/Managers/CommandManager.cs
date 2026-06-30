using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    [SerializeField] private float _formationSpacing = 2f;
    [SerializeField] public CommandManager _commandManager;
    [SerializeField] private SelectionManager _selectionManager;

   public void MoveSelectedNPCs(Vector3 destination)
   {
    int npcCount = _selectionManager.SelectedNPCs.Count;

    int columns = Mathf.CeilToInt(Mathf.Sqrt(npcCount));
    int rows = Mathf.CeilToInt((float)npcCount / columns);

    float formationWidth = (columns - 1) * _formationSpacing;
    float formationHeight = (rows - 1) * _formationSpacing;

    Vector3 formationOffset = new Vector3(
        formationWidth / 2f,
        0f,
        formationHeight / 2f
    );

    Debug.Log($"NPC : {npcCount}");

    Debug.Log($"Columns : {columns}");

      if (_selectionManager.SelectedNPCs.Count == 0)
        {
            Debug.Log("Tidak ada NPC yang dipilih.");
            return;
        }

        Debug.Log($"Move Command -> {_selectionManager.SelectedNPCs.Count} NPC");

        int index = 0;

        NPCSelection leader = _selectionManager.SelectedNPCs[0];

        Vector3 direction =
            destination - leader.transform.position;
        
        direction.y = 0f;
        direction.Normalize();
        Debug.Log(direction);

        foreach (NPCSelection npc in _selectionManager.SelectedNPCs)
        {
            int row = index / columns;
            int column = index % columns;
            Vector3 offset = new Vector3(
                column * _formationSpacing,
                0f,
                -row * _formationSpacing
            );

            Vector3 targetPosition =
                destination +
                offset -
                formationOffset;

            Debug.Log($"Offset : {offset}");

            Debug.Log($"NPC {index} -> Row {row} Column {column}");

            NPCMovement movement = npc.GetComponent<NPCMovement>();

            if (movement != null)
            {
                movement.MoveTo(targetPosition);
                Debug.Log($"Target Position : {targetPosition}");
            }

            index++;
        }
   }
}
