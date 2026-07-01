using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController 
{
    public Vector3 Destination { get; private set; }
    public Vector3 Forward { get; private set; }
    public List<FormationSlot> Slots { get; private set; }
    public FormationController()
    {
        Slots = new List<FormationSlot>();
    }

    public void CreateFormation(Vector3 destination, Vector3 forward, int npcCount, float spacing)
    {
        Destination = destination;
        Forward = forward;
        Slots = FormationGenerator.GenerateRectangle(destination, forward, npcCount, spacing);
    }
}
