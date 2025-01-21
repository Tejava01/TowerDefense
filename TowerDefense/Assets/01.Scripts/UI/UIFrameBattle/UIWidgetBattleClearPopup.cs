using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIWidgetBattleClearPopup : UIWidgetBase
{
    [SerializeField] private TextMeshProUGUI ClearTime;

    //-------------------------------------

    public void SetClearTime(float clearTime)
    {
        PrivSetClearTime(clearTime);
    }

    //-------------------------------------

    private void PrivSetClearTime(float clearTime)
    {
        ClearTime.text = clearTime.ToString("F0")+" √ ";
    }

    //-------------------------------------

    public void OnClikGoStageSelect()
    {
        ManagerScene.Instance.DoLoadStageScene(null);
    }
}
