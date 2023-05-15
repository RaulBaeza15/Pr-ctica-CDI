using UnityEngine;
using System.Collections;
using UnityEngine.UI;
<<<<<<< HEAD
using TMPro;
=======
>>>>>>> refs/remotes/origin/main


public class LanzadorDePelota : MonoBehaviour
{
    
    public GameObject puntoDeLanzamiento;
    public float fuerzaLanzamiento = 100f;
    public float tiempoDeVida = 10f;
    public int cuentaPelotas =0;
<<<<<<< HEAD
    public TextMeshProUGUI contadorPelotasText;
    public TextMeshProUGUI contadorFinal;


    void start()
    {
        contadorPelotasText.text = "0";
    }
=======
    public Text contadorPelotasText;
>>>>>>> refs/remotes/origin/main

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LanzarPelota();
        }
<<<<<<< HEAD
        contadorPelotasText.text = cuentaPelotas.ToString();
        contadorFinal.text = contadorPelotasText.text;
=======
        contadorPelotasText.text = "Pelotas: " + cuentaPelotas.ToString();
>>>>>>> refs/remotes/origin/main
    }

    public void LanzarPelota()
    {
        GameObject pelota = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        cuentaPelotas++;
        //pelota.transform.parent = parentObject; // establece el padre del objeto creado
        pelota.AddComponent<Rigidbody>();

        Rigidbody pelotaRigidbody = pelota.GetComponent<Rigidbody>();
        Renderer renderer = pelota.GetComponent<Renderer>();
        // Asigna el nuevo material al objeto
        renderer.material = materialRandom();
        pelota.transform.localScale *= 2;
        pelota.transform.position=puntoDeLanzamiento.transform.position;
        StartCoroutine(DestruirDespuesDeTiempo(pelota));
        if (pelotaRigidbody != null)
        {
            pelotaRigidbody.AddForce(puntoDeLanzamiento.transform.forward * fuerzaLanzamiento, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("El objeto de la pelota no tiene un componente Rigidbody.");
        }
    }
    private IEnumerator DestruirDespuesDeTiempo(GameObject pelota)
    {
        yield return new WaitForSeconds(tiempoDeVida);
        Destroy(pelota);
    }
    private Material materialRandom()
    {
        // Crea un nuevo material
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);

        Material newMaterial = new Material(Shader.Find("Standard"));

        // Configura los valores RGB del material
        newMaterial.color = new Color(r, g, b);
        return newMaterial;
    }
}
