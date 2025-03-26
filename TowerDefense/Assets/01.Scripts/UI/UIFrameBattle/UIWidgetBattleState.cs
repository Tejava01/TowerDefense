using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWidgetBattleState : UIWidgetBase
{
    [SerializeField] private Slider PlayerHpSlider;
    [SerializeField] private Slider EnemyHpSlider;

    public void SetStageData(StageData stageData)
    {
        PrivSetStageData(stageData);
    }

    public void SetHpSlider(float hp, MapEnum.ECharacterType characterType)
    {
        if (characterType == MapEnum.ECharacterType.Unit)
        {
            PrivSetHpSlider(hp, characterType);
        }
        else if (characterType == MapEnum.ECharacterType.Enemy)
        {
            PrivSetHpSlider(hp, characterType);
        }
    }

    //-------------------------------------------------------------

    private void PrivSetStageData(StageData stageData)
    {
        PlayerHpSlider.maxValue = stageData.PlayerHP;
        PlayerHpSlider.value = stageData.PlayerHP;

        EnemyHpSlider.maxValue = stageData.EnemyHP;
        EnemyHpSlider.value = stageData.EnemyHP;
    }

    public void PrivSetHpSlider(float hp, MapEnum.ECharacterType characterType)
    {
        if (characterType == MapEnum.ECharacterType.Unit)
        {
            PlayerHpSlider.value = hp;
        }
        else if (characterType == MapEnum.ECharacterType.Enemy)
        {
            EnemyHpSlider.value = hp;
        }
    }

}
