 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelManager : MonoBehaviour
{
    //Intancia de la clase
    public static LevelManager Instance;
    [Header("Level Data")]
    public Subject Lesson;

    [Header("User Interface")]
    public TMP_Text QuestionTxt;
    public TMP_Text livesTxt;
    public List<Option> Options;
    public GameObject CheckButton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;

    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerFromPlayer = 9;
    public int lives = 5;

    [Header("Current Leccion")]
    public Leccion currentLesson;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else 
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Establecemos la cantidad de preguntas en la leccion
        questionAmount = Lesson.leccionList.Count;


        //Cargar la primera pregunta
        LoadQuestion();

        //Check player input
        CheckPlayerState();
    }


    private void LoadQuestion() 
    {
        //Aseguramos que la pregunta actual este dentro de los limites
        if (currentQuestion < questionAmount)
        {
            //Establecemos la leccion actual
            currentLesson = Lesson.leccionList[currentQuestion];
            //Establecemos la pregunta
            question = currentLesson.lessons;
            //Establecemos la respuesta correcta
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];
            //Establecemos la pregunta en la UI
            QuestionTxt.text = question;
            //Establecemos las Opciones 
            for (int i = 0; i < currentLesson.options.Count;i++) 
            {
                Options[i].GetComponent<Option>().OptionName = currentLesson.options[i];
                Options[i].GetComponent<Option>().OptionID = i;
                Options[i].GetComponent<Option>().UpdateText();
            }
        }
        else 
        {
            //Si llegamos al fin de las preguntas
            Debug.Log("Fin de las preguntas");
       }
    }

    public void NextQuestion() 
    {
        if (CheckPlayerState())
        {
            if (currentQuestion < questionAmount)
            {
                //Revisamos si la repuesta es correcta o no
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                AnswerContainer.SetActive(true);

                if (isCorrect)
                {
                    AnswerContainer.GetComponent<Image>().color = Green;
                    Debug.Log("Respuesta correcta. " + question + ": " + correctAnswer);
                }
                else 
                {
                    lives--;
                    AnswerContainer.GetComponent<Image>().color = Red;
                    Debug.Log("Respuesta incorrecta. " + question + ": " + correctAnswer);
                }
                //Actualizamos el contador de vidas
                livesTxt.text = lives.ToString();

                //Incrementamos el indice de la pregunta actual
                currentQuestion++;

                //Mostramos el resultado durante un tiempo (puedes usar el coroutine o Invoke)
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));

                //Reset answer from player
                answerFromPlayer = 9;
           

            }
            else
            {
                //cambio de escena
            }
        }
    }
    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect) 
    {
        //Ajustamos el tiempo que desemos mostrar el resultado
        yield return new WaitForSeconds(2.5f);

        //Ocultar el contenedor de respuestas
        AnswerContainer.SetActive(false);

        //Cargamos la nueva pregunta 
        LoadQuestion();

        //Activar el botón después de mostrar el resultado
        //Puedes hacer esto aqui o en LoadQuestion(), dependiendo de tu estructura
        //por ejemplo, si el botón está en el mismo GameObject que el script:
        //GetComponent<Buttton>().intercambiable = true;
        CheckPlayerState();
    }
    public void SetPlayerAnswer(int answer) 
    {
        answerFromPlayer = answer;
    }

    public bool CheckPlayerState() 
    {
        if (answerFromPlayer != 9) 
        {
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else
        {
            CheckButton.GetComponent<Button>().interactable = false;
            CheckButton.GetComponent<Image>().color = Color.grey;
            return false;
        }
    }
    
}
