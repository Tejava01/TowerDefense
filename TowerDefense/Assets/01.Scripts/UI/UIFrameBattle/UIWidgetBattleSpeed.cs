using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWidgetBattleSpeed : MonoBehaviour
{
    private MapEnum.EGameSpeedType m_currentSpeedType = MapEnum.EGameSpeedType.X1;
    private int m_totalSpeedTypeCount = 0;

    //--------------------------------------------------------------

    private void Awake()
    {
        m_totalSpeedTypeCount = Enum.GetValues(typeof(MapEnum.EGameSpeedType)).Length;
    }

    private void Start()
    {
        PrivSetGameSpeed(m_currentSpeedType);
    }

    //--------------------------------------------------------------

    private void PrivSetGameSpeed(MapEnum.EGameSpeedType eSpeedType)
    {
        BattleSimulateManual.Instance.SetGameSpeed(eSpeedType);
        m_currentSpeedType = eSpeedType;
    }

    //----------------------------------------------------

    public void OnClickSpeedCycleUp()
    {
        int nextSpeedTypeIndex = (int)m_currentSpeedType;

        nextSpeedTypeIndex = (nextSpeedTypeIndex + 1) % m_totalSpeedTypeCount;

        MapEnum.EGameSpeedType speedType = (MapEnum.EGameSpeedType)nextSpeedTypeIndex;

        PrivSetGameSpeed(speedType);
    }
}
