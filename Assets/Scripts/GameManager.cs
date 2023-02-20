using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;


[System.Serializable]
public class QuizArray
{
    public Quiz[] Quizzes;
}

[System.Serializable]
public class Quiz
{
    public string Verb;
    public string[] Answers;
    public string RightAnswer;
    public string PrefabName;
}





public class GameManager : MonoBehaviour
{

    public Button[] Buttons;
    public TextMeshProUGUI[] ButtonTexts;


    private QuizArray _quizData;

    // Start is called before the first frame update
    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Quiz");

        if (jsonFile != null)
        {
            string jsonString = jsonFile.text;

            _quizData = JsonConvert.DeserializeObject<QuizArray>(jsonString);




            LoadQuiz(_quizData.Quizzes[0]);
        }
        else
        {
            Debug.LogError("Failed to load JSON file.");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadQuiz(Quiz quiz)
    {
        for (int i = 0; i < 3; i++)
        {

            
            ButtonTexts[i].text = quiz.Answers[i];
        }
    }
}
