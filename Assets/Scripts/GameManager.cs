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

    public TextMeshProUGUI[] ButtonTexts;
    public Button[] Buttons;
    public Sprite FailedButtonImage;
    public Sprite DefaultButtonImage;
    public TextMeshProUGUI TopQuizText;
    private QuizArray _quizData;
    public int RightAnswerId = -1;
    private int _currentLoadedQuiz = 0;
    public Vector3 TappedPosition { get; private set; } = default;
    public Quaternion TappedRotation { get; private set; } = default;
    public GameObject ObjectToPlace { get; private set; } = null;

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

        ResetButtonsTexture();

        TopQuizText.text = quiz.Verb;

        if (ObjectToPlace != null) GameObject.Destroy(ObjectToPlace);

        ObjectToPlace = GameObject.Find(quiz.PrefabName);
        if (TappedPosition != default)
        {
            ObjectToPlace.transform.SetPositionAndRotation(TappedPosition, TappedRotation);
            ObjectToPlace.transform.Rotate(0, 180, 0);
        }
        for (int i = 0; i < 4; i++)
        {
            ButtonTexts[i].text = quiz.Answers[i];

            if (quiz.RightAnswer == quiz.Answers[i])
                RightAnswerId = i;
        }
    }

    public void QuizButtonPressed(int buttonId)
    {
        if (buttonId == RightAnswerId)
        {
            LoadQuiz(_quizData.Quizzes[++_currentLoadedQuiz]);
            return;
        }

        Buttons[buttonId].image.sprite = FailedButtonImage;
    }

    public void Tapped(Vector3 positoin, Quaternion quaternion)
    {
        ObjectToPlace.transform.SetPositionAndRotation(positoin, quaternion);
        ObjectToPlace.transform.Rotate(0, 180, 0);
        TappedPosition = positoin;
        TappedRotation = quaternion;
    }

    private void ResetButtonsTexture()
    {
        foreach (var button in Buttons)
        {
            button.image.sprite = DefaultButtonImage;
        }
    }
}
