using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidgetTitleButtons : UIWidgetBase
{
    [SerializeField]private UIWidgetTitleExitPopup GameExitPopup;

    //----------------------------------------------------

    public void OnClickGameStart()
    {
        ManagerScene.Instance.DoLoadStageScene(null);
    }
    
    public void OnClickGameExit()
    {
        GameExitPopup.DoShowHideWidget(true);
    }
}
