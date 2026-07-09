using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationUtility 
{
    public static bool IsIdealFormation(FormationType type)
    {
        switch(type)
        {
            case FormationType.Rectangle:
            case FormationType.Circle:
            case FormationType.HorizontalLine:
            case FormationType.VerticalLine:
                return false;

            case FormationType.Triangle:
            case FormationType.Diamond:
            case FormationType.VShape:
                return true;

            default:
                return false;
        }
    }

    public static int GetIdealSlotCount(FormationType type, int npcCount)
    {
        if (!IsIdealFormation(type))
            return npcCount;

        switch(type)
        {
            case FormationType.Triangle:
                return GetTriangleIdeal(npcCount);
            case FormationType.Diamond:
                return GetDiamondIdeal(npcCount);
            case FormationType.VShape:
                return GetVShapeIdeal(npcCount);
            default:
                return npcCount;
        }
    }

     private static int GetTriangleIdeal(int npcCount)
    {
        int row = 1;

        while (true)
        {
            int total = row * (row + 1) / 2;

            if (total >= npcCount)
                return total;

            row++;
        }
    }

    private static int GetDiamondIdeal(int npcCount)
    {
        int level = 0;

        while (true)
        {
            int total = 2 * level * (level + 1) + 1;

            if (total >= npcCount)
                return total;

            level++;
        }
    }

    private static int GetVShapeIdeal(int npcCount)
    {
        if (npcCount <= 1)
            return 1;

        int arm = 1;

        while (true)
        {
            int total = arm * 2 + 1;

            if (total >= npcCount)
                return total;

            arm++;
        }
    }
}
