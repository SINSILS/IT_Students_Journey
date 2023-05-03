using ClearSky;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExamManager : MonoBehaviour
{
    int sceneIndex;
    bool examDone = false;
    public StudentController student;
    [SerializeField] private Question question;
    [SerializeField] private TMP_Text examLabel;
    [SerializeField] private TMP_Text examQuestionLabel;
    [SerializeField] private TMP_Text answerALabel;
    [SerializeField] private TMP_Text answerBLabel;
    [SerializeField] private TMP_Text answerCLabel;
    [SerializeField] private Button answerAButton;
    [SerializeField] private Button answerBButton;
    [SerializeField] private Button answerCButton;

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
        AudioHelper.instance.PlayQuizSong();
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
        AudioHelper.instance.StopQuizSong();
    }

    public bool isExamDone()
    {
        return examDone;
    }
}
