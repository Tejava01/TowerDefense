using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidgetBattleFailPopup : UIWidgetBase
{
    public void OnClikGoStageSelect()
    {
        ManagerScene.Instance.DoLoadStageScene(null);
    }
}
