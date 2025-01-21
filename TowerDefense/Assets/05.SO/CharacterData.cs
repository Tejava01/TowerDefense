using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Object/CharacterData")]
public class CharacterData : ScriptableObject
{
    public Sprite Portrait;
    public int Id;
    public string Name;
    public int Cost;
    public float Hp;
    public float Attack;
    public float Speed;
    public int TargetCount;
}
