using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    

    public void BodyType(int type)
    {
        //0: Dynamic, 1: Kinematic, 2: Static
        rb.bodyType = (RigidbodyType2D) type; 
    }
    
    public void DestroyBall()
    {
        Destroy(gameObject);
    }
}