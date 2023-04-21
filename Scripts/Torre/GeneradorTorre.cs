using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorTorre : MonoBehaviour
{
    public int altura = 5; // La altura de la torre en cubos
    public int anchoBase = 5; // El ancho de la base de la torre en cubos
    public int anchoSuperior = 3; // El ancho de la parte superior de la torre en cubos
    public Material rojoMaterial;
    public GameObject cuboPrefab; // El prefab del cubo que se utilizará para construir la torre

    void Start()
    {
        GameObject instancia=Instantiate(cuboPrefab, transform.position+ new Vector3(10,10,10) , Quaternion.identity, transform);
        
        instancia.transform.localScale=new Vector3(1,1,2);
        instancia.GetComponent<Renderer>().material = rojoMaterial;
        
        /*// Generar la torre
        for (int y = 0; y < altura; y++)
        {
            int anchoActual = Mathf.RoundToInt(Mathf.Lerp(anchoBase, anchoSuperior, (float)y / altura));

            for (int x = 0; x < anchoActual; x++)
            {
                for (int z = 0; z < anchoActual; z++)
                {
                    // Crear un nuevo cubo en la posición correspondiente
                    Vector3 posicion = new Vector3(x - anchoActual / 2f + 0.5f, y, z - anchoActual / 2f + 0.5f);
                    Instantiate(cuboPrefab, transform.position + posicion, Quaternion.identity, transform);
                }
            }
        }
        */
    }
}