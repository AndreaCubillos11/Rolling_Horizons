using UnityEngine;
using System.Collections.Generic;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private Vector3 posicionOriginal;
    private int score = 0;
    public AudioSource paredes;
    public AudioSource audioRecoleccion;
    public AudioSource audioRecoleccionF;
    public Transform particulas;
    private ParticleSystem systemaParticulas; 
    private Vector3 posicion; 

    public Transform particulasC;
    private ParticleSystem systemaParticulasC; 
    private Vector3 posicionC; 



    void Start()
    {

        rb = GetComponent<Rigidbody>();

        posicionOriginal = transform.position; // Guarda la posición inicial

        systemaParticulas = particulas.GetComponent<ParticleSystem>();

        systemaParticulas.Stop();


        systemaParticulasC = particulasC.GetComponent<ParticleSystem>();

        systemaParticulasC.Stop();


        
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
        if (other.gameObject.CompareTag("Recolectable"))
        
        {
            score = score + 10;
            Debug.Log("Ganas 10 puntos");
            Debug.Log("Puntaje: "+ score);

            posicion = other.gameObject.transform.position;// obtener posicion del cubo contra el cual colisiona
            particulas.position = new Vector3(posicion.x, posicion.y-0.5f, posicion.z); // ubica las particulas en la posicion del cubo
            systemaParticulas = particulas.GetComponent<ParticleSystem>();
            systemaParticulas.Play();

            Destroy(other.gameObject);
            audioRecoleccion.Play();
        }
        if (other.gameObject.CompareTag("BadCoin"))
        
        {
            score = score - 5;
            Debug.Log("Pierdes 5 puntos ");
            Debug.Log("Puntaje: "+ score);

            posicionC = other.gameObject.transform.position;// obtener posicion del cubo contra el cual colisiona
            particulasC.position = new Vector3(posicionC.x, posicionC.y-0.5f, posicionC.z); // ubica las particulas en la posicion del cubo
            systemaParticulasC = particulasC.GetComponent<ParticleSystem>();
            systemaParticulasC.Play();


            Destroy(other.gameObject);
            audioRecoleccionF.Play();
        }


    }
void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Walls"))
        {

        paredes.Play();

        }
}
}
