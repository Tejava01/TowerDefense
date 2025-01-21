using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCastle : Unit
{
    public void SetStageData(StageData stageData)
    {
        m_hp = stageData.PlayerHP;
    }
}
