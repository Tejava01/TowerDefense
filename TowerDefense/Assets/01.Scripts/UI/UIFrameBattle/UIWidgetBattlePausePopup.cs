using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidgetBattlePausePopup : UIWidgetBase
{
    [SerializeField] private UIWidgetBattleExitPopup ExitPopup;

    //--------------------------------------------------

    public void OnClickPopupResume()
    {
        this.gameObject.SetActive(false);
        BattleSimulateManual.Instance.DoGameResume();
    }

    public void OnClickPopupExit()
    {
        ExitPopup.DoShowHideWidget(true);
    }
}
