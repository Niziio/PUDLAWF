using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movenemy : MonoBehaviour
{
    public Transform[] waypoints;  // Array de los puntos a lo largo de los cuales el personaje se moverá
    public float speed = 5f;  // Velocidad de movimiento del personaje
    private int currentWaypointIndex;  // Índice del punto actual hacia el que el personaje se está moviendo
    [SerializeField] private GameObject kill;
    void Start()
    {
        currentWaypointIndex = Random.Range(0, waypoints.Length);
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        Transform currentPoint = waypoints[currentWaypointIndex];

        transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.1f)
        {
            currentWaypointIndex = Random.Range(0, waypoints.Length);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala"))
        {
            Instantiate(kill, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}