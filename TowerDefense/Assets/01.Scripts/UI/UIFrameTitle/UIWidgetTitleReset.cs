using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidgetTitleReset : UIWidgetBase
{
    [SerializeField] private UIWidgetTitleResetPopup GameResetPopup;

    //----------------------------------------------------

    public void OnClickGameResetPopup()
    {
        GameResetPopup.DoShowHideWidget(true);
    }
}
