using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestRainbow : MonoBehaviour
{

    public Transform particulas;
    private ParticleSystem systemaParticulas; 
    private Vector3 posicion; 
    private float tiempo = 0f;
    private bool contando= false;  
    public GameObject mensajeCanvas; 

    // Start is called before the first frame update
    void Start()
    {
        systemaParticulas = particulas.GetComponent<ParticleSystem>();

        systemaParticulas.Stop();

        contando=true; 

        //Se oculta el Canvas
        if (mensajeCanvas != null)
        {
            mensajeCanvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(contando){
        
        tiempo += Time.deltaTime; 

        }
    }

    void OnTriggerEnter(Collider other){

        if(other.CompareTag("Player")){

            contando= false; 

            Debug.Log($"[Contador] Finalizado en: {tiempo:F2} segundos");

            posicion = other.gameObject.transform.position;
            particulas.position = new Vector3(posicion.x, posicion.y, posicion.z); // ubica las particulas en la posicion del cubo
            systemaParticulas = particulas.GetComponent<ParticleSystem>();
            systemaParticulas.Play();

            Rigidbody rb = other.attachedRigidbody;

    
            if (rb != null)
            {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            }

            if (mensajeCanvas != null)
            {
                mensajeCanvas.SetActive(true); 
            }
            
        }
    }
}
