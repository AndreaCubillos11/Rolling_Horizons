using UnityEngine;
using System.Collections.Generic;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private Vector3 posicionOriginal;
    private int score = 0;


    void Start()
    {

        rb = GetComponent<Rigidbody>();
        posicionOriginal = transform.position; // Guarda la posición inicial

        /*systemaParticulas = particulas.GetComponent<ParticleSystem>();

        systemaParticulas.Stop();

        sonido1 = GetComponent<AudioSource>();
        */
    }

void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = Camera.main.transform.right * moveHorizontal +
        Camera.main.transform.forward * moveVertical;

        movimiento.y = 0f; // evitar que se mueva en vertical

        rb.AddForce(movimiento.normalized * speed);
    }

    void OnTriggerEnter(Collider other)
    {

    }
void OnCollisionEnter(Collision other){
        
}
}
