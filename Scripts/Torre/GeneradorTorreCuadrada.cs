using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GeneradorTorreCuadrada : MonoBehaviour
{
     public int altura = 20; // La altura de la torre en cubos
     public int anchoX = 6; // El ancho de la base de la torre en cubos
     public int anchoZ = 6; // El ancho de la parte superior de la torre en cubos
     public bool rigid =true;
      int contadorLadrillos = 0;
     float inicioX ;
     float inicioZ;
    public GameObject imageTarget;

    private void rigido(GameObject objeto){
         if (rigid){
             objeto.AddComponent<Rigidbody>();
         }
     }
    

    private void dimensionesCarta()
    {
        Renderer targetRenderer = imageTarget.GetComponent<Renderer>();
        if (targetRenderer != null)
        {
            Vector3 targetSize = targetRenderer.bounds.size;
            Debug.Log("Las dimensiones del Image Target son: " + targetSize);
        }
    }

    public void construirTorre()
    {
        GameObject plano = GameObject.CreatePrimitive(PrimitiveType.Plane);  
        plano.transform.localScale = new Vector3(anchoX, 1f, anchoZ);
        inicioX =transform.position.x;
         inicioZ=transform.position.z;
        
        for(int i =0;i<altura;i++){
           
            for (int j = 0; j < 4; j++)
            {
                hilera(i,j);
                
            }
        }
        Debug.Log("Numero de Ladrillos "+contadorLadrillos);
        dimensionesCarta();
    }
    private void hilera(int alturaActual, int tipo )
    {
        int ancho;
        if (tipo%2 ==0)
        {
            ancho = anchoX;
        }else
        {
            ancho = anchoZ;
        }
        for (int i = 0; i < ancho; i++)
        {
            GameObject ladrillo = cuboPrimitivo();
            contadorLadrillos++;
            escalarALadrillo(ladrillo,tipo);
            posicionarLadrillo(ladrillo, i, alturaActual, tipo);
            nombrarLadrillo(ladrillo, tipo, i, alturaActual);
            rigido(ladrillo);
            colorearLadrillo(ladrillo);
        }
    }
   private GameObject cuboPrimitivo()
    {
        return GameObject.CreatePrimitive(PrimitiveType.Cube);
    }
    
    private void escalarALadrillo(GameObject ladrillo, int tipo)
    {
        if (tipo % 2 == 0)
        {
            ladrillo.transform.localScale = new Vector3(2, 1, 1);
        }
        else
        {
            ladrillo.transform.localScale = new Vector3(1, 1, 2);
        }

    }
    private void posicionarLadrillo(GameObject ladrillo, int recorrido, int alturaActual, int tipo)
    {
        float desnivelSuelo = 0.5f;
        float alturaY=0;
        float posicionX=0;
        float posicionZ=0;
        if (tipo == 0)
        {
            float desajusteDeHilera = alturaActual % 2;
            
             alturaY = alturaActual + desnivelSuelo;
             posicionX = inicioX + 0.5f + recorrido * 2 + desajusteDeHilera;
             posicionZ = inicioZ;
             ladrillo.transform.position = new Vector3(posicionX, alturaY, posicionZ);

        }else if(tipo == 1)
        {
            posicionX = inicioX;
            alturaY = alturaActual + desnivelSuelo;
            posicionZ = recorrido * 2 - alturaActual % 2 + 1 + desnivelSuelo + inicioZ;
            
            ladrillo.transform.position = new Vector3(posicionX, alturaY, posicionZ);
        }
        else if(tipo == 2)
        {
            posicionX = inicioX + 0.5f + recorrido * 2 + (alturaActual + 1) % 2;
            alturaY = alturaActual + desnivelSuelo;
            posicionZ = inicioZ + anchoZ * 2;
            
            ladrillo.transform.position = new Vector3(posicionX, alturaY, posicionZ);
        }
        else if (tipo == 3)
        {
           
            posicionX = inicioX + anchoX * 2;
            alturaY = alturaActual + desnivelSuelo;
            posicionZ = recorrido * 2 + alturaActual % 2 + desnivelSuelo + inicioZ;
            
            ladrillo.transform.position = new Vector3(posicionX, alturaY, posicionZ);
        }
        
    }
    
    private void colorearLadrillo(GameObject ladrillo)
    {
        Renderer renderer = ladrillo.GetComponent<Renderer>();
        // Asigna el nuevo material al objeto
        renderer.material = materialRandom();
    }

    
    
    
    private void nombrarLadrillo(GameObject ladrillo,int tipo, int recorrido, int alturaActual)
    {
        ladrillo.name = "Ladrillo"+tipo+'A'+alturaActual+'R'+recorrido;
    }
    
    private Material materialRandom(){
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
    






