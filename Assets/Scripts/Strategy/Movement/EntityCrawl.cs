using UnityEngine;

public class EntityCrawl : MonoBehaviour, IMoveable
{
    #region IMOVABLE_PROPERTIES

    public float Speed => GetComponent<Enemy>().CharacterStats.MoveSpeed/2;
        

    #endregion
        
    #region IMOVABLE_METHODS
    public void Move(Vector2 direction)
    {
        Vector3 movement = direction;
        if (direction.x > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f));
        }
        else if (direction.x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f));
        }
        transform.position +=  movement * Time.deltaTime * Speed;
    }

    public void MoveTowards(Vector2 target)
    {
        Vector2 direction = (Vector2)transform.position - target;

        if (direction.x > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f));
        }
        else if (direction.x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f));
        }
        transform.position = Vector2.MoveTowards(transform.position,target, Speed*Time.deltaTime);
    }
    
    public void MoveAway(Vector2 target)
    {
        Vector2 direction = (Vector2)transform.position - target;

        if (direction.x > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f));
        }
        else if (direction.x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f));
        }
        transform.position = Vector2.MoveTowards(transform.position,target, -1*Speed*Time.deltaTime);
    }
    
    #endregion 
}