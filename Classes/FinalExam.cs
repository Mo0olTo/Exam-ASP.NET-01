using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_ASP.NET_01.Classes
{
    public class FinalExam : Exam
    {
        public FinalExam(
            int time,
            int numberOfQuestions,
            Question[] questions)
            : base(time, numberOfQuestions, questions)
        {
        }

        public override void ShowExam()
        {
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.Clear();

                Question question = Questions[i];

                Console.WriteLine($"Question {i + 1}");
                Console.WriteLine();

                question.Display();

                Console.WriteLine();
                Console.Write("Enter your answer ID: ");

                int answerId;

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out answerId) &&
                        answerId >= 1 &&
                        answerId <= question.Answers.Length)
                    {
                        break;
                    }

                    Console.Write($"Please enter a number between 1 and {question.Answers.Length}: ");
                }

                question.UserAnswer =
                    question.Answers[answerId - 1];
            }
        }

        public override void ShowResults()
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine("          Final Exam Result");
            Console.WriteLine("=================================");
            Console.WriteLine();

            for (int i = 0; i < Questions.Length; i++)
            {
                Question question = Questions[i];

                Console.WriteLine($"Question {i + 1}:");
                Console.WriteLine(question.Body);

                Console.WriteLine($"Your Answer: {question.UserAnswer?.AnswerText}");

                Console.WriteLine($"Correct Answer: {question.RightAnswer.AnswerText}");

                Console.WriteLine();
            }

            int grade = CalculateGrade();
            int totalMarks = GetTotalMarks();

            Console.WriteLine($"Your Grade is {grade} from {totalMarks}");

            Console.WriteLine($"Time = {ElapsedTime.TotalSeconds:F2} seconds");

            Console.WriteLine();
            Console.WriteLine("Thank You ! ('',)");
        }

        public override object Clone()
        {
            Question[] clonedQuestions = new Question[Questions.Length];

            for (int i = 0; i < Questions.Length; i++)
            {
                clonedQuestions[i] =
                    (Question)Questions[i].Clone();
            }

            return new FinalExam( Time,NumberOfQuestions,clonedQuestions);
        }
    }
}
