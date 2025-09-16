using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private Rigidbody rb;
    private bool hasFallen = false;
    public GameObject player;
    private Rigidbody rbPlayer;
    // Altura del piso (donde debe quedar el mazo apoyado)
    public float alturaSuelo = -0.492f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        rbPlayer= player.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasFallen)
        {
            Debug.Log("¡Te ha aplastado el mazo!");

            // Obtener la altura real del mazo desde su collider
            float altoMazo = GetComponent<Collider>().bounds.size.y;

            // Ajustar posición final para que apoye sobre el piso
            transform.position = new Vector3(
                transform.position.x, 
                alturaSuelo + (altoMazo / 2f), 
                transform.position.z
            );

            // Rotación final (acostado en el piso)
            transform.rotation = Quaternion.Euler(30f, 0f, 0f);
            // Detiene el Rigidbody
            rbPlayer.velocity = Vector3.zero;
            rbPlayer.angularVelocity = Vector3.zero;
            rbPlayer.isKinematic = true; // Evita que se mueva por física

        

            hasFallen = true;
        }
    }
}
