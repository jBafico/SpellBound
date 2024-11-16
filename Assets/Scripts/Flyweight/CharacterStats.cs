using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName="ScriptableObjects/Characters", order=0)]
    
public class CharacterStats : ScriptableObject
{
    [SerializeField] private CharacterStatProperties _stats;
    public float MaxLife => _stats.MaxLife;
    public float MoveSpeed => _stats.MoveSpeed;
}

[System.Serializable]
public struct CharacterStatProperties
{
    //Life section
    public float MaxLife;
    //Life Recover, ShieldCover, Max Shield, etc
    
    //Movement section
    public float MoveSpeed;
    // Animator -> animaciones de caminar, correr, etc
}
