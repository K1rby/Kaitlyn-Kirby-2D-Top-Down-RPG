using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [HideInInspector] public float arrowVelocity;
    [SerializeField] Rigidbody2D arrowRB;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4f);   
    }

    void FixedUpdate()
    {
        arrowRB.velocity = transform.up * arrowVelocity;  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
