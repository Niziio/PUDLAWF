using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlend : MonoBehaviour
{
    private Animator anim;
    public Transform rotationSpawn; //El jugador debe tener un objeto vacio que contenga el SpawnPoint (otro objeto vacio)
    public Transform bulletPrefab; 
    public Transform bulletSpawnPoint;
    Vector2 movement;
    public float moveSpeed = 5f;
    public Rigidbody2D rb; 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0 || vertical != 0)
        {
            anim.SetFloat("X", horizontal);
            anim.SetFloat("Y", vertical);
            anim.SetFloat("Velocidad", 1);

            //Aqui debes poner la rotacion correcta para que la bala salga hacia donde ve el jugador
            if (horizontal > 0 && vertical == 0)
                rotationSpawn.rotation = Quaternion.Euler(0f, 0f, 90f);
            else if (horizontal < 0 && vertical == 0)
                rotationSpawn.rotation = Quaternion.Euler(0f, 0f, -90f);
            else if (horizontal == 0 && vertical > 0)
                rotationSpawn.rotation = Quaternion.Euler(0f, 0f, -180f);
            else if (horizontal == 0 && vertical < 0)
                rotationSpawn.rotation = Quaternion.Euler(0f, 0f, 0f);



        } else
        {
            anim.SetFloat("Velocidad", 0);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    private void Shoot()
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
}
