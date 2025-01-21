using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    [SerializeField] private MapEnum.EEnemyType EnemyType;

    protected MapEnum.EEnemyState m_enemyState;
    protected List<Unit> m_listTargetUnit = new List<Unit>();

    //---------------------------------------------

    public void EnemyDamaged(float damage)
    {
        m_hp -= damage;

        if (m_hp <= 0 && EnemyType == MapEnum.EEnemyType.Castle)
        {
            PrivEnemyCastleDestroy();
        }
        else if (m_hp <= 0 && EnemyType == MapEnum.EEnemyType.Character)
        {
            PrivEnemyDie();
        }
    }

    public MapEnum.EEnemyType GetEnemyType()
    {
        return EnemyType;
    }

    //---------------------------------------------

    protected void ProtCheckEnemyState()
    {
        ProtClearAnimState();
        switch (m_enemyState)
        {
            case MapEnum.EEnemyState.Walk:
                ProtDoAnimWalk();
                break;
            case MapEnum.EEnemyState.Attack:
                ProtDoAnimAttack();
                break;
            case MapEnum.EEnemyState.Dead:
                ProtDoAnimDead();
                break;
        }
    }

    protected void ProtOnTriggerEnterEnemy(Collider2D collision)
    {

    }

    protected void ProtOnTriggerStayEnemy(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Unit"))
        {
            m_enemyState = MapEnum.EEnemyState.Attack;
            for (int i = 0; i < m_targetCount; i++)
            {
                Unit unit = collision.gameObject.GetComponent<Unit>();

                if (!m_listTargetUnit.Contains(unit))
                {
                    m_listTargetUnit.Add(unit);
                }
            }
        }
    }

    protected void ProtOnTriggerExitEnemy(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Unit"))
        {
            m_enemyState = MapEnum.EEnemyState.Walk;
        }
    }

    //---------------------------------------------

    private void PrivEnemyAttack()
    {
        for (int i = 0; i < m_listTargetUnit.Count; i++)
        {
            m_listTargetUnit[i].UnitDamaged(m_attack);

            if (m_listTargetUnit[i].GetUnitType() == MapEnum.EUnitType.Castle)
            {
                m_listTargetUnit[i].GetBattleSimulateEvents().SetHpSlider(m_listTargetUnit[i].GetCharacterData().hp, MapEnum.ECharacterType.Unit);
            }
        }
    }

    private void PrivEnemyCastleDestroy()
    {
        BattleSimulateManual.Instance.ClearStage();
    }

    private void PrivEnemyDie()
    {
        BattleSimulateManual.Instance.DoReturnCharacterPool(PoolIndex, gameObject.GetComponent<CharacterBase>(), MapEnum.ECharacterType.Enemy);
    }
}