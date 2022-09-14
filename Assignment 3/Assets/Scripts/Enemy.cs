using UnityEngine;

public class Enemy : MonoBehaviour
{
   [Header("Attributes")]
    public float speedMin = 1.0f;
    public float speedMax = 6.0f;
    public float speed = 5f;
    public float directionType = 1.0f;

    private bool direction = true;

    [Header("Unity Setup Field")]
    public Rigidbody2D enemyRd;
    

    void Start()
    {
        enemyRd = GetComponent<Rigidbody2D>();
      
    }

   
    void FixedUpdate()
    {
        speed = Random.Range(speedMin, speedMax);
        if (direction == true)
        {
            enemyRd.AddForce(Vector2.right.normalized * speed * Time.deltaTime * directionType, ForceMode2D.Impulse);
        }
        else
        {
            enemyRd.AddForce(Vector2.right.normalized * -speed * Time.deltaTime * directionType, ForceMode2D.Impulse);
        }

    }
    

     void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Boundary"))
        {
            if (direction)
            {
                direction = false;
            }
            else if (!direction)
            {
                direction = true;
            }
        }
        else
            return;
    }
}
