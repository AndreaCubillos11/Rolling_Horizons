using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivator : MonoBehaviour
{

    public GameObject jaula; 
    public Transform platoCentro; 



    // Start is called before the first frame update
    void Start()
    {
        if(jaula!= null){

            jaula.SetActive (false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
    
        // Centro dinámico del collider
        Vector3 centroTapete = GetComponent<Collider>().bounds.center;
        other.transform.position = centroTapete;
        Rigidbody rb = other.attachedRigidbody;

        jaula.SetActive(true);
        jaula.transform.position = new Vector3(transform.position.x, transform.position.y-0.2f , transform.position.z);

        
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }
        Debug.Log("¡Haz quedado atrapado!");
    }
}

}
