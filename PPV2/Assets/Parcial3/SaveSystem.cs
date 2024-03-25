using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class SaveSystem : MonoBehaviour
{
    //Se empieza a declarar Singulton
    public static SaveSystem instance;

    //variables a las cuales nos vamos a referir 
    public Leccion data;
    public SubjectContainer subject;

    //El Singulton es un patron de diseño encargado de crear una instancia de la clase sin necesidad de crear una variable 
    private void Awake ()
    {
        if (instance != null)
        {
            return;
        }
        else 
        {
            instance = this;
        }

    }

    // El contenido de Start se leé primero
    private void Start()
    {
        SaveToJSON("LeccionDummy", data);

        subject = LoadFromJSON<SubjectContainer>("SubjectDummy");
    }

    ///<summary>
    ///Esta funcion esta encargada de almacenar objetos en archivos JSON
    ///</summary>
    ///<param name="_fileName"></param>
    ///<param name="_data"></param>

    //Creamos las funciones a las cuales nos referiremos
    public void SaveToJSON(string _fileName, object _data) 
    {
        if (_data != null) 
        {
            string JSONData = JsonUtility.ToJson(_data, true);
            if (JSONData.Length != 0)
            {
                Debug.Log("JSON STRING: " + JSONData);
                //Declaramos nombre del archivo
                string fileName = _fileName + ".json";
                //Llamamos a la carpeta JSONS de la siguiente manera "/Resousers/JSONS/"
                string filePath = Path.Combine(Application.dataPath + "/Resoures/JSONS/", fileName);

                File.WriteAllText(filePath, JSONData);
                //Se regresa mensaje 
                Debug.Log("JSON almacenado en la direccion: " + filePath);
            }
            else 
            {
                //Damos un mensaje que el Dato esta vacio 
                Debug.LogWarning("ERROR - FileSystem: JSONData is empty, check for local variable [string JSONData]");
            }
        }
             else
             {
            //Mandamos un mensaje que el dato es nulo 
                Debug.LogWarning("ERROR - fileSystem: _data is null, check for param [object _data]");
             }
    }
    //Funcion de retorno tipo T
    public T LoadFromJSON<T>(string _fileName) where T : new() 
    {
        T Dato = new T();
        //Se lllama a la carpeta
        string path = Application.dataPath + "/Resources/JSONS/" + _fileName + "_json";
        string JSONData = "";
        //Declaramos la existencia 
        if (File.Exists(path)) 
        {
            JSONData = File.ReadAllText(path);
            //Damos mensaje del nombre 
            Debug.Log("JSON STRING: " + JSONData);
        }
        if (JSONData.Length != 0)
        {
            JsonUtility.FromJsonOverwrite(JSONData, Dato);
        }
        else 
        {
            //Damos un mensaje que el Dato esta vacio y que se verifique la varible local
            Debug.LogWarning("ERROR - FileSystem: JSONData is empty, check for local variable [string JSONData]");
        }
        return Dato;
    }
}
