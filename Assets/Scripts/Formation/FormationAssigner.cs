using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FormationAssigner 
{
    public static List<(NPCSelection npc, FormationSlot slot)> AssignRelative(
        List<NPCSelection> npcs,
        List<FormationSlot> slots,
        Vector3 center,
        Vector3 right)
    {
        List<(NPCSelection npc, FormationSlot slot)> assignments = new();
        List<NPCSelection> sortedNPCs = new(npcs);
        List<FormationSlot> sortedSlots = new(slots);

        sortedNPCs.Sort((a, b) =>
        {
            float da = Vector3.Dot(a.transform.position - center, right);
            float db = Vector3.Dot(b.transform.position - center, right);

            return da.CompareTo(db);
        });

        sortedSlots.Sort((a, b) =>
        {
            float da = Vector3.Dot(a.Position - center, right);
            float db = Vector3.Dot(b.Position - center, right);

            return da.CompareTo(db);
        });


        for (int i = 0; i < sortedNPCs.Count; i++)
        {
            assignments.Add(
                (sortedNPCs[i], sortedSlots[i])
            );
        }

        return assignments;
    }
}
