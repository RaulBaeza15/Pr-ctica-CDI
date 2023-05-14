using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTrigger : MonoBehaviour
{
    public int cuentaLadrillos = 0;
    public int getCuentaLadrillos()
    {
        return cuentaLadrillos;
    }
    public void sumaLadrillo()
    {
        cuentaLadrillos++;  
    }
    private void OnTriggerEnter(Collider other)
    {
        // Acciones cuando otro objeto entra en el trigger invisible
        
        GameObject collidedObject = other.gameObject;
        MeshFilter meshFilter = collidedObject.GetComponent<MeshFilter>();

        // Comprobar si la malla asociada es un cubo
        if (meshFilter != null && meshFilter.mesh != null && meshFilter.mesh.name == "Cube Instance")
        {
            
            sumaLadrillo();
        }
        else
        {
            //Debug.Log("El GameObject no es un cubo.\nEs un "+ meshFilter.mesh.name);
        }
        Destroy(collidedObject);
    }

    private void OnTriggerExit(Collider other)
    {
        // Acciones cuando otro objeto sale del trigger invisible
        //Debug.Log("Sali� del trigger invisible: " + other.name);
    }

    private void OnTriggerStay(Collider other)
    {
        // Acciones mientras otro objeto est� en el trigger invisible
        //Debug.Log("Permanece en el trigger invisible: " + other.name);
    }
}


