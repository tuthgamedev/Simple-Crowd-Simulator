using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FormationDatabase
{
    public static bool UsesIdealSlots(FormationType type)
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

    public static string GetDisplayName(FormationType type)
    {
        switch(type)
        {
            case FormationType.Rectangle:
                return "Rectangle";

            case FormationType.Circle:
                return "Circle";

            case FormationType.HorizontalLine:
                return "Horizontal Line";

            case FormationType.VerticalLine:
                return "Vertical Line";

            case FormationType.Triangle:
                return "Triangle";

            case FormationType.Diamond:
                return "Diamond";

            case FormationType.VShape:
                return "V Shape";

            default:
                return "Unknown";
        }
    }
}