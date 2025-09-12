using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotadorF : MonoBehaviour

{

public Transform particulas;
private ParticleSystem systemaParticulas;
private Vector3 posicion;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
      transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }

}
