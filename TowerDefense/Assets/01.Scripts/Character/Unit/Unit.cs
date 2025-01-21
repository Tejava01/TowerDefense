using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : CharacterBase
{
    [SerializeField] private MapEnum.EUnitType UnitType;

    protected MapEnum.EUnitState m_unitState;
    protected List<Enemy> m_listTargetEnemy = new List<Enemy>();

    //---------------------------------------------

    public void UnitDamaged(float damage)
    {
        m_hp -= damage;

        if (m_hp <= 0 && UnitType == MapEnum.EUnitType.Castle)
        {
            PrivUnitCastleDestroy();
        }
        else if (m_hp <= 0 && UnitType == MapEnum.EUnitType.Character)
        {
            PrivUnitDie();
        }
    }

    public MapEnum.EUnitType GetUnitType()
    {
        return UnitType;
    }

    //-------------------------------------

    protected void ProtCheckUnitState()
    {
        ProtClearAnimState();
        switch (m_unitState)
        {
            case MapEnum.EUnitState.Walk:
                ProtDoAnimWalk();
                break;
            case MapEnum.EUnitState.Attack:
                ProtDoAnimAttack();
                break;
            case MapEnum.EUnitState.Dead:
                ProtDoAnimDead();
                break;
        }
    }

    protected void ProtOnTriggerEnterUnit(Collider2D collision)
    {

    }

    protected void ProtOnTriggerStayUnit(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            m_unitState = MapEnum.EUnitState.Attack;
            for (int i = 0; i < m_targetCount; i++)
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();

                if (!m_listTargetEnemy.Contains(enemy))
                {
                    m_listTargetEnemy.Add(enemy);
                }
            }
        }
    }

    protected void ProtOnTriggerExitUnit(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            m_unitState = MapEnum.EUnitState.Walk;
        }
    }

    //-------------------------------------

    private void PrivUnitAttack()
    {
        for (int i = 0; i < m_listTargetEnemy.Count; i++)
        {
            m_listTargetEnemy[i].EnemyDamaged(m_attack);

            if (m_listTargetEnemy[i].GetEnemyType() == MapEnum.EEnemyType.Castle)
            {
                m_listTargetEnemy[i].GetBattleSimulateEvents().SetHpSlider(m_listTargetEnemy[i].GetCharacterData().hp, MapEnum.ECharacterType.Enemy);
            }
        }
    }

    private void PrivUnitCastleDestroy()
    {
        BattleSimulateManual.Instance.FailStage();    
    }

    private void PrivUnitDie()
    {
        BattleSimulateManual.Instance.DoReturnCharacterPool(PoolIndex, gameObject.GetComponent<CharacterBase>(), MapEnum.ECharacterType.Unit);
    }
}