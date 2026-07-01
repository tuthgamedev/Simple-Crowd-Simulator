using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationSlot
{
    public Vector3 Position;
    public NPCMovement Occupant;
    public FormationSlotState State;

    public bool IsOccupied 
    {
        get 
        { 
            return State != FormationSlotState.Occupied;
        }
    }
    public FormationSlot(Vector3 position)
    {
        Position = position;
        Occupant = null;
        State = FormationSlotState.Free;
    }

    public void Reserve(NPCMovement npc)
    {
        Occupant = npc;
        State = FormationSlotState.Reserved;
        Debug.Log("Slot Reserved({Position})");
    }

    public void Occupy()
    {
        State = FormationSlotState.Occupied;
        Debug.Log("Slot Occupied({Position})");
    }

    public void Release()
    {
        Occupant = null;
        State = FormationSlotState.Free;
        Debug.Log($"Slot Released ({Position})");
    }
}
