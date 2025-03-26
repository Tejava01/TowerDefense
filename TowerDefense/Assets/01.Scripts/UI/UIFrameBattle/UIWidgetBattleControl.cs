using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIWidgetBattleControl : UIWidgetBase
{
    [SerializeField] private TextMeshProUGUI ManaText;

    //----------------------------------------------------------------

    public void SetCurrentMana(float mana)
    {
        PrivSettingCurrentMana(mana);
    }

    //----------------------------------------------------------------

    private void PrivSettingCurrentMana(float mana)
    {
        ManaText.text = mana.ToString("F0");
    }
}
