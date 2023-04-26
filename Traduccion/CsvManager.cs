using System.IO;
using UnityEngine;

public class CsvManager : MonoBehaviour
{
    public TextAsset csvFile; // Archivo CSV en la carpeta "Assets/Resources"
    string[,] csvData;

    void Start()
    {
        // Leer el contenido del archivo CSV
        string csvContent = csvFile.text;

        // Dividir el contenido del archivo CSV en líneas
        string[] lines = csvContent.Split('\n');

        // Crear una matriz de dos dimensiones para almacenar los datos del archivo CSV
         csvData = new string[lines.Length, lines[0].Split(';').Length];

        // Leer las líneas del archivo CSV una por una y almacenar los datos en la matriz
        for (int i = 0; i < lines.Length; i++)
        {
            string[] cells = lines[i].Split(';'); // Separar las celdas por coma (puedes cambiar ',' por otro separador si lo necesitas)

            for (int j = 0; j < cells.Length; j++)
            {
                csvData[i, j] = cells[j];
            }
        }

        // Acceder a los datos de la matriz
        Debug.Log("Fila 1, Columna 2: " + csvData[0, 1]);
    }
    public void español(){

    }
}


