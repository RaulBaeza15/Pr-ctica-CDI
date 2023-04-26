using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorTorre : MonoBehaviour
{
     public int altura = 5; // La altura de la torre en cubos
     public int anchoX = 5; // El ancho de la base de la torre en cubos
     public int anchoZ = 3; // El ancho de la parte superior de la torre en cubos
     public bool rigid =false;
     public float salto = 0.5f;
     float inicioX ;
     float inicioZ;
     
     private void rigido(GameObject objeto){
         if (rigid){
             objeto.AddComponent<Rigidbody>();
         }
     } 

     void Start() {   
         inicioX =transform.position.x;
         inicioZ=transform.position.z;
        
        for(int i =0;i<altura;i++){
             
             hiladaX(i);
             hiladaZ(i);
             hiladaXPared(i);
             hiladaZPared(i);
             
        }

        
        
        //instancia2.GetComponent<Renderer>().material = rojoMaterial;
        
    }
   
    private void hiladaX(int alturaActual){
        float desajusteCubo=0.5f;
        

        for(int i =0;i<anchoX;i++){

             GameObject ladrilloX =GameObject.CreatePrimitive(PrimitiveType.Cube);

             ladrilloX.transform.localScale=new Vector3(2,1,1);
             
             ladrilloX.transform.position=new Vector3(inicioX+desajusteCubo+i*2+alturaActual%2,alturaActual+salto,inicioZ+0);
             ladrilloX.name="LadrilloX"+i+'_'+alturaActual;
             rigido(ladrilloX);
             
             

             Renderer renderer = ladrilloX.GetComponent<Renderer>();
             // Asigna el nuevo material al objeto
             renderer.material = materialRandom();

             
        }
        

    }
    private void hiladaXPared(int alturaActual){
        float desajusteCubo=0.5f;
        

        
        for(int i =0;i<anchoX;i++){

             GameObject ladrilloX =GameObject.CreatePrimitive(PrimitiveType.Cube);

             ladrilloX.transform.localScale=new Vector3(2,1,1);
             
             ladrilloX.transform.position=new Vector3(inicioX+desajusteCubo+i*2+(alturaActual+1)%2,alturaActual+salto,inicioZ+anchoZ*2);
             ladrilloX.name="LadrilloXPared"+i+'_'+alturaActual;
             rigido(ladrilloX);
             Renderer renderer = ladrilloX.GetComponent<Renderer>();
             // Asigna el nuevo material al objeto
             renderer.material = materialRandom();

        
             
        }

    }
   
    private void hiladaZ(int alturaActual){
        float desajusteCubo=0.5f;

        for(int i =0;i<anchoZ;i++){

             GameObject ladrilloZ =GameObject.CreatePrimitive(PrimitiveType.Cube);

             ladrilloZ.transform.localScale=new Vector3(1,1,2);
             ladrilloZ.transform.position=new Vector3(inicioX+0,alturaActual+salto,i*2-alturaActual%2+1+desajusteCubo+inicioZ);
             ladrilloZ.name="LadrilloZ"+i+'_'+alturaActual;
             rigido(ladrilloZ);

             Renderer renderer = ladrilloZ.GetComponent<Renderer>();
             // Asigna el nuevo material al objeto
             renderer.material = materialRandom();
        }
        

    }
    private void hiladaZPared(int alturaActual){
        float desajusteCubo=0.5f;

    
        for(int i =0;i<anchoZ;i++){

             GameObject ladrilloZ =GameObject.CreatePrimitive(PrimitiveType.Cube);

             ladrilloZ.transform.localScale=new Vector3(1,1,2);
             ladrilloZ.transform.position=new Vector3(inicioX+anchoX*2,alturaActual+salto,i*2+alturaActual%2+desajusteCubo+inicioZ);
             ladrilloZ.name="LadrilloZPared"+i+'_'+alturaActual;
             rigido(ladrilloZ);
             
             Renderer renderer = ladrilloZ.GetComponent<Renderer>();
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
    






