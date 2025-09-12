using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionPortal : MonoBehaviour
{
    // Start is called before the first frame update

    private float tiempo = 0f;
    private bool contando = false;
  
    void Start()
    {
        contando = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (contando)
        {
            tiempo += Time.deltaTime; // acumula tiempo en segundos
        }

    } 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            contando = false;
        Debug.Log($"[Contador] Finalizado en: {tiempo:F2} segundos");
        SceneManager.LoadScene(1);
        }
    }
}