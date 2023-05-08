using UnityEngine;

public class LanzadorDePelota : MonoBehaviour
{
    public GameObject pelotaPrefab;
    public GameObject puntoDeLanzamiento;
    public float fuerzaLanzamiento = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LanzarPelota();
        }
    }

    void LanzarPelota()
    {
        GameObject pelota = Instantiate(pelotaPrefab, puntoDeLanzamiento.transform.position, puntoDeLanzamiento.transform.rotation);
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
