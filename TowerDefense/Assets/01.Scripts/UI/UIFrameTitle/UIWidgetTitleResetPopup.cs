using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidgetTitleResetPopup : UIWidgetBase
{
    private void PrivPlayerPrefsClear()
    {
        PlayerPrefs.DeleteAll();
    }

    //--------------------------------------------------------------

    public void OnClickPopupResetConfirm()
    {
        DoShowHideWidget(false);
        PrivPlayerPrefsClear();

        Debug.Log("초기화 완료");
    }

    public void OnClickPopupResetCancel()
    {
        DoShowHideWidget(false);
    }
}
