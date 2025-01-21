using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGolem01 : Enemy
{
    private void Start()
    {
        m_transform = GetComponent<Transform>();
        m_animator = GetComponent<Animator>();
        m_enemyState = MapEnum.EEnemyState.Walk;
    }

    private void Update()
    {
        ProtChangeAnimSpeed();
        ProtCheckEnemyState();
    }

    //-----------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProtOnTriggerEnterEnemy(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ProtOnTriggerStayEnemy(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ProtOnTriggerExitEnemy(collision);
    }
}
