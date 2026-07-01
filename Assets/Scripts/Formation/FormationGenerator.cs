using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FormationGenerator 
{
    public static List<FormationSlot> GenerateRectangle(
        Vector3 destination,
        Vector3 forward,
        int npcCount,
        float spacing)
    {
        List<FormationSlot> slots = new();
        
        if (forward.sqrMagnitude < 0.01f)
        {
            forward = Vector3.forward;
        }
        
        forward.Normalize();

        Vector3 right = Vector3.Cross(Vector3.up, forward);

        int colums = Mathf.CeilToInt(Mathf.Sqrt(npcCount));
        int rows = Mathf.CeilToInt((float)npcCount / colums);

        float width = (colums - 1) * spacing;
        float height = (rows - 1) * spacing;

        Vector3 formationOffset =
            right * (width * 0.5f) +
            forward * (-height * 0.5f);

        for (int i = 0; i < npcCount; i++)
        {
            int row = i / colums;
            int column = i % colums;

            Vector3 offset =
                right * (column * spacing) +
                forward * (-row * spacing);

            offset -= formationOffset;

            slots.Add(new FormationSlot(destination + offset));
        }
        return slots;
    } 
}
