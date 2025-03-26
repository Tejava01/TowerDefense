using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidgetBattleExitPopup : UIWidgetBase
{
    public void OnClickPopupExitConfirm()
    {
        ManagerScene.Instance.DoLoadStageScene(null);
    }

    public void OnClickPopupExitCancel()
    {
        this.DoShowHideWidget(false);
    }
}
