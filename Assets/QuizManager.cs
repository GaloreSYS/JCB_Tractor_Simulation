using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Question[] questions;
    private Question currentQuestion;
    public TextMeshProUGUI questionText; 
    public TextMeshProUGUI[] answerTexts;
    public TextMeshProUGUI ScoreText;
    private int currentQuestionIndex;
    private int score;
    

    void Start()
    {
        currentQuestionIndex = 0;
        score = 0;
        SetCurrentQuestion();
    }

    void SetCurrentQuestion()
    {
        currentQuestion = questions[currentQuestionIndex];
        questionText.text = currentQuestion.questionText;

        for (int i = 0; i < answerTexts.Length; i++)
        {
            answerTexts[i].text = currentQuestion.answers[i];
        }
    }

    public void OnAnswerSelected(int index)
    {
        if (index == currentQuestion.correctAnswerIndex)
        {
            Debug.Log("Correct!");
            score++;
        }
        else
        {
            Debug.Log("Wrong!");
        }

       
        ScoreText.text = score.ToString();
        if (currentQuestionIndex < questions.Length - 1)
        {
            currentQuestionIndex++;
            SetCurrentQuestion();
        }
        else
        {
            Debug.Log("Quiz Completed! Your score: " + score);
            // Handle quiz completion (e.g., show score, restart, etc.)
        }
    }
    
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] answers;
        public int correctAnswerIndex;
    }
}
