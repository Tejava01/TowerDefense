using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSimulateManual : Singleton<BattleSimulateManual>
{
    [SerializeField] private BattleSimulate BattleSimulate;
    [SerializeField] private UnitSpawner UnitSpawner;
    [SerializeField] private EnemySpawner EnemySpawner;

    private struct SpeedTypeData
    {
        public MapEnum.EGameSpeedType SpeedType;
        public float SpeedValue;

        public SpeedTypeData(MapEnum.EGameSpeedType speedType, float speedValue)
        {
            SpeedType = speedType;
            SpeedValue = speedValue;
        }
    }
    private List<SpeedTypeData> m_listSpeedTypeData = new List<SpeedTypeData>();
    private float m_fPrevGameSpeed = 0;

    //---------------------------------------------

    public float GetManaAmount() { return BattleSimulate.GetManaAmount(); }
    public void SetManaAmount(float cost) { BattleSimulate.SetManaAmount(cost); }
    public float GetGameSpeed() { return BattleSimulate.GetGameSpeed(); }
    public void SetGameSpeed(MapEnum.EGameSpeedType gameSpeed)
    {
        float nextSpeed = 0;

        switch (gameSpeed)
        {
            case MapEnum.EGameSpeedType.X1:
                nextSpeed = MapConst.c_gameSpeedx1;
                break;
            case MapEnum.EGameSpeedType.X2:
                nextSpeed = MapConst.c_gameSpeedx2;
                break;
            case MapEnum.EGameSpeedType.X4:
                nextSpeed = MapConst.c_gameSpeedx4;
                break;
        }

        BattleSimulate.SetGameSpeed(nextSpeed);
    }

    //---------------------------------------------

    public void DoGamePause()
    {
        m_fPrevGameSpeed = BattleSimulate.GetGameSpeed();
        BattleSimulate.SetGameSpeed(MapConst.c_gameSpeedx0);
    }

    public void DoGameResume()
    {
        BattleSimulate.SetGameSpeed(m_fPrevGameSpeed);
    }

    public void DoSpawnCharacter(int characterId, MapEnum.ECharacterType characterType)
    {
        if (characterType == MapEnum.ECharacterType.Unit)
        {
            UnitSpawner.DoCharacterSpawn(characterId);
        }
        else if (characterType == MapEnum.ECharacterType.Enemy)
        {
            EnemySpawner.DoCharacterSpawn(characterId);
        }
    }

    public void DoReturnCharacterPool(int poolIndex, CharacterBase character, MapEnum.ECharacterType characterType)
    {
        if (characterType == MapEnum.ECharacterType.Unit)
        {
            UnitSpawner.DoReturnCharacterPool(poolIndex, character);
        }
        else if (characterType == MapEnum.ECharacterType.Enemy)
        {
            EnemySpawner.DoReturnCharacterPool(poolIndex, character);
        }
    }

    public CharacterDataCache GetCharacterData(int unitId)
    {
        return UnitSpawner.GetCharacterData(unitId);
    }

    public void ClearStage()
    {
        DoGamePause();
        BattleSimulate.ClearStage();
    }

    public void FailStage()
    {
        DoGamePause();
        BattleSimulate.FailStage();
    }
}
