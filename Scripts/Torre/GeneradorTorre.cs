using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using TMPro;

public class GeneradorTorre : MonoBehaviour
{
     public int altura = 20; // La altura de la torre en cubos
     public int anchoX = 6; // El ancho de la base de la torre en cubos
     public int anchoZ = 6; // El ancho de la parte superior de la torre en cubos
     public bool cuadrada = true;
     public bool rigid =true;
     bool PreviamenteConstruido=false;
      int contadorLadrillos = 0;
     float inicioX ;
     float inicioZ;
     public Transform carta;
     public int porcentaje = 90;
    public Transform Papa;
    public GameObject pantallaFinal;
    public ControladorEventos eventos;

    public InvisibleTrigger ScriptTrigger;
    public TextMeshProUGUI PorcentajeDerribos;
    public TextMeshProUGUI PorcentajeFinal;
    private LanzadorDePelota pelotas;

    void start(){
        PorcentajeDerribos.text = "0";
        bool torre = eventos.botonSeleccion;
        porcentaje = int.Parse(eventos.porcentaje.text);
        if(torre){
            anchoX = int.Parse(eventos.CLado.text);
            anchoX = anchoZ;
            altura = int.Parse(eventos.CAltura.text);
        }  
        else{
            altura = int.Parse(eventos.RAltura.text);
            anchoX = int.Parse(eventos.RLado1.text);
            anchoZ = int.Parse(eventos.RLado2.text);

        }
        
    }

    private void rigido(GameObject objeto){
         if (rigid){
             objeto.AddComponent<Rigidbody>();
         }
    }
    

   


    public void construirTorre()
    {   
        if (!PreviamenteConstruido){
            PreviamenteConstruido=true;
            
            GameObject plano = cuboPrimitivo();
            plano.transform.localScale = new Vector3(2*anchoX+2, 1f, 2*anchoZ+2);
            plano.transform.position=carta.position;
            plano.transform.position = new Vector3(plano.transform.position.x-1, -0.5f, plano.transform.position.z-1);
            plano.transform.SetParent(Papa);
            MeshRenderer meshRenderer = plano.GetComponent<MeshRenderer>();

            // Obtener el tamaño del plano (ancho y largo) en unidades del mundo
            Vector3 planoTamano = meshRenderer.bounds.size;

            // Obtener la posición del centro del plano en el mundo
            Vector3 planoPosicion = transform.position;

            // Calcular la esquina inferior izquierda del plano
            Vector3 esquinaInferiorIzquierda = planoPosicion - new Vector3(planoTamano.x / 2, 0, planoTamano.z / 2);

            
            inicioX =carta.position.x;
            inicioZ=carta.position.z;
            inicioX =esquinaInferiorIzquierda.x;
            inicioZ=esquinaInferiorIzquierda.z;
            
            for(int i =0;i<altura;i++){
            
                for (int j = 0; j < 4; j++)
                {
                    hilera(i,j);
                    
                }
            }
            Debug.Log("Numero de Ladrillos "+contadorLadrillos);
        }
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
            ladrillo.transform.SetParent(Papa);
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
    void Update()
    {
    if (ScriptTrigger != null && PorcentajeDerribos != null)
        {
        int derribados = ScriptTrigger.cuentaLadrillos;
        float contador = (derribados / contadorLadrillos)*100;
        PorcentajeDerribos.text = contador.ToString();
        if(contador >= porcentaje){
            PorcentajeFinal.text = PorcentajeDerribos.text;
            pantallaFinal.SetActive(true);
            PorcentajeDerribos.enabled = false;
            PorcentajeFinal.enabled = true;
            pelotas.contadorPelotasText.enabled = false;
            pelotas.contadorFinal.enabled =true;
        }
        }
    }



}