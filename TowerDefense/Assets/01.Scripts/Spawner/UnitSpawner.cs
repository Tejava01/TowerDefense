using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : SpawnerBase
{
    //질문)이거 CharacterBase에 있는데 여기다 또 만들어도 되는건지..
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