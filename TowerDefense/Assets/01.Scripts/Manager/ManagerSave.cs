using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSave : Singleton<ManagerSave>
{
    [SerializeField] private int ClearStage = -1;
    [SerializeField] private int CurrentStage = -1;

    //-----------------------------------------------------------------

    private void Start()
    {
        if (PlayerPrefs.HasKey("ClearStage") )
        {
            ClearStage = GetClearStage();
        }
        else
        {
            PlayerPrefs.SetInt("ClearStage", 0);
            CurrentStage = 0;
        }
    }

    //-----------------------------------------------------------------

    public int GetClearStage() { return PlayerPrefs.GetInt("ClearStage"); }
    public void SetClearStage(int stageLevel) { PlayerPrefs.SetInt("ClearStage", stageLevel); }
    public int GetCurrentStage() { return CurrentStage; }
    public void SetCurrentStage(int stage) { CurrentStage = stage; }
}
