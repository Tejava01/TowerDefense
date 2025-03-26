using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMiyako : Unit
{
    private void Start()
    {
        m_transform = GetComponent<Transform>();
        m_animator = GetComponent<Animator>();
        m_unitState = MapEnum.EUnitState.Walk;
    }

    private void Update()
    {
        ProtChangeAnimSpeed();
        ProtCheckUnitState();
    }

    //-----------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProtOnTriggerEnterUnit(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ProtOnTriggerStayUnit(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ProtOnTriggerExitUnit(collision);
    }
}
