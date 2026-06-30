using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private NPCSelection _currentSelectedNPC;
    public NPCSelection CurrentSelectedNPC => _currentSelectedNPC;
    public void Select(NPCSelection npc)
    {
        if (_currentSelectedNPC == npc)
            return;

        ClearSelection();

        _currentSelectedNPC = npc;

        _currentSelectedNPC.Select();
    }

    public void ClearSelection()
    {
        if (_currentSelectedNPC == null)
        return;
            _currentSelectedNPC.Deselect();
            _currentSelectedNPC = null;
    }
}
