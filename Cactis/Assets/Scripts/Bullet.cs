using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public int damage = 1;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Aplicar velocidad a la bala
        rb.velocity = transform.right * speed;

        // Destruir la bala después de cierto tiempo
        Destroy(gameObject, lifetime);
    }
}
