using ClearSky;
using TMPro;
using UnityEngine;

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
    private void Start()
    {
        examLabel = GameObject.Find("Exam label").GetComponent<TMP_Text>();
        examQuestionLabel = GameObject.Find("Exam question").GetComponent<TMP_Text>();
        answerALabel = GameObject.Find("Answer A").GetComponent<TMP_Text>();
        answerBLabel = GameObject.Find("Answer B").GetComponent<TMP_Text>();
        answerCLabel = GameObject.Find("Answer C").GetComponent<TMP_Text>();
    }

    private void Update()
    {

    }

    public void setSceneIndex(int x)
    {
        sceneIndex = x;
    }

    public void generateQuestion(int semester)
    {
        examDone = false;
        question = new Question(sceneIndex, semester);
        examLabel.text = "EXAM " + semester;
        examQuestionLabel.text = question.question;
        answerALabel.text = "A] " + question.answerA;
        answerBLabel.text = "B] " + question.answerB;
        answerCLabel.text = "C] " + question.answerC;
    }

    public void checkAnswer(int x)
    {
        if (question.rightAnswer == x)
        {
            student.resetHealth();
            student.addCoins(10);

            //refresh HP, give coins mby
        }
        else
        {
            student.takeDamage(10);
            student.payCoins(10);
            //deal damage, steal coins
        }
        examDone = true;
    }

    public bool isExamDone()
    {
        return examDone;
    }
}
