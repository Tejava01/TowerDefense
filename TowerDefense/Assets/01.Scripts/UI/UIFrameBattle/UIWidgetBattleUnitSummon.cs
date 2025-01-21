using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIWidgetBattleUnitSummon : UIWidgetBase
{
    [SerializeField] private int UnitID = 0;
    [SerializeField] private TextMeshProUGUI UnitCostText;
    [SerializeField] private Button SummonButton;
    [SerializeField] private Image Portrait;
    [SerializeField] private TextMeshProUGUI ManaOringText;

    private int unitCost;

    //-----------------------------------------------------

    public void Start()
    {
        ButtonSetting();
    }

    //-----------------------------------------------------

    private void ButtonSetting()
    {
        CharacterDataCache data = BattleSimulateManual.Instance.GetCharacterData(UnitID);

        SummonButton.image.sprite = data.portrait;
        unitCost = data.cost;
        UnitCostText.text = unitCost.ToString("F0");
    }

    private IEnumerator ButtonRed()
    {
        Portrait.color = Color.red;
        ManaOringText.alpha = 1;

        yield return new WaitForSeconds(0.2f);

        Portrait.color = new Color(255, 255, 255);
        ManaOringText.alpha = 0;
    }

    //-----------------------------------------------------

    public void OnClickSummonUnit()
    {
        if (BattleSimulateManual.Instance.GetManaAmount() >= unitCost)
        {
            BattleSimulateManual.Instance.SetManaAmount(unitCost);
            BattleSimulateManual.Instance.DoSpawnCharacter(UnitID, MapEnum.ECharacterType.Unit);
        }
        else
        {
            StartCoroutine(ButtonRed());
        }
    }
}
