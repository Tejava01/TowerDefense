using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEnum
{
    public enum EGameSpeedType
    {
        X1,
        X2,
        X4,
    }

    public enum ECharacterType
    {
        Unit,
        Enemy,
    }

    public enum EUnitType
    {
        Castle,
        Character,
    }

    public enum EEnemyType
    {
        Castle,
        Character,
    }

    public enum EUnitState
    {
        Walk,
        Attack,
        Dead,
    }

    public enum EEnemyState
    {
        Walk,
        Attack,
        Dead,
    }  
}
