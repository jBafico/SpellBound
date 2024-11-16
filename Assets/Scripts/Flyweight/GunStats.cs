using UnityEngine;

[CreateAssetMenu(fileName = "GunStats", menuName="ScriptableObjects/Guns", order=0)]


public class GunStats : ScriptableObject
{
    [SerializeField] private GunStatProperties _gunStats;

    public GameObject BulletPrefab => _gunStats.BulletPrefab;
    public int Damage => _gunStats.Damage;
    public int MaxBullets => _gunStats.MaxBullets;
    public int ShotCount => _gunStats.ShotCount;
}

[System.Serializable]
public struct GunStatProperties
{
    public GameObject BulletPrefab;
    public int Damage;
    public int MaxBullets;
    public int ShotCount;
}