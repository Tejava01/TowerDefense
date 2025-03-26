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

        Debug.Log("�ʱ�ȭ �Ϸ�");
    }

    public void OnClickPopupResetCancel()
    {
        DoShowHideWidget(false);
    }
}
