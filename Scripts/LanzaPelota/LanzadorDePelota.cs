using UnityEngine;

public class LanzadorDePelota : MonoBehaviour
{
    
    public GameObject puntoDeLanzamiento;
    public float fuerzaLanzamiento = 10f;
    public Transform parentObject;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LanzarPelota();
        }
    }

    void LanzarPelota()
    {
        GameObject pelota = Instantiate(spherePrefab, transform.position, Quaternion.identity);
    }
    Rigidbody pelotaRigidbody = pelota.GetComponent<Rigidbody>();

        if (pelotaRigidbody != null)
        {
            pelotaRigidbody.AddForce(puntoDeLanzamiento.transform.forward * fuerzaLanzamiento, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("El objeto de la pelota no tiene un componente Rigidbody.");
        }
    }
}
