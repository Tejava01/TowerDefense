using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidgetTitleExitPopup : UIWidgetBase
{
    public void OnClickGameExitConfirm()
    {
        ManagerScene.Instance.DoExitGame();
    }

    public void OnClickGameExitCancel()
    {
        DoShowHideWidget(false);
    }
}
