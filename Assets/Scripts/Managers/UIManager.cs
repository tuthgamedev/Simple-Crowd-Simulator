using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text npcCounter;
    public TMP_Text fpsCounter;

    // Update is called once per frame
    void Update()
    {
        UpdateNPCCounter();
        UpdateFPSCounter();
    }

    private void OnEnable()
    {
        SpawnManager.OnNPCCountChanged += UpdateNPCText;
    }

    private void OnDisable()
    {
        SpawnManager.OnNPCCountChanged -= UpdateNPCText;
    }

    void UpdateNPCText(int count)
    {
        npcCounter.text = 
            "NPC : " + count;
    }   

    void UpdateNPCCounter()
    {
        npcCounter.text = 
            "NPC : " + 
            SpawnManager.Instance.GetNPCCount();
    }

    void UpdateFPSCounter()
    {
        float fps = 
            1f / Time.deltaTime;
        
        fpsCounter.text = 
            "FPS : " + 
            Mathf.RoundToInt(fps);
    } 
}
