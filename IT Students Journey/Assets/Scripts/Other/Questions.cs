using UnityEngine;

public class Question
{
    public int rightAnswer;
    public string question;
    public string answerA;
    public string answerB;
    public string answerC;

    //C#
    string[][] questions_CSharp = new string[8][] { new string[3]{
                                            "What value can be stored in int variable?",
                                            "What is the data type for true or false values?",
                                            "Which data type stores text values?"},
                                        new string[3]{
                                            "What is an array in programming?",
                                            "What is the index of the first element in an array?",
                                            "How can you access the third element of an array named \"numbers\"?"},
                                        new string[3]{
                                            "What method is used to add an item to a list variable?",
                                            "Method used to remove an item from a list variable:",
                                            "What method is used to sort a list variable?"},
                                        new string[3]{
                                            "What symbol is used to declare a matrix?",
                                            "What does a matrix store?",
                                            "How do you multiply two matrices?" },
                                        new string[3]{
                                            "Data structure using the principle \"first in, first out\":",
                                            "Which C# data structure stores items as key-value pairs?",
                                            "Which C# data structure allows duplicate values?"},
                                        new string[3]{
                                            "What is the primary purpose of LINQ in C#?",
                                            "Method used in LINQ to sort a sequence in ascending order:",
                                            "Method used in LINQ to filter elements to meet a condition:"},
                                        new string[3]{
                                            "What is the file extension for an ASP.NET web page?",
                                            "Primary programming language used in ASP.NET:",
                                            "What is the purpose of a master page in ASP.NET?"},
                                        new string[3]{
                                            "What method is used in C# to start a new thread?",
                                            "Method used to pause the execution of a thread:",
                                            "Method used to wait for a thread to complete its execution:"}};

    string[][] answersA_CSharp = new string[8][] { new string[3]{
                                            "True",
                                            "int",
                                            "string"},
                                        new string[3]{
                                            "Collection of variables",
                                            "-1",
                                            "numbers(3)"},
                                        new string[3]{
                                            "Add()",
                                            "Remove()",
                                            "Sort()"},
                                        new string[3]{
                                            "[ ]",
                                            "Data in a circle",
                                            "Using the + operator"},
                                        new string[3]{
                                            "Stack",
                                            "Dictionary",
                                            "Stack"},
                                        new string[3]{
                                            "Programming language",
                                            "OrderBy",
                                            "Select"},
                                        new string[3]{
                                            ".aspx",
                                            "Python",
                                            "To create graphical user interfaces"},
                                        new string[3]{
                                            "Thread.Start()",
                                            "Thread.Join()",
                                            "Thread.Abort()"}};

    string[][] answersB_CSharp = new string[8][] { new string[3]{
                                            "3.14",
                                            "bool",
                                            "float"},
                                        new string[3]{
                                            "Group of variables",
                                            "1",
                                            "numbers[2]"},
                                        new string[3]{
                                            "Insert()",
                                            "Clear()",
                                            "OrderBy()"},
                                        new string[3]{
                                            "{ }",
                                            "Data in a single line",
                                            "Using the * operator"},
                                        new string[3]{
                                            "Queue",
                                            "Tvalue",
                                            "Queue"},
                                        new string[3]{
                                            "To query data from different sources",
                                            "GroupBy",
                                            "Where"},
                                        new string[3]{
                                            ".html",
                                            "Java",
                                            "Template for other pages"},
                                        new string[3]{
                                            "Thread.Join()",
                                            "Thread.Sleep()",
                                            "Thread.Start()"}};

    string[][] answersC_CSharp = new string[8][] { new string[3]{
                                            "-123",
                                            "string",
                                            "bool"},
                                        new string[3]{
                                            "Same type variables",
                                            "0",
                                            "numbers{3}"},
                                        new string[3]{
                                            "Remove()",
                                            "Extend()",
                                            "Reverse()"},
                                        new string[3]{
                                            "( )",
                                            "Data in rows and columns",
                                            "Using the - operator"},
                                        new string[3]{
                                            "LinkedList",
                                            "Hashset",
                                            "Hashset"},
                                        new string[3]{
                                            "To manipulate hardware devices",
                                            "Select",
                                            "GroupBy"},
                                        new string[3]{
                                            ".php",
                                            "C#",
                                            "Manage database operations"},
                                        new string[3]{
                                            "Thread.Abort()",
                                            "Thread.Abort()",
                                            "Thread.Join()"}};

    int[][] rightAnswers_CSharp = new int[8][] { new int[3] { 3, 2, 1},
                                          new int[3] { 3, 3, 2},
                                          new int[3] { 1, 1, 1},
                                          new int[3] { 1, 3, 2},
                                          new int[3] { 2, 1, 3},
                                          new int[3] { 2, 1, 2},
                                          new int[3] { 1, 3, 1},
                                          new int[3] { 1, 2, 3}};

    //JS
    string[][] questions_JS = new string[8][] { new string[3]{
                                            "1What value can be stored in int variable?",
                                            "1Question 2",
                                            "1Question 3"},
                                        new string[3]{
                                            "2Question 1",
                                            "2Question 2",
                                            "2Question 3"},
                                        new string[3]{
                                            "3Question 1",
                                            "3Question 2",
                                            "3Question 3"},
                                        new string[3]{
                                            "4Question 1",
                                            "4Question 2",
                                            "4Question 3" },
                                        new string[3]{
                                            "5Question 1",
                                            "5Question 2",
                                            "5Question 3"},
                                        new string[3]{
                                            "6Question 1",
                                            "6Question 2",
                                            "6Question 3"},
                                        new string[3]{
                                            "7Question 1",
                                            "7Question 2",
                                            "7Question 3"},
                                        new string[3]{
                                            "8Question 1",
                                            "8Question 2",
                                            "8Question 3"}};

    string[][] answersA_JS = new string[8][] { new string[3]{
                                            "1True",
                                            "1AnswerA 2",
                                            "1AnswerA 3"},
                                        new string[3]{
                                            "2AnswerA 1",
                                            "2AnswerA 2",
                                            "2AnswerA 3"},
                                        new string[3]{
                                            "3AnswerA 1",
                                            "3AnswerA 2",
                                            "3AnswerA 3"},
                                        new string[3]{
                                            "4AnswerA 1",
                                            "4AnswerA 2",
                                            "4AnswerA 3"},
                                        new string[3]{
                                            "5AnswerA 1",
                                            "5AnswerA 2",
                                            "5AnswerA 3"},
                                        new string[3]{
                                            "6AnswerA 1",
                                            "6AnswerA 2",
                                            "6AnswerA 3"},
                                        new string[3]{
                                            "7AnswerA 1",
                                            "7AnswerA 2",
                                            "7AnswerA 3"},
                                        new string[3]{
                                            "8AnswerA 1",
                                            "8AnswerA 2",
                                            "8AnswerA 3"}};

    string[][] answersB_JS = new string[8][] { new string[3]{
                                            "3.14",
                                            "1AnswerB 2",
                                            "1AnswerB 3"},
                                        new string[3]{
                                            "2AnswerB 1",
                                            "2AnswerB 2",
                                            "2AnswerB 3"},
                                        new string[3]{
                                            "3AnswerB 1",
                                            "3AnswerB 2",
                                            "3AnswerB 3"},
                                        new string[3]{
                                            "4AnswerB 1",
                                            "4AnswerB 2",
                                            "4AnswerB 3"},
                                        new string[3]{
                                            "5AnswerB 1",
                                            "5AnswerB 2",
                                            "5AnswerB 3"},
                                        new string[3]{
                                            "6AnswerB 1",
                                            "6AnswerB 2",
                                            "6AnswerB 3"},
                                        new string[3]{
                                            "7AnswerB 1",
                                            "7AnswerB 2",
                                            "7AnswerB 3"},
                                        new string[3]{
                                            "8AnswerB 1",
                                            "8AnswerB 2",
                                            "8AnswerB 3"}};

    string[][] answersC_JS = new string[8][] { new string[3]{
                                            "-123",
                                            "1AnswerC 2",
                                            "1AnswerC 3"},
                                        new string[3]{
                                            "2AnswerC 1",
                                            "2AnswerC 2",
                                            "2AnswerC 3"},
                                        new string[3]{
                                            "3AnswerC 1",
                                            "3AnswerC 2",
                                            "3AnswerC 3"},
                                        new string[3]{
                                            "4AnswerC 1",
                                            "4AnswerC 2",
                                            "4AnswerC 3"},
                                        new string[3]{
                                            "5AnswerC 1",
                                            "5AnswerC 2",
                                            "5AnswerC 3"},
                                        new string[3]{
                                            "6AnswerC 1",
                                            "6AnswerC 2",
                                            "6AnswerC 3"},
                                        new string[3]{
                                            "7AnswerC 1",
                                            "7AnswerC 2",
                                            "7AnswerC 3"},
                                        new string[3]{
                                            "8AnswerC 1",
                                            "8AnswerC 2",
                                            "8AnswerC 3"}};

    int[][] rightAnswers_JS = new int[8][] { new int[3] { 3, 3, 3},
                                          new int[3] { 1, 1 , 1},
                                          new int[3] { 1, 1 , 1},
                                          new int[3] { 1, 1 , 1},
                                          new int[3] { 1, 1 , 1},
                                          new int[3] { 1, 1 , 1},
                                          new int[3] { 1, 1 , 1},
                                          new int[3] { 1, 1 , 1}};

    //----------------------------------------------------------------------------------
    //Python
    string[][] questions_Python = new string[8][] { new string[3]{
                                            "1What value can be stored in int variable?",
                                            "1Question 2",
                                            "1Question 3"},
                                        new string[3]{
                                            "2Question 1",
                                            "2Question 2",
                                            "2Question 3"},
                                        new string[3]{
                                            "3Question 1",
                                            "3Question 2",
                                            "3Question 3"},
                                        new string[3]{
                                            "4Question 1",
                                            "4Question 2",
                                            "4Question 3" },
                                        new string[3]{
                                            "5Question 1",
                                            "5Question 2",
                                            "5Question 3"},
                                        new string[3]{
                                            "6Question 1",
                                            "6Question 2",
                                            "6Question 3"},
                                        new string[3]{
                                            "7Question 1",
                                            "7Question 2",
                                            "7Question 3"},
                                        new string[3]{
                                            "8Question 1",
                                            "8Question 2",
                                            "8Question 3"}};

    string[][] answersA_Python = new string[8][] { new string[3]{
                                            "1True",
                                            "1AnswerA 2",
                                            "1AnswerA 3"},
                                        new string[3]{
                                            "2AnswerA 1",
                                            "2AnswerA 2",
                                            "2AnswerA 3"},
                                        new string[3]{
                                            "3AnswerA 1",
                                            "3AnswerA 2",
                                            "3AnswerA 3"},
                                        new string[3]{
                                            "4AnswerA 1",
                                            "4AnswerA 2",
                                            "4AnswerA 3"},
                                        new string[3]{
                                            "5AnswerA 1",
                                            "5AnswerA 2",
                                            "5AnswerA 3"},
                                        new string[3]{
                                            "6AnswerA 1",
                                            "6AnswerA 2",
                                            "6AnswerA 3"},
                                        new string[3]{
                                            "7AnswerA 1",
                                            "7AnswerA 2",
                                            "7AnswerA 3"},
                                        new string[3]{
                                            "8AnswerA 1",
                                            "8AnswerA 2",
                                            "8AnswerA 3"}};

    string[][] answersB_Python = new string[8][] { new string[3]{
                                            "3.14",
                                            "1AnswerB 2",
                                            "1AnswerB 3"},
                                        new string[3]{
                                            "2AnswerB 1",
                                            "2AnswerB 2",
                                            "2AnswerB 3"},
                                        new string[3]{
                                            "3AnswerB 1",
                                            "3AnswerB 2",
                                            "3AnswerB 3"},
                                        new string[3]{
                                            "4AnswerB 1",
                                            "4AnswerB 2",
                                            "4AnswerB 3"},
                                        new string[3]{
                                            "5AnswerB 1",
                                            "5AnswerB 2",
                                            "5AnswerB 3"},
                                        new string[3]{
                                            "6AnswerB 1",
                                            "6AnswerB 2",
                                            "6AnswerB 3"},
                                        new string[3]{
                                            "7AnswerB 1",
                                            "7AnswerB 2",
                                            "7AnswerB 3"},
                                        new string[3]{
                                            "8AnswerB 1",
                                            "8AnswerB 2",
                                            "8AnswerB 3"}};

    string[][] answersC_Python = new string[8][] { new string[3]{
                                            "-123",
                                            "1AnswerC 2",
                                            "1AnswerC 3"},
                                        new string[3]{
                                            "2AnswerC 1",
                                            "2AnswerC 2",
                                            "2AnswerC 3"},
                                        new string[3]{
                                            "3AnswerC 1",
                                            "3AnswerC 2",
                                            "3AnswerC 3"},
                                        new string[3]{
                                            "4AnswerC 1",
                                            "4AnswerC 2",
                                            "4AnswerC 3"},
                                        new string[3]{
                                            "5AnswerC 1",
                                            "5AnswerC 2",
                                            "5AnswerC 3"},
                                        new string[3]{
                                            "6AnswerC 1",
                                            "6AnswerC 2",
                                            "6AnswerC 3"},
                                        new string[3]{
                                            "7AnswerC 1",
                                            "7AnswerC 2",
                                            "7AnswerC 3"},
                                        new string[3]{
                                            "8AnswerC 1",
                                            "8AnswerC 2",
                                            "8AnswerC 3"}};

    int[][] rightAnswers_Python = new int[8][] { new int[3] { 3, 3, 3},
                                          new int[3] { 1, 1 , 1},
                                          new int[3] { 1, 1 , 1},
                                          new int[3] { 1, 1 , 1},
                                          new int[3] { 1, 1 , 1},
                                          new int[3] { 1, 1 , 1},
                                          new int[3] { 1, 1 , 1},
                                          new int[3] { 1, 1 , 1}};

    public Question(int sceneIndex, int semester)
    {
        generateQuestion(sceneIndex, semester);
    }

    //1 - C# (blueEnemy)
    //3 - Python (greenEnemy)
    //4 - JavaScript (redEnemy)
    void generateQuestion(int sceneIndex, int semester)
    {
        int temp = semester - 1;
        var random = Random.Range(0, 3);
        if (sceneIndex == 1)
        {
            this.rightAnswer = rightAnswers_CSharp[temp][random];
            this.question = questions_CSharp[temp][random];
            this.answerA = answersA_CSharp[temp][random];
            this.answerB = answersB_CSharp[temp][random];
            this.answerC = answersC_CSharp[temp][random];
        }
        else if (sceneIndex == 3)
        {
            this.rightAnswer = rightAnswers_Python[temp][random];
            this.question = questions_Python[temp][random];
            this.answerA = answersA_Python[temp][random];
            this.answerB = answersB_Python[temp][random];
            this.answerC = answersC_Python[temp][random];
        }
        else
        {
            this.rightAnswer = rightAnswers_JS[temp][random];
            this.question = questions_JS[temp][random];
            this.answerA = answersA_JS[temp][random];
            this.answerB = answersB_JS[temp][random];
            this.answerC = answersC_JS[temp][random];
        }
    }
}

