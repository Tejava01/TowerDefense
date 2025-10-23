using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSimulateEvents : MonoBehaviour
{
    [SerializeField] private UIFrameBattle UIFrameBattle;
    [SerializeField] private UnitCastle UnitCastle;
    [SerializeField] private EnemyCastle EnemyCastle;

    //-------------------------------------------------------------------

    public void SetStageData(StageData stageData)
    {
        EnemyCastle.SetStageData(stageData);
        UnitCastle.SetStageData(stageData);
        UIFrameBattle.SetStageData(stageData);
    }

    public void SetCurrentMana(float mana)
    {
        UIFrameBattle.SetCurrentMana(mana);
    }

    public void SetHpSlider(float hp, MapEnum.ECharacterType characterType)
    {
        if (characterType == MapEnum.ECharacterType.Unit)
        {
            UIFrameBattle.SetHpSlider(hp, characterType);
        }
        else if (characterType == MapEnum.ECharacterType.Enemy)
        {
            UIFrameBattle.SetHpSlider(hp, characterType);
        }
    }

    public void DoPopupClear(float clearTime)
    {
        UIFrameBattle.DoPopupClear(clearTime);
    }

    public void DoPopupFail()
    {
        UIFrameBattle.DoPopupFail();
    }
}
