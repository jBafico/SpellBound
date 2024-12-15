using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public enum EnemyType { Zombie, RavageZombie, Orb, Golem, NecromancerGolem, Necromancer, Ball, Ghost}

    [SerializeField] private Enemy zombiePrefab;
    [SerializeField] private Enemy ravageZombiePrefab;
    [SerializeField] private Enemy orbPrefab;
    [SerializeField] private Enemy golemPrefab;
    [SerializeField] private Enemy necromancerGolemPrefab;
    [SerializeField] private Enemy necromancerPrefab;
    [SerializeField] private Enemy ballPrefab;
    [SerializeField] private Enemy ghostPrefab;

    private IFactory<Enemy> _factory = new Spawner<Enemy>();

    #region SINGLETON
        static public EnemyFactory instance;
        private void Awake() {
            if(instance != null) Destroy(this);
            instance = this;
        }
    #endregion

    public Enemy CreateEnemy(EnemyType type, Vector3 position)
    {
        Enemy enemyInstance = null;

        switch (type)
        {
            case EnemyType.Zombie:
                enemyInstance = _factory.Create(zombiePrefab);
                break;
            case EnemyType.RavageZombie:
                enemyInstance = _factory.Create(ravageZombiePrefab);
                break;
            case EnemyType.Orb:
                enemyInstance = _factory.Create(orbPrefab);
                break;
            case EnemyType.Golem:
                enemyInstance = _factory.Create(golemPrefab);
                break;
            case EnemyType.NecromancerGolem:
                enemyInstance = _factory.Create(necromancerGolemPrefab);
                break;
            case EnemyType.Necromancer:
                enemyInstance = _factory.Create(necromancerPrefab);
                break;
            case EnemyType.Ball:
                enemyInstance = _factory.Create(ballPrefab);
                break;
            case EnemyType.Ghost:
                enemyInstance = _factory.Create(ghostPrefab);
                break;
        }

        if (enemyInstance != null)
        {
            enemyInstance.transform.position = position; 
            enemyInstance.transform.rotation = Quaternion.identity;
        }

        return enemyInstance;
    }
}
