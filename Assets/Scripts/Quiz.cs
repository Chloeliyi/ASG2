using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] private GameObject[] QuizQns;

    //public Color wrongColor;
    //public Color rightColor;

    //public Button wrongButton;
    //public Button rightButton;

    private int quizpoints;
    private int quizcounter;

    //private int checkpoints;

    [SerializeField] private TextMeshProUGUI Quizscore;
    [SerializeField] private TextMeshProUGUI CheckpointText;

    public GameObject StartQuiz;
    public GameObject Questions;
    public GameObject EndQuiz;

    [SerializeField] private AuthManager authManager;
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        quizcounter = 0;
        StartQuiz.gameObject.SetActive(true);
        Questions.gameObject.SetActive(false);
        EndQuiz.gameObject.SetActive(false);

        Quizscore.text = "Score : " + quizpoints;
    }

    public void QuizStarts()
    {
        StartQuiz.gameObject.SetActive(false);
        Questions.gameObject.SetActive(true);
        QuizQns[quizcounter].gameObject.SetActive(true);
    }

    public void WrongAnswer()
    {
        Debug.Log("Wrong Answer");
        //WrongColor();

        QuizQns[quizcounter].gameObject.SetActive(false);
        quizcounter ++;
        QuizQns[quizcounter].gameObject.SetActive(true);

        if (quizcounter < QuizQns.Length) {
            Questions.gameObject.SetActive(false);
            EndQuiz.gameObject.SetActive(true);
        }

    }

    public void WrongColor()
    {
        /*ColorBlock cb = wrongButton.colors;
        cb.normalColor = wrongColor;
        cb.highlightedColor = wrongColor;
        cb.pressedColor = wrongColor;
        wrongButton.colors = cb;*/
    }

    public void RightColor()
    {
        /*ColorBlock cb = rightButton.colors;
        cb.normalColor = rightColor;
        cb.highlightedColor = rightColor;
        cb.pressedColor = rightColor;
        rightButton.colors = cb;*/
    }

    public void RightAnswer()
    {
        Debug.Log("Right Answer");
        //RightColor();

        quizpoints ++;

        Quizscore.text = "Score : " + quizpoints;

        QuizQns[quizcounter].gameObject.SetActive(false);
        quizcounter ++;
        QuizQns[quizcounter].gameObject.SetActive(true);

        if (quizcounter < QuizQns.Length) {
            Questions.gameObject.SetActive(false);
            EndQuiz.gameObject.SetActive(true);

            gameManager.checkpoints ++;
            CheckpointText.text = "Checkpoint : " + gameManager.checkpoints;
        }

    }

    public void QuizComplete()
    {
        //checkpoints ++;
        gameManager.QuizComplete();
        authManager.CheckForNewQuizScore(quizpoints);

    }
}
