using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static System.Action<int> OnNPCCountChanged;
    public static SpawnManager Instance;
    public GameObject npcPrefab;
    public Transform npcContainer;
    public int npcCount = 20;
    public float spawnRange = 20f;
    private int currentNPCs;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        SpawnNPCs(npcCount);
    }

    // Update is called once per frame
    public void SpawnNPCs(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-spawnRange, spawnRange),
                1f, 
                Random.Range(-spawnRange, spawnRange)
            );

            GameObject npc = Instantiate(
                npcPrefab,
                randomPos,
                Quaternion.identity
            );

            currentNPCs++;
            OnNPCCountChanged?.Invoke(currentNPCs);
        }
    }

    public int GetNPCCount()
    {
        return currentNPCs;
    }
}
