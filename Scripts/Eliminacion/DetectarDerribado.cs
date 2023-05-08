using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarDerribado : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        cubos();


    }
    public void cubos()
    {
        GameObject[] cubos = FindObjectsOfType<GameObject>();
        Debug.Log("Los Cubos:\n");
        foreach (GameObject cubo in cubos)
        {
            MeshRenderer renderer = cubo.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                // Este Game Object es un cubo, realiza las operaciones deseadas aquí
                Debug.Log("Encontré un cubo: " + cubo.name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
