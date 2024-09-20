using UnityEngine;

public class CharacterCrawl : MonoBehaviour, IMoveable
{
    #region IMOVABLE_PROPERTIES

    public float Speed => _speed;

    [SerializeField] private float _speed = 2;
        

    #endregion
        
    #region IMOVABLE_METHODS
    public void Move(Vector2 direction)
    {
        Vector3 movement = direction;
        transform.position +=  movement * Time.deltaTime * Speed;
    }

    public void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position,target, Speed*Time.deltaTime);
    }
        
    //activar animacion de caminar
    //activar sonidos de pasos de caminar
        
    #endregion 
}
