using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputContext 
{
    public Vector2 MousePosition;

    public bool LeftMouseDown;
    public bool LeftMouseHeld;
    public bool LeftMouseUp;

    public bool RightMouseDown;

    public Ray MouseRay;

    public bool IsPointerOverUI;
}