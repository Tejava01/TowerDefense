using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : SpawnerBase
{
    public CharacterDataCache GetCharacterData(int characterID)
    {
        m_dicCharacterTable.TryGetValue(characterID, out (int num , CharacterData data) character);

        CharacterDataCache cache = new CharacterDataCache();
        cache.portrait = character.data.Portrait;
        cache.id = character.data.Id;
        cache.name = character.data.Name;
        cache.cost = character.data.Cost;
        cache.hp = character.data.Hp;
        cache.attack = character.data.Attack;
        cache.speed = character.data.Speed;
        cache.targetCount = character.data.TargetCount;

        return cache;
    }

    //-------------------------------------------------------

    private void Awake()
    {
        ProtCharacterTableSetting();
        ProtCharacterPoolSetting();
    }
}