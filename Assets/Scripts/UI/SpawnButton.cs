using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    public void SpawnMoreNPCs()
    {
        SpawnManager.Instance.SpawnNPCs(10);
    }
}
