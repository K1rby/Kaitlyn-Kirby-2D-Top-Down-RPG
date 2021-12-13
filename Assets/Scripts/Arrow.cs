using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [HideInInspector] public float arrowVelocity;
    [HideInInspector] public float arrowDamage;
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
        if(collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Enemy Attacked");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(arrowDamage);
        }
        Destroy(gameObject);
    }
}
