using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "Scriptable Object/StageData")]
public class StageData : ScriptableObject
{
    public float PlayerHP;
    public float EnemyHP;

    public int[] Wave1;
    public int[] Wave2;
    public int[] Wave3;
}
