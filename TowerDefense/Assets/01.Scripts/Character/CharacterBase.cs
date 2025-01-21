using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CharacterDataCache
{
    public Sprite portrait;
    public int id;
    public string name;
    public int cost;
    public float hp;
    public float attack;
    public float speed;
    public int targetCount;
}

public class CharacterBase : MonoBehaviour
{
    [SerializeField] protected int PoolIndex;
    [SerializeField] protected BattleSimulateEvents BattleSimulateEvents;

    protected Transform m_transform;
    protected Animator m_animator;

    protected Sprite m_portrait;
    protected int m_id;
    protected string m_name;
    protected int m_cost;
    protected float m_hp;
    protected float m_attack;
    protected float m_speed;
    protected int m_targetCount;

    public int GetPoolIndex() { return PoolIndex; }
    public void SetPoolIndex(int poolIndex) { PoolIndex = poolIndex; }
    public BattleSimulateEvents GetBattleSimulateEvents() { return BattleSimulateEvents; }
    public void SetBattleSimulateEvents(BattleSimulateEvents events) { BattleSimulateEvents = events; }
    public CharacterDataCache GetCharacterData()
    {
        CharacterDataCache cache = new CharacterDataCache();
        cache.portrait = m_portrait;
        cache.id = m_id;
        cache.name = m_name;
        cache.cost = m_cost;
        cache.hp = m_hp;
        cache.attack = m_attack;
        cache.speed = m_speed;
        cache.targetCount = m_targetCount;

        return cache;
    }
    public void SetCharacterData(CharacterData data)
    {
        m_portrait = data.Portrait;
        m_id = data.Id;
        m_name = data.Name;
        m_cost = data.Cost;
        m_hp = data.Hp;
        m_attack = data.Attack;
        m_speed = data.Speed;
        m_targetCount = data.TargetCount;
    }

    //----------------------------------------------

    protected void ProtChangeAnimSpeed()
    {
        m_animator.speed = BattleSimulateManual.Instance.GetGameSpeed();
    }

    protected void ProtClearAnimState()
    {
        m_animator.SetBool("Walk", false);
        m_animator.SetBool("Attack", false);
    }

    protected void ProtDoAnimWalk()
    {
        m_animator.SetBool("Walk", true);
        
        Vector3 speed = Vector3.left * m_speed * BattleSimulateManual.Instance.GetGameSpeed() * Time.deltaTime;
        if (gameObject.tag == "Unit")
        {
            m_transform.position -= speed;
        }
        else if (gameObject.tag == "Enemy")
        {
            m_transform.position += speed;
        }
       
    }

    protected void ProtDoAnimAttack()
    {
        m_animator.SetBool("Attack", true);

    }

    protected void ProtDoAnimDead()
    {
        m_animator.SetTrigger("Die");
    }
}
