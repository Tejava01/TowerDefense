using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBase : CharacterPool
{
    [SerializeField] protected BattleSimulateEvents m_battleSimulateEvents;
    [SerializeField] protected Transform m_spawnPoint;

    //-----------------------------------

    public void DoCharacterSpawn(int characterID)
    {
        m_dicCharacterTable.TryGetValue(characterID, out (int num, CharacterData data) enemy);
        int characterPrefabNum = enemy.num;
        CharacterData characterData = enemy.data;

        CharacterBase characterPrefab = ProtDoPoolNextCharacter(characterPrefabNum);
        characterPrefab.SetPoolIndex(characterPrefabNum);
        characterPrefab.SetBattleSimulateEvents(m_battleSimulateEvents);
        characterPrefab.SetCharacterData(characterData);
        characterPrefab.transform.position = m_spawnPoint.position;
    }
}
