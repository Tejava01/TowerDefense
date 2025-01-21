using UnityEngine;
using UnityEngine.UI;

public class UIFrameBattle : MonoBehaviour
{
    [SerializeField] private UIWidgetBattleControl WidgetControlPanel;
    [SerializeField] private UIWidgetBattleState WidgetBattleState;
    [SerializeField] private UIWidgetBattleClearPopup WidgetClearPopup;
    [SerializeField] private UIWidgetBattleFailPopup WidgetFailPopup;

    //-----------------------------------------------------

    public void SetStageData(StageData stageData)
    {
        WidgetBattleState.SetStageData(stageData);
    }

    public void SetHpSlider(float hp, MapEnum.ECharacterType characterType)
    {
        if (characterType == MapEnum.ECharacterType.Unit)
        {
            WidgetBattleState.SetHpSlider(hp, characterType);
        }
        else if (characterType == MapEnum.ECharacterType.Enemy)
        {
            WidgetBattleState.SetHpSlider(hp, characterType);
        }
    }

    public void SetCurrentMana(float mana)
    {
        WidgetControlPanel.SetCurrentMana(mana);
    }

    public void DoPopupClear(float clearTime)
    {
        WidgetClearPopup.SetClearTime(clearTime);
        WidgetClearPopup.DoShowHideWidget(true);
    }

    public void DoPopupFail()
    {
        WidgetFailPopup.DoShowHideWidget(true);
    }
}
