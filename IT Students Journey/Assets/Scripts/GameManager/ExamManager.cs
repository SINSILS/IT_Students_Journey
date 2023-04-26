using ClearSky;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExamManager : MonoBehaviour
{
    int sceneIndex;
    bool examDone = false;
    public StudentController student;
    Question question;
    TMP_Text examLabel;
    TMP_Text examQuestionLabel;
    TMP_Text answerALabel;
    TMP_Text answerBLabel;
    TMP_Text answerCLabel;
    Button answerAButton;
    Button answerBButton;
    Button answerCButton;
    private void Start()
    {
        examLabel = GameObject.Find("Exam label").GetComponent<TMP_Text>();
        examQuestionLabel = GameObject.Find("Exam question").GetComponent<TMP_Text>();
        var tempA = GameObject.Find("Answer A").GetComponent<TMP_Text>();
        var tempB = GameObject.Find("Answer B").GetComponent<TMP_Text>();
        var tempC = GameObject.Find("Answer C").GetComponent<TMP_Text>();
        answerALabel = tempA.GetComponent<TMP_Text>();
        answerAButton = tempA.GetComponent<Button>();
        answerBLabel = tempB.GetComponent<TMP_Text>();
        answerBButton = tempB.GetComponent<Button>();
        answerCLabel = tempC.GetComponent<TMP_Text>();
        answerCButton = tempC.GetComponent<Button>();

    }

    public void setSceneIndex(int x)
    {
        sceneIndex = x;
    }

    public void generateQuestion(int semester)
    {
        examDone = false;
        question = new Question(sceneIndex, semester);
        examLabel.color = Color.white;
        examLabel.text = "EXAM " + semester;
        examQuestionLabel.text = question.question;
        answerALabel.text = "A] " + question.answerA;
        answerBLabel.text = "B] " + question.answerB;
        answerCLabel.text = "C] " + question.answerC;
        answerAButton.interactable = true;
        answerBButton.interactable = true;
        answerCButton.interactable = true;
    }

    public void checkAnswer(int x)
    {
        if (question.rightAnswer == x)
        {
            examLabel.text = "Correct!";
            examLabel.color = Color.green;
            student.resetHealth();
            student.addCoins(10);
        }
        else
        {
            examLabel.text = "Wrong!";
            examLabel.color = Color.red;
            student.takeDamage(10);
            student.payCoins(10);
        }
        answerAButton.interactable = false;
        answerBButton.interactable = false;
        answerCButton.interactable = false;
        examDone = true;
    }

    public bool isExamDone()
    {
        return examDone;
    }
}
