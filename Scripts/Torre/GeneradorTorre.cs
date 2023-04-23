using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorTorre : MonoBehaviour
{
    public int altura = 5; // La altura de la torre en cubos
    public int anchoX = 5; // El ancho de la base de la torre en cubos
    public int anchoZ = 3; // El ancho de la parte superior de la torre en cubos
    public Material rojoMaterial;
    public GameObject cuboPrefab; // El prefab del cubo que se utilizará para construir la torre

    void Start()
    {   
        GameObject ladrilloZ= Instantiate (cuboPrefab);
        
        ladrilloZ.transform.localScale=new Vector3(1,1,2);
        
        ladrilloZ.transform.position=new Vector3(-5,1,5);
        
        hiladaX(0);
        
        //instancia2.GetComponent<Renderer>().material = rojoMaterial;
        
    }
    private void hiladaX(int alturaActual){
        GameObject ladrilloX= Instantiate (cuboPrefab);
        ladrilloX.transform.localScale=new Vector3(2,1,1);
        ladrilloX.transform.position=new Vector3(5,1+alturaActual,5);

        for(int i =1;i<anchoX;i++){
             GameObject amor =Instantiate(ladrilloX, ladrilloX.transform.position + new Vector3(i*2, 0, 0), Quaternion.identity);
             amor.name="X"+i+'_'+alturaActual;

             Renderer renderer = amor.GetComponent<Renderer>();

             

             // Asigna el nuevo material al objeto
             renderer.material = materialRandom();
        }

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
    






/*
        for (int y = 0; y < altura; y++)
        {
            // Generar la torre
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