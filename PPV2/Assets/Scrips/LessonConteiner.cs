using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LessonConteiner : MonoBehaviour
{
    [Header("GameObject Configuration")]
    public int Lection = 0;
    public int CurrentLession = 0;
    public int TotalLessions = 0;
    public bool AreAllLessonsComplete = false;

    [Header("UI Configuration")]
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;

    [Header("External GameObject Configuration")]
    public GameObject lessonContainer; 

    [Header("Lesson Data")]
    public ScriptableObject LessonData;

    // Start is called before the first frame update
    void Start()
    {
        if (lessonContainer != null)
        {
            OnUpdateUI();
        }
        else 
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo GameObject lessonContainer"); 
        }
        
    }
    public void OnUpdateUI()
    {
        if (StageTitle.text != null || LessonStage != null)
        {
            StageTitle.text = "Leccion" + Lection;
            LessonStage.text = "Leccion" + CurrentLession + " de " + TotalLessions;
        }
        else 
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo TMP_Text"); 
         
        }
    }

  //Este metodo aciva/dessactiva la ventana le lessonContainer
    public void EnableWindow()
    {
        OnUpdateUI ();

        if (lessonContainer.activeSelf)
        {
            //Desactiva el objeto si está activado
            lessonContainer.SetActive(false);
        }
        else 
        {
            //Activa el objeto si está desactivado
            lessonContainer.SetActive(true);

        }
    }
}
