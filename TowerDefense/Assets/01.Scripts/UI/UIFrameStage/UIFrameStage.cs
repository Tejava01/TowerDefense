using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStage : MonoBehaviour
{
    [SerializeField] private Button[] StageButtons;

    //----------------------------------------------------

    private void Start()
    {
        PrivStageSetting();
    }

    //----------------------------------------------------

    private void PrivStageSetting()
    {
        int ClearStage = ManagerSave.Instance.GetClearStage();
        for (int i = 0; i < ClearStage + 1; i++)
        {
            StageButtons[i].interactable = true;
        }
    }
}
