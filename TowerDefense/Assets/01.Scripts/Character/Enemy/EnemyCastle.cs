using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCastle : Enemy
{
    
    public void SetStageData(StageData stageData)
    {
        m_hp = stageData.EnemyHP;
    }
}
