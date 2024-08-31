using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissor : MonoBehaviour
{
    [SerializeField] private Collider2D scissorCollider;
    private balloon _balloon;


    private void Start()
    {
        _balloon = FindObjectOfType<balloon>();
    }

    private void Update()
    {
        if(_balloon == null) return;
        if (scissorCollider.GetComponent<Collider2D>().IsTouching(_balloon.GetComponent<Collider2D>()))
        {
            _balloon.GetComponent<balloon>().PopBalloon();
        }
    }
    
    public void DestroyScissor()
    {
        Destroy(gameObject);
    }
}
