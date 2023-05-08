using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorTorreCuadrada : MonoBehaviour
{
     public int altura = 20; // La altura de la torre en cubos
     public int anchoX = 6; // El ancho de la base de la torre en cubos
     public int anchoZ = 6; // El ancho de la parte superior de la torre en cubos
     public bool rigid =true;
     float salto = 0.5f;
     float inicioX ;
     float inicioZ;
     

     private void rigido(GameObject objeto){
         if (rigid){
             objeto.AddComponent<Rigidbody>();
         }
     } 

     
    public void construirTorre()
    {
        GameObject plano = GameObject.CreatePrimitive(PrimitiveType.Plane);  
        plano.transform.localScale = new Vector3(anchoX, 1f, anchoZ);
        inicioX =transform.position.x;
         inicioZ=transform.position.z;
        
        for(int i =0;i<altura;i++){
             
             hiladaX(i);
             hiladaZ(i);
            hiladaXPared(i);
             hiladaZPared(i);

        }
    }
   private GameObject cuboPrimitivo()
    {
        return GameObject.CreatePrimitive(PrimitiveType.Cube);
    }
    private void escalarALadrilloX(GameObject ladrillo)
    {
        ladrillo.transform.localScale = new Vector3(2, 1, 1);
    }
    private void escalarALadrilloZ(GameObject ladrillo)
    {
        ladrillo.transform.localScale = new Vector3(1, 1, 2);
    }
    private void posicionarLadrillo(GameObject ladrillo, int recorrido, int alturaActual)
    {
        float desajusteDeHilera = alturaActual % 2;
        float desnivelSuelo = 0.5f;
        float altura = alturaActual + desnivelSuelo;
        float posicionX = inicioX + 0.5f + recorrido * 2 + desajusteDeHilera;
        float posicionZ = inicioZ;
        ladrillo.transform.position = new Vector3(posicionX, altura, posicionZ);
        
    }
    
    private void colorearLadrillo(GameObject ladrillo)
    {
        Renderer renderer = ladrillo.GetComponent<Renderer>();
        // Asigna el nuevo material al objeto
        renderer.material = materialRandom();
    }

    private void hiladaX(int alturaActual){   
        for(int i =0;i<anchoX;i++){
             GameObject ladrilloX = cuboPrimitivo();
             escalarALadrilloX(ladrilloX);            
             posicionarLadrillo(ladrilloX, i, alturaActual);            
             nombrarLadrillo(ladrilloX, "X", "1", i, alturaActual);
             rigido(ladrilloX);                     
             colorearLadrillo( ladrilloX);
        }    
    }
    
    private void hiladaXPared(int alturaActual){
        float desajusteCubo=0.5f;
        
        for(int i =0;i<anchoX;i++){

             GameObject ladrilloX = cuboPrimitivo();
             escalarALadrilloX(ladrilloX);
             
             ladrilloX.transform.position=new Vector3(inicioX+desajusteCubo+i*2+(alturaActual+1)%2,alturaActual+salto,inicioZ+anchoZ*2);
             
             nombrarLadrillo(ladrilloX, "X", "2", i, alturaActual);
             rigido(ladrilloX);
             colorearLadrillo(ladrilloX);



        }

    }
   
    private void hiladaZ(int alturaActual){
        float desajusteCubo=0.5f;
        for(int i =0;i<anchoZ;i++){
             GameObject ladrilloZ = cuboPrimitivo();
             escalarALadrilloZ(ladrilloZ);
             ladrilloZ.transform.position=new Vector3(inicioX+0,alturaActual+salto,i*2-alturaActual%2+1+desajusteCubo+inicioZ);
             nombrarLadrillo(ladrilloZ, "Z", "1", i, alturaActual);
             rigido(ladrilloZ);
             colorearLadrillo(ladrilloZ);
        }
        

    }
    private void nombrarLadrillo(GameObject ladrillo,string eje, string pared, int recorrido, int alturaActual)
    {
        ladrillo.name = "Ladrillo"+eje+'P'+pared+'A'+alturaActual+'R'+recorrido;
    }
    private void hiladaZPared(int alturaActual){
        float desajusteCubo=0.5f;

    
        for(int i =0;i<anchoZ;i++){

             GameObject ladrilloZ = cuboPrimitivo();
             escalarALadrilloZ(ladrilloZ);
            ladrilloZ.transform.position=new Vector3(inicioX+anchoX*2,alturaActual+salto,i*2+alturaActual%2+desajusteCubo+inicioZ);
           
            nombrarLadrillo(ladrilloZ, "Z","2",i, alturaActual);
             rigido(ladrilloZ);

             colorearLadrillo(ladrilloZ);
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
    






