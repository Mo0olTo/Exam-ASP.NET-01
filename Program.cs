using Exam_ASP.NET_01.Classes;
using Exam_ASP.NET_01.Enums;

namespace Exam_ASP.NET_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Examination System";

            Console.WriteLine("=================================");
            Console.WriteLine("      Examination System");
            Console.WriteLine("=================================");
            Console.WriteLine();

      
            // Choose Exam Type
          

            Console.Write("Enter the Type of exam (1 for Practical, 2 for Final): ");

            int examTypeValue = ReadInt(1, 2);

            ExamType examType = (ExamType)examTypeValue;

            Console.Clear();

            // Enter Exam Time
        

            Console.WriteLine("========== Exam Information ==========");
            Console.WriteLine();

            Console.Write("Please enter time for the exam (30 to 180 minutes): ");

            int examTime = ReadInt(30, 180);

            Console.WriteLine();

            // Number of Questions
        

            Console.Write("Please enter the number of questions: ");

            int numberOfQuestions = ReadPositiveInt();

            Console.Clear();

            // Create Questions
        

            Question[] questions =
                new Question[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.Clear();

                Console.WriteLine($"========== Enter Details For Question {i + 1} ==========");

                Console.WriteLine();

                QuestionType questionType;

                // Practical = MCQ only
                if (examType == ExamType.Practical)
                {
                    questionType = QuestionType.MCQ;
                }
                else
                {
                    Console.WriteLine(
                        "Choose question type: 1 for MCQ, 2 for True or False");

                    int questionTypeValue = ReadInt(1, 2);

                    questionType =
                        (QuestionType)questionTypeValue;
                }

                Console.Clear();

                
                // Create MCQ
               

                if (questionType == QuestionType.MCQ)
                {
                    questions[i] = CreateMCQQuestion(i + 1);
                }

             
                // Create True / False
              

                else
                {
                    questions[i] =
                        CreateTrueFalseQuestion(i + 1);
                }
            }

            Console.Clear();

           
            // Create Exam
            


            Exam exam;

            if (examType == ExamType.Practical)
            {
                exam = new PracticalExam(examTime,numberOfQuestions,questions);
            }
            else
            {
                exam = new FinalExam( examTime,numberOfQuestions,questions);
            }

            // Create Subject


            Subject subject = new Subject(
                1,
                "Object Oriented Programming");

            subject.CreateExam(exam);

   
            // Start Exam


            Console.WriteLine(
                "Do you want to start Exam (Y | N)");

            string? startExam = Console.ReadLine();

            if (startExam != null &&
                startExam.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();

                exam.StartExam();

                exam.ShowResults();
            }
            else
            {
                Console.Clear();

                Console.WriteLine("Exam was not started.");
                Console.WriteLine("Thank You ! ('',)");
            }

            Console.ReadLine();
        }


        // Create MCQ Question

        static MCQQuestion CreateMCQQuestion(int questionNumber)
        {
            Console.WriteLine($"========== Enter Details For Question {questionNumber} ==========");

            Console.WriteLine();

            Console.Write("Please enter the question body: ");

            string body = ReadText();

            Console.WriteLine();

            Console.Write("Please enter the question mark: ");

            int mark = ReadPositiveInt();

            Console.WriteLine();

            Console.WriteLine("Choices of question:");

            Answer[] answers = new Answer[4];

            for (int i = 0; i < 4; i++)
            {
                Console.Write(
                    $"Please enter choice number {i + 1}: ");

                string answerText = ReadText();

                answers[i] =
                    new Answer(i + 1, answerText);
            }

            Console.WriteLine();

            Console.Write("Please enter the ID of the Correct Answer (1 to 4): ");

            int correctAnswerId = ReadInt(1, 4);

            Answer correctAnswer = answers[correctAnswerId - 1];

            return new MCQQuestion( "MCQ Question", body,mark,answers,correctAnswer);
        }

        // Create True / False Question


        static TrueFalseQuestion CreateTrueFalseQuestion(
            int questionNumber)
        {
            Console.WriteLine( $"========== Enter Details For Question {questionNumber} ==========");

            Console.WriteLine();

            Console.Write("Please enter the question body: ");

            string body = ReadText();

            Console.WriteLine();

            Console.Write("Please enter the question mark: ");

            int mark = ReadPositiveInt();

            Console.WriteLine();

            Answer trueAnswer = new Answer(1, "True");

            Answer falseAnswer = new Answer(2, "False");

            Answer[] answers =
            {
                trueAnswer,
                falseAnswer
            };

            Console.Write("Please enter the ID of the Correct Answer (1 for True, 2 for False): ");

            int correctAnswerId = ReadInt(1, 2);

            Answer correctAnswer = answers[correctAnswerId - 1];

            return new TrueFalseQuestion("True or False Question", body,mark, answers,correctAnswer);
        }


        // Read Integer Within Range


        public static int ReadInt(int min, int max)
        {
            int value;

            while (true)
            {
                string? input = Console.ReadLine();

                if (int.TryParse(input, out value) &&
                    value >= min &&
                    value <= max)
                {
                    return value;
                }

                Console.Write($"Please enter a number between {min} and {max}: ");
            }
        }


        // Read Positive Integer
        public static int ReadPositiveInt()
        {
            int value;

            while (true)
            {
                string? input = Console.ReadLine();

                if (int.TryParse(input, out value) &&
                    value > 0)
                {
                    return value;
                }

                Console.Write("Please enter a positive number: ");
            }
        }


        // Read Text

        static string ReadText()
        {
            while (true)
            {
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                Console.Write("Please enter a valid value: ");
            }
        
    }
    }
}
