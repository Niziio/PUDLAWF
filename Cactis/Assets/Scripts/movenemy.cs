using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movenemy : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform targetPoint;

    public Transform originalPoint;
    public float speed = 5f;

    private int currentWaypointIndex;
    private bool hasReachedTarget = false;
    [SerializeField] private GameObject kill;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentWaypointIndex = Random.Range(0, waypoints.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Rotacion();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala"))
        {
            Instantiate(kill, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    

    void Rotacion()
    {
        // Verificar si el NPC ha llegado al punto objetivo
        if (!hasReachedTarget)
        {
            // Mover el NPC hacia el punto objetivo
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

            // Verificar si el NPC ha alcanzado el punto objetivo
            if (transform.position == targetPoint.position)
            {
                hasReachedTarget = true;

                // Voltear el NPC utilizando FlipX del componente SpriteRenderer
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            // Mover el NPC hacia el punto original
            transform.position = Vector3.MoveTowards(transform.position, originalPoint.position, speed * Time.deltaTime);

            // Verificar si el NPC ha regresado al punto original
            if (transform.position == originalPoint.position)
            {
                hasReachedTarget = false;

                // Restaurar la orientación original del NPC
                spriteRenderer.flipX = false;
            }
        }
    }
}