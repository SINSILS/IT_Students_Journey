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
                                            "What data type is assigned to the variable 'x' in the statement 'var x = \"name\"'?",
                                            "What is the value of 'x' after the following code is executed: 'let x = 10; x += 5;'?",
                                            "What is the output of the following code: 'console.log(typeof 3.14);'?"},
                                        new string[3]{
                                            "Which statement is used in JS to execute code repeatedly for a specified number of times?",
                                            "Which statement is used in JS to execute code repeatedly as long as a certain condition is true?",
                                            "Which statement is used in JavaScript to execute code only if a certain condition is true?"},
                                        new string[3]{
                                            "What is the keyword used in JavaScript to define a function?",
                                            "What is the term used in JavaScript to describe the values passed into a function?",
                                            "What is the term used in JavaScript to describe a function that doesn't have a name?"},
                                        new string[3]{
                                            "In JavaScript, what is the syntax for creating a new object?",
                                            "Which keyword is used in JavaScript to iterate over an object's properties?",
                                            "Which method is used in JavaScript to remove the last element of an array?" },
                                        new string[3]{
                                            "In the DOM, what property is used to access an element's class?",
                                            "Which event is triggered when an element is clicked in the DOM?",
                                            "In the DOM, what property is used to access an element's content?"},
                                        new string[3]{
                                            "Which method is used to register an event listener in JavaScript?",
                                            "Which event is triggered when a user presses a key on the keyboard in JavaScript?",
                                            "Which method is used to stop the propagation of an event in JavaScript?"},
                                        new string[3]{
                                            "What does AJAX stand for in JavaScript?",
                                            "What does API stand for in JavaScript?",
                                            "What is the format of data returned by an API in JavaScript?"},
                                        new string[3]{
                                            "What keyword is used in ES6 to declare a block-scoped variable in JavaScript?",
                                            "Which feature in ES6 allows you to define a function that can receive a variable number of arguments?",
                                            "What is the purpose of the \"spread operator\" in ES6?"}};

    string[][] answersA_JS = new string[8][] { new string[3]{
                                            "boolean value",
                                            "5",
                                            "\"number\""},
                                        new string[3]{
                                            "for loop",
                                            "for loop",
                                            "question statement"},
                                        new string[3]{
                                            "create",
                                            "arguments",
                                            "anonymous function"},
                                        new string[3]{
                                            "let obj = new Object ( );",
                                            "for",
                                            "push ( )"},
                                        new string[3]{
                                            "classList",
                                            "mouseover",
                                            "innerHTML"},
                                        new string[3]{
                                            "registerEvent ( )",
                                            "keydown",
                                            "cancelPropagation ( )"},
                                        new string[3]{
                                            "Automated JavaScript and XML",
                                            "Advanced Programming Interface",
                                            "JSON"},
                                        new string[3]{
                                            "var",
                                            "rest parameters",
                                            "To split an array into arguments"}};

    string[][] answersB_JS = new string[8][] { new string[3]{
                                            "number",
                                            "10",
                                            "\"string\""},
                                        new string[3]{
                                            "do loop",
                                            "do loop",
                                            "if statement"},
                                        new string[3]{
                                            "function",
                                            "parameters",
                                            "unnamed function"},
                                        new string[3]{
                                            "let obj = { };",
                                            "while",
                                            "pop ( )"},
                                        new string[3]{
                                            "className",
                                            "click",
                                            "outerHTML"},
                                        new string[3]{
                                            "createListener ( )",
                                            "keyup",
                                            "stopPropagation ( )"},
                                        new string[3]{
                                            "Advanced JavaScript and XML",
                                            "Application Programming Interface",
                                            "XML"},
                                        new string[3]{
                                            "let",
                                            "spread operator",
                                            "To merge multiple arrays into one"}};

    string[][] answersC_JS = new string[8][] { new string[3]{
                                            "string",
                                            "15",
                                            "\"boolean\""},
                                        new string[3]{
                                            "while loop",
                                            "while loop",
                                            "while loop"},
                                        new string[3]{
                                            "define",
                                            "inputs",
                                            "no-name function"},
                                        new string[3]{
                                            "let obj = Object.create ( );",
                                            "foreach",
                                            "shift ( )"},
                                        new string[3]{
                                            "classType",
                                            "keypress",
                                            "textContent"},
                                        new string[3]{
                                            "addEventListener ( )",
                                            "keypress",
                                            "prohibitPropagation ( )"},
                                        new string[3]{
                                            "Asynchronous JavaScript and XML",
                                            "Automated Programming Interface",
                                            "CSV"},
                                        new string[3]{
                                            "const",
                                            "variable parameters",
                                            "Both A and B"}};

    int[][] rightAnswers_JS = new int[8][] { new int[3] { 3, 3, 1},
                                          new int[3] { 1, 3, 2},
                                          new int[3] { 2, 2, 1},
                                          new int[3] { 2, 1, 2},
                                          new int[3] { 2, 2, 1},
                                          new int[3] { 3, 1, 2},
                                          new int[3] { 3, 2, 1},
                                          new int[3] { 2, 1, 3}};

    //----------------------------------------------------------------------------------
    //Python
    string[][] questions_Python = new string[8][] { new string[3]{
                                            "How do you find the length of a string in Python?",
                                            "How do you declare a variable in Python?",
                                            "How do you swap the values of two variables in Python without using a third variable?"},
                                        new string[3]{
                                            "What does the continue statement do in a loop in Python?",
                                            "What does the break statement do in a loop in Python?",
                                            "What does the range() function do in a for loop in Python?"},
                                        new string[3]{
                                            "How do you add an element to the end of a list in Python?",
                                            "What is the syntax for creating a tuple in Python?",
                                            "How do you reverse the order of a list in Python?"},
                                        new string[3]{
                                            "What is the syntax for opening a file for reading in Python?",
                                            "What is the syntax for opening a file for writing in Python?",
                                            "How do you read a file line by line in Python?" },
                                        new string[3]{
                                            "What is inheritance in OOP?",
                                            "What is encapsulation in OOP?",
                                            "What is polymorphism in OOP?"},
                                        new string[3]{
                                            "What is the syntax for raising a custom exception in Python?",
                                            "How can you access the error message in a Python except block?",
                                            "What is the purpose of the \"finally\" block in a try-except statement in Python?"},
                                        new string[3]{
                                            "What is NumPy used for in Python?",
                                            "What is Pandas used for in Python?",
                                            "What is Matplotlib used for in Python?"},
                                        new string[3]{
                                            "What is the main advantage of multithreading?",
                                            "What is GIL in Python?",
                                            "What is the difference between a thread and a process in Python?"}};

    string[][] answersA_Python = new string[8][] { new string[3]{
                                            "len(string)",
                                            "var name = value",
                                            "x = y; y = x"},
                                        new string[3]{
                                            "It exits the loop",
                                            "Continues to the next iteration",
                                            "Creates a list of integers"},
                                        new string[3]{
                                            "list.append(element)",
                                            "(element1, element2, ...)",
                                            "list.sort(reverse=True)"},
                                        new string[3]{
                                            "open(filename, \"w\")",
                                            "open(filename, \"r\")",
                                            "file.read()"},
                                        new string[3]{
                                            "New code",
                                            "Data hiding",
                                            "Only one behaviour"},
                                        new string[3]{
                                            "raise Exception (Error message)",
                                            "By using the \"try\" keyword",
                                            "It always executes"},
                                        new string[3]{
                                            "Scientific computing",
                                            "Data analysis",
                                            "Data manipulation"},
                                        new string[3]{
                                            "Improved performance",
                                            "Global Identifier Lock",
                                            "Process is lighter than a thread"}};

    string[][] answersB_Python = new string[8][] { new string[3]{
                                            "count(string)",
                                            "name = value",
                                            "x = y; y = x + y"},
                                        new string[3]{
                                            "Restarts the loop",
                                            "It exits the loop",
                                            "Performs a mathematical stuff"},
                                        new string[3]{
                                            "list.insert(element)",
                                            "[element1, element2, ...]",
                                            "list.reverse()"},
                                        new string[3]{
                                            "open(filename, \"r\")",
                                            "open(filename, \"w\")",
                                            "file.readall()"},
                                        new string[3]{
                                            "File sharing",
                                            "File hiding",
                                            "All answers are incorect"},
                                        new string[3]{
                                            "raise Error (Error message)",
                                            "By using the \"raise\" keyword",
                                            "It never executes"},
                                        new string[3]{
                                            "Data visualization",
                                            "Image processing",
                                            "Data visualization"},
                                        new string[3]{
                                            "Simpler code",
                                            "Global Import Lock",
                                            "Thread is lighter than a process"}};

    string[][] answersC_Python = new string[8][] { new string[3]{
                                            "length(string)",
                                            "declare name = value",
                                            "x, y = y, x"},
                                        new string[3]{
                                            "Continues to the next iteration",
                                            "It adds a value to the loop",
                                            "Generates a sequence of numbers"},
                                        new string[3]{
                                            "list.add(element)",
                                            "{element1, element2, ...}",
                                            "list.flip()"},
                                        new string[3]{
                                            "open(filename, \"a\")",
                                            "open(filename, \"a\")",
                                            "file.readlines()"},
                                        new string[3]{
                                            "Parent-child relationship",
                                            "Public attributes",
                                            "Many behaviors"},
                                        new string[3]{
                                            "throw Exception (Error message)",
                                            "By using the \"as\" keyword",
                                            "Same as \"finish\""},
                                        new string[3]{
                                            "Web development",
                                            "Machine learning",
                                            "Data storage"},
                                        new string[3]{
                                            "Easier debugging",
                                            "Global Interpreter Lock",
                                            "They are the same thing"}};

    int[][] rightAnswers_Python = new int[8][] { new int[3] { 1, 2, 3},
                                          new int[3] { 3, 2, 3},
                                          new int[3] { 1, 1, 2},
                                          new int[3] { 2, 2, 3},
                                          new int[3] { 3, 1, 1},
                                          new int[3] { 1, 3, 1},
                                          new int[3] { 2, 2, 1},
                                          new int[3] { 1, 3, 2}};

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