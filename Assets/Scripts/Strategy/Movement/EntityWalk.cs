using UnityEngine;

public class EntityWalk : MonoBehaviour, IMoveable
{
    #region IMOVABLE_PROPERTIES

    public float Speed => GetComponent<Enemy>().CharacterStats.MoveSpeed;
        

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
        
    public void MoveAway(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position,target, -1*Speed*Time.deltaTime);
    }
        
    #endregion 
}