using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class balloon : MonoBehaviour
{
    public float gravityScale = -0.05f;
    public float waitToDestroy = 1f;
    
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }
    
    private void FixedUpdate()
    {
        rb.gravityScale = gravityScale;
    }
    private void Update()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1) 
        {
            StartCoroutine(destroyBalloon());
        }
    }

    private System.Collections.IEnumerator destroyBalloon()
    {
        yield return new WaitForSeconds(waitToDestroy);
        Destroy(gameObject);
    }

    public void PopBalloon()
    {
        Destroy(gameObject);
    }
}

