using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRegistry : MonoBehaviour
{
    public static NPCRegistry Instance;
    public List<GameObject> NPCs = 
        new List<GameObject>();
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void Register(GameObject npc)
    {
        NPCs.Add(npc);
    }

    public void Unregister(GameObject npc)
    {
        NPCs.Remove(npc);
    }
}
