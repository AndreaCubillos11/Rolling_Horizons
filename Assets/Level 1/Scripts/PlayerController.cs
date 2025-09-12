using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public bool enterrado = false;
    public float profundidadEnterrado;
    private Vector3 posicionOriginal;
    public AudioSource sonido1;
    private bool sonidoReproducido = false;
    private int score = 0;

    public Transform particulas;
    private ParticleSystem systemaParticulas;
    private Vector3 posicion;

    public Transform particulasF;
    private ParticleSystem systemaParticulasF;
    private Vector3 posicionF;

    public AudioSource paredes;
    public AudioSource audioRecoleccion;
    public AudioSource audioRecoleccionF;


    void Start()
    {

        rb = GetComponent<Rigidbody>();
        posicionOriginal = transform.position; // Guarda la posición inicial

    systemaParticulas = particulas.GetComponent<ParticleSystem>();

    systemaParticulas.Stop();

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
            score = score + 10;
            Debug.Log("Ganas 10 puntos");
            Debug.Log("Puntaje: "+ score);
            posicion = other.gameObject.transform.position;// obtener posicion del cubo contra el cual colisiona
            particulas.position = posicion; // ubica las particulas en la posicion del cubo
            systemaParticulas = particulas.GetComponent<ParticleSystem>();
            systemaParticulas.Play();

            Destroy(other.gameObject);
            audioRecoleccion.Play();
        }

        if (other.gameObject.CompareTag("RecolectableF"))
        
        {
            score = score - 5;
            Debug.Log("Pierdes 5 puntos ");
            Debug.Log("Puntaje: "+ score);

            posicionF = other.gameObject.transform.position;// obtener posicion del cubo contra el cual colisiona
            particulasF.position = posicionF; // ubica las particulas en la posicion del cubo
            systemaParticulasF = particulasF.GetComponent<ParticleSystem>();
            systemaParticulasF.Play();


            Destroy(other.gameObject);
            audioRecoleccionF.Play();
        }

        if (other.gameObject.CompareTag("Mud") )
        {
            enterrado = true;

            // Mueve al jugador hacia abajo (enterrado) usando posición absoluta
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + profundidadEnterrado,
                transform.position.z
            );

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
            // Mueve al jugador hacia abajo (enterrado) usando posición absoluta
            transform.position = new Vector3(
                transform.position.x + profundidadEnterrado,
                transform.position.y,
                transform.position.z
            );

            // Detiene el Rigidbody
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true; // Evita que se mueva por física


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
            if(other.gameObject.CompareTag("Bushes")){
                
                paredes.Play();
            }

}
void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Bushes"))
        {
            paredes.Play();
        }
}
}
