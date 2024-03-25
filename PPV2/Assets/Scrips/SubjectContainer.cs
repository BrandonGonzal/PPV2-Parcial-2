using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //Se usa para hacer que las variables  privadas sean accesibles dentro del editor Sin hacerlas publicas
 [System.Serializable]

//SubjectContainer se encargara de leer lo que se encuentra dentro de Json como Preguntas, Respuestas, ID, etc.
public class SubjectContainer 
{
    //Esta es la lección
    [Header("GameObject Configuration")]
    [SerializeField]
    public int Lesson = 0;

    //Esta es la lista de la lección
    [Header("Lession Quest Configuration")]
    [SerializeField]
     public List<Leccion>leccionList;
}
