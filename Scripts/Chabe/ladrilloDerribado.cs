using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    public int wallWidth = 5;
    public int wallHeight = 5;
    public float cubeWidth = 1f;
    public float cubeHeight = 1f;
    public float cubeDepth = 1f;

    private int cubesLeft;

    void Start()
    {
        cubesLeft = wallWidth * wallHeight;

        Vector3 cubeScale = new Vector3(cubeWidth, cubeHeight, cubeDepth);

        for (int x = 0; x < wallWidth; x++)
        {
            for (int y = 0; y < wallHeight; y++)
            {
                GameObject cube = Instantiate(cubePrefab);
                cube.transform.position = new Vector3(x * cubeWidth, y * cubeHeight, 0);
                cube.transform.localScale = cubeScale;
                cube.transform.parent = transform;

                // Agregar el componente RigidBody a cada cubo
                Rigidbody rigidbody = cube.AddComponent<Rigidbody>();
                rigidbody.useGravity = false;
                rigidbody.isKinematic = true;

                // Agregar un collider a cada cubo
                BoxCollider collider = cube.AddComponent<BoxCollider>();
                collider.size = cubeScale;

                // Agregar un script para detectar colisiones
                cube.AddComponent<CubeController>();
            }
        }

        // Agregar un collider al plano horizontal
        GameObject plane = new GameObject("Plane");
        plane.transform.parent = transform;
        plane.transform.position = new Vector3(wallWidth * cubeWidth / 2f, -cubeHeight / 2f, 0);
        BoxCollider planeCollider = plane.AddComponent<BoxCollider>();
        planeCollider.size = new Vector3(wallWidth * cubeWidth, 0.1f, cubeDepth);
    }

    // Función que se llama cuando un cubo es derribado
    public void CubeDestroyed()
    {
        cubesLeft--;

        if (cubesLeft <= 0)
        {
            Debug.Log("¡Todos los cubos han sido derribados!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class CubeController : MonoBehaviour
{
    private bool isDestroyed = false;
    private WallGenerator wallGenerator;

    void Start()
    {
        wallGenerator = transform.parent.GetComponent<WallGenerator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isDestroyed && collision.gameObject.CompareTag("Projectile"))
        {
            isDestroyed = true;
            Destroy(gameObject);
            wallGenerator.CubeDestroyed();
        }
    }
}
