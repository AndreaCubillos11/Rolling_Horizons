using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public bool enterrado = false;
    public float profundidadEnterrado = -0.5f; // Valor negativo para enterrar
    private Vector3 posicionOriginal;
    public AudioSource sonido1;
    private bool sonidoReproducido = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionOriginal = transform.position; // Guarda la posición inicial


        sonido1 = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (!enterrado)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movimiento = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movimiento * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Recolectable"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Mud") )
        {
            enterrado = true;
            // Mueve al jugador hacia abajo (enterrado)
            transform.Translate(0, profundidadEnterrado, 0);
            // Detiene el Rigidbody
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true; // Evita que se mueva por física

                  // Mensaje en la consola
            Debug.Log("¡Ups! Has quedado enterrado en el lodo");
        }

        if (other.gameObject.CompareTag("Rake"))
        {
            enterrado = true;
            transform.Translate(0, profundidadEnterrado, 0);
            // Opcional: Detener el Rigidbody
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Debug.Log("¡Te has pinchado con el rastrillo!");
        }


        if (other.gameObject.CompareTag("Desaparecer") && !sonidoReproducido)
        {
            // Destruye todas las plataformas
            GameObject[] plataformas = GameObject.FindGameObjectsWithTag("Platform");
            foreach (GameObject plataforma in plataformas)
            {
                Destroy(plataforma);
            }

            Debug.Log("¡Todas las plataformas han sido destruidas!");

            // Reproduce el sonido SOLO al destruir las plataformas
            if (sonido1 != null)
            {
                sonido1.Play();
                sonidoReproducido = true; // Marca el sonido como reproducido
            }

    



    
}
}
}
