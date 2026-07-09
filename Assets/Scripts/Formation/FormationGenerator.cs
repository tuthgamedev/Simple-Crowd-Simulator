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

    public static List<FormationSlot> GenerateCircle(
        Vector3 center,
        Vector3 forward,
        int unitCount,
        float spacing)
    {
        List<FormationSlot> slots = new List<FormationSlot>();

        if (unitCount == 0)
            return slots;

        float radius = Mathf.Max(spacing, (unitCount * spacing) / (2f * Mathf.PI));

        for (int i = 0; i < unitCount; i++)
        {
            float angle = i * Mathf .PI * 2f / unitCount;

            Vector3 offset =
            new Vector3(
                Mathf.Cos(angle),
                0f,
                Mathf.Sin(angle)
            ) * radius;

            Vector3 position = center + offset;

            slots.Add(new FormationSlot(position));
        }
        return slots;
    }

    public static List<FormationSlot> GeneratorHorizontalLine(
        Vector3 center,
        Vector3 forward,
        int unitCount,
        float spacing)
    {
        List<FormationSlot> slots = new List<FormationSlot>();

        Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

        float totalWidth = (unitCount - 1) * spacing;

        for (int i = 0; i < unitCount; i++)
        {
            float offset = i * spacing - totalWidth * 0.5f;

            Vector3 position = center + right * offset;

            slots.Add(new FormationSlot(position));
        }

        return slots;
    }

    public static List<FormationSlot> GenerateVerticalLine(
        Vector3 center,
        Vector3 forward,
        int unitCount,
        float spacing)
    {
        List<FormationSlot> slots = new List<FormationSlot>();

        float totalLength = (unitCount - 1) * spacing;

        for (int i = 0; i < unitCount; i++)
        {
            float offset = i * spacing - totalLength * 0.5f;

            Vector3 position = center + forward * offset;

            slots.Add(new FormationSlot(position));
        }

        return slots;
    }

    public static List<FormationSlot> GenerateTriangle(
        Vector3 center,
        Vector3 forward,
        int slotCount,
        float spacing)
    {
        List<FormationSlot> slots = new();

        if (slotCount <= 0)
            return slots;

        forward.Normalize();
        Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

        int placed = 0;
        int row = 1;

        while (placed < slotCount)
        {
            float rowWidth = (row - 1) * spacing;

            for (int i = 0; i < row && placed < slotCount; i++)
            {
                float xOffset = i * spacing - rowWidth * 0.5f;

                Vector3 position =
                    center
                    - forward * (row - 1) * spacing
                    + right * xOffset;

                slots.Add(new FormationSlot(position));

                placed++;
            }

            row++;
        }

        return slots;
    }

    public static List<FormationSlot> GenerateVShape(
        Vector3 center,
        Vector3 forward,
        int unitCount,
        float spacing)
    {
        List<FormationSlot> slots = new List<FormationSlot>();

        Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

        int placed = 0;
        int row = 0;

        while (placed < unitCount)
        {
            if (row == 0)
            {
                slots.Add(new FormationSlot(center));
                placed++;
                row++;
                continue;
            }

            Vector3 leftPosition =
                center
                - forward * row * spacing
                - right * row * spacing;

            slots.Add(new FormationSlot(leftPosition));
            placed++;

            if (placed >= unitCount)
                break;

            Vector3 rightPosition =
                center
                - forward * row * spacing
                + right * row * spacing;

            slots.Add(new FormationSlot(rightPosition));
            placed++;

            row++;
        }

        return slots;
    }

    public static List<FormationSlot> GenerateDiamond(
        Vector3 center,
        Vector3 forward,
        int unitCount,
        float spacing)
    {
        List<FormationSlot> slots = new List<FormationSlot>();

        Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

        int placed = 0;
        int row = 0;
        int unitsInRow = 1;
        bool expanding = true;

        while (placed < unitCount)
        {
            float rowWidth = (unitsInRow - 1) * spacing;

            for (int i = 0; i < unitsInRow && placed < unitCount; i++)
            {
                float offset = i * spacing - rowWidth * 0.5f;

                Vector3 position =
                    center
                    - forward * row * spacing
                    + right * offset;

                slots.Add(new FormationSlot(position));

                placed++;
            }

            row++;

            if (expanding)
            {
                unitsInRow += 2;

                // kalau sisa NPC sudah lebih sedikit,
                // mulai mengecil
                if (placed + unitsInRow > unitCount)
                {
                    expanding = false;
                }
            }
            else
            {
                unitsInRow = Mathf.Max(1, unitsInRow - 2);
            }
        }

        return slots;
    }

    public static List<FormationSlot> GenerateFormation(
        FormationType formationType,
        Vector3 center,
        Vector3 forward,
        int unitCount,
        float spacing)
    {
        switch (formationType)
        {
            case FormationType.Rectangle:
                return GenerateRectangle(center, forward, unitCount, spacing);
            
            case FormationType.Circle:
                return GenerateCircle(center, forward, unitCount, spacing);

            case FormationType.HorizontalLine:
                return GeneratorHorizontalLine(center, forward, unitCount, spacing);

            case FormationType.VerticalLine:
                return GenerateVerticalLine(center, forward, unitCount, spacing);

            case FormationType.Triangle:
                return GenerateTriangle(center, forward, unitCount, spacing);

            case FormationType.VShape:
                return GenerateVShape(center, forward, unitCount, spacing);

            case FormationType.Diamond:
                return GenerateDiamond(center, forward, unitCount, spacing);

            default:
                return GenerateRectangle(center, forward, unitCount, spacing);
        }
    } 
}
