using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleSimulate : MonoBehaviour
{
    [SerializeField] private BattleSimulateEvents BattleSimulateEvents;

    [Header("Stage Data")]
    [SerializeField] private StageData[] StageData;

    [Header ("Time")]
    [SerializeField] private TextMeshProUGUI BattleTimeText;
    private float m_totalBattleTime = 0;
    
    [Header("Mana")]
    [SerializeField] private float ManaAmount = 0;
    [SerializeField] private float ManaGenTime = 5;
    [SerializeField] private float ManaPerGenTime = 5;
    private float m_manaTime = 0;
    private float m_battleSpeedDelta = 0; //Time.deltaTime * ���� �ӵ�
    private float m_gameSpeed = 1;        //���� �ӵ�

    private StageData m_currentStageData;
    private bool m_wave1 = false;
    private bool m_wave2 = false;
    private bool m_wave3 = false;

    //---------------------------------------------------------------------

    public float GetGameSpeed() { return m_gameSpeed; }                 
    public void SetGameSpeed(float gameSpeed) { m_gameSpeed = gameSpeed; }
    public float GetGameTimeTotal() { return m_totalBattleTime; }       
    public float GetBattleSpeedDelta() { return m_battleSpeedDelta; }   
    public float GetManaAmount() { return ManaAmount; }
    public void SetManaAmount(float cost)
    {   
        ManaAmount -= cost;
        BattleSimulateEvents.SetCurrentMana(ManaAmount);
    }

    //---------------------------------------------------------------------

    private void Start()
    {
        PrivSettingStage();
        BattleSimulateEvents.SetCurrentMana(ManaAmount);
    }

    private void Update()
    {
        PrivBattleSpeedDeltaTimer();

        PrivChangeTotalBattleTime();
        PrivChangeManaGenTime();

        PrivCheckWave();
    }

    //---------------------------------------------------------------------

    public void ClearStage()
    {
        ManagerSave.Instance.SetClearStage(ManagerSave.Instance.GetCurrentStage());
        BattleSimulateEvents.DoPopupClear(GetGameTimeTotal());
    }

    public void FailStage()
    {
        BattleSimulateEvents.DoPopupFail();
    }

    //---------------------------------------------------------------------

    private IEnumerator CoroutineSpawnTime(int[] wave,float sec)
    {
        for (int i = 0; i < wave.Length; i++)
        {
            yield return new WaitForSeconds(sec);

            BattleSimulateManual.Instance.DoSpawnCharacter(wave[i], MapEnum.ECharacterType.Enemy);
        }
    }

    private void PrivCheckWave()
    {
        //wave1����
        if (m_totalBattleTime >= 0 && m_wave1==false)
        {
            Debug.Log("Wave1 ����");
            m_wave1 = true;
            StartCoroutine(CoroutineSpawnTime(m_currentStageData.Wave1, 5));
        }
        //wave2����
        else if (m_totalBattleTime >= 30 && m_wave2==false)
        {
            m_wave2 = true;
            Debug.Log("Wave2 ����");
            StartCoroutine(CoroutineSpawnTime(m_currentStageData.Wave2, 5));
        }
        //wave3����
        else if (m_totalBattleTime >= 60  && m_wave3==false)
        {
            m_wave3 = true;
            Debug.Log("Wave3 ����");
            StartCoroutine(CoroutineSpawnTime(m_currentStageData.Wave3, 5));
        }
    }

    private void PrivBattleSpeedDeltaTimer()
    {
        m_battleSpeedDelta = Time.deltaTime * m_gameSpeed;
    }

    private void PrivSettingStage()
    {
        int m_stageLevel = ManagerSave.Instance.GetCurrentStage();

        //teststage
        if (m_stageLevel == -1)
        {
            Debug.Log("�׽�Ʈ�� �������� 1�� �ε��մϴ�");
            m_stageLevel = 1;
        }

        Debug.Log($"���� �������� : {m_stageLevel}");
        m_currentStageData = StageData[m_stageLevel - 1];

        BattleSimulateEvents.SetStageData(m_currentStageData);
    }


    private void PrivChangeTotalBattleTime()
    {
        m_totalBattleTime += m_battleSpeedDelta;
        BattleTimeText.text = m_totalBattleTime.ToString("F0");
    }

    private void PrivChangeManaGenTime()
    {
        m_manaTime += m_battleSpeedDelta;
        
        if (m_manaTime >= ManaGenTime)
        {
            ManaAmount += ManaPerGenTime;
            BattleSimulateEvents.SetCurrentMana(ManaAmount);

            //m_battleSpeedDelta��������ŭ �ð��ս��� �߻��ϴ°� ������ 
            m_manaTime = m_manaTime - ManaGenTime;
        }
    }
}
