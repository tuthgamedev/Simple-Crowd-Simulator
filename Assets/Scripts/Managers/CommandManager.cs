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

        int columns = Mathf.CeilToInt(Mathf.Sqrt(npcCount));
        int rows = Mathf.CeilToInt((float)npcCount / columns);

        float formationWidth = (columns - 1) * _formationSpacing;
        float formationHeight = (rows - 1) * _formationSpacing;

        Debug.Log($"NPC : {npcCount}");

        Debug.Log($"Columns : {columns}");
        Debug.Log($"Move Command -> {_selectionManager.SelectedNPCs.Count} NPC");

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

        Vector3 right = Vector3.Cross(Vector3.up, forward);

        Vector3 formationOffset =
            right * (formationWidth * 0.5f) +
            forward * (-formationHeight * 0.5f);

        Debug.Log($"Forward : {forward}");
        Debug.Log($"Right : {right}");

        List<Vector3> slots = new List<Vector3>();

        for (int i = 0; i < npcCount; i++)
        {
            int row = i / columns;
            int column = i % columns;

            Vector3 offset =
                right * (column * _formationSpacing)
                +
                forward * (-row * _formationSpacing);

            offset -= formationOffset;

            slots.Add(destination + offset);
        }

        foreach (NPCSelection npc in selected)
        {
            float bestDistance = Mathf.Infinity;
            int bestIndex = 0;

            for (int i = 0; i < slots.Count; i++)
            {
                float distance = Vector3.SqrMagnitude(npc.transform.position - slots[i]);
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestIndex = i;
                }
            }

            Vector3 target = slots[bestIndex];
            slots.RemoveAt(bestIndex);
            NPCMovement movement = npc.GetComponent<NPCMovement>();

            if(movement != null)
                movement.MoveTo(target);

            if (showDebug)
            {
                Debug.Log($"{npc.name} -> {target}");
            } 
        }
   }
}
