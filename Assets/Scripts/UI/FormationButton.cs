using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationButton : MonoBehaviour
{
    [SerializeField] private FormationType formationType;
    [SerializeField] private CommandManager commandManager;

    public void SelectFormation()
    {
        commandManager.SetFormation(formationType);
    }
}
