using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidgetBattlePause : UIWidgetBase
{
    [SerializeField] private UIWidgetBattlePausePopup PausePopup;

    //--------------------------------------------------------------

    public void OnClickBattlePause()
    {
        PausePopup.DoShowHideWidget(true);
        BattleSimulateManual.Instance.DoGamePause();
    }
}
