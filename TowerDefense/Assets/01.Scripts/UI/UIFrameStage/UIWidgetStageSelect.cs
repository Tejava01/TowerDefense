using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidgetStageSelect : UIWidgetBase
{
    [SerializeField] private int StageNumber = 0;

    //----------------------------------------------------

    public void OnClickStageStart()
    {
        ManagerScene.Instance.DoLoadBattleScene(StageNumber, null);
    }
}
