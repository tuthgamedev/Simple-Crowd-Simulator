using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public bool IsPointerOverUI()
    {

        bool over = 
            EventSystem.current != null &&
            EventSystem.current.IsPointerOverGameObject();

        Debug.Log("Pointer Over UI = " + over);

        return over; 
    }
}
