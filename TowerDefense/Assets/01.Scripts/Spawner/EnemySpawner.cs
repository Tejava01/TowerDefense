using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : SpawnerBase
{
    private void Awake()
    {
        ProtCharacterTableSetting();
        ProtCharacterPoolSetting();
    }
}
