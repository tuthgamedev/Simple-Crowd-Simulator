using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private readonly List<NPCSelection> _selectedNPCs = new();

    public IReadOnlyList<NPCSelection> SelectedNPCs => _selectedNPCs;

    public bool HasSelection => _selectedNPCs.Count > 0;

    public void SelectSingle(NPCSelection npc)
    {
        if (npc == null)
            return;
        ClearSelection();
        AddToSelection(npc);
    }

    public void AddToSelection(NPCSelection npc)
    {
        if (npc == null)
            return;

        if (_selectedNPCs.Contains(npc))
            return;

        npc.Select();
        _selectedNPCs.Add(npc);
    }

    public void RemoveFromSelection(NPCSelection npc)
    {
        if (npc == null)
            return;

        if (!_selectedNPCs.Remove(npc))
            return;

        npc.Deselect();
    }

    public void ClearSelection()
    {
        foreach (NPCSelection npc in _selectedNPCs)
        {
            npc.Deselect();
        }

        _selectedNPCs.Clear();
    }

    public void SelectInRectangle(Rect selectionRect)
    {
        ClearSelection();

        NPCSelection[] allNPCs = FindObjectsOfType<NPCSelection>();

        foreach (NPCSelection npc in allNPCs)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(npc.transform.position);

            if (selectionRect.Contains(screenPosition))
            {
                AddToSelection(npc);
            }
        }
    }
}
