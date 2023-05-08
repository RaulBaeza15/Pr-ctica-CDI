using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Acciones cuando otro objeto entra en el trigger invisible
        Debug.Log("Entró en el trigger invisible: " + other.name);
        GameObject collidedObject = other.gameObject;
        Destroy(collidedObject);
    }

    private void OnTriggerExit(Collider other)
    {
        // Acciones cuando otro objeto sale del trigger invisible
        //Debug.Log("Salió del trigger invisible: " + other.name);
    }

    private void OnTriggerStay(Collider other)
    {
        // Acciones mientras otro objeto está en el trigger invisible
        //Debug.Log("Permanece en el trigger invisible: " + other.name);
    }
}


