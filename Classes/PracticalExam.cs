using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_ASP.NET_01.Classes
{
    internal class PracticalExam :Exam
    {
        public PracticalExam(int time, int numberOfQuestions, Question[] questions) : base(time, numberOfQuestions, questions)
        {
            
        }

        public override void ShowResults()
        {
            Console.Clear();

            Console.WriteLine("=================================");

            Console.WriteLine("Practical Exam Results");

            Console.WriteLine("=================================");

            Console.WriteLine();

            foreach (Question question in Questions)
            {
                Console.WriteLine( $"Question: {question.Body}");

                Console.WriteLine($"Your Answer ====> " +$"{question.UserAnswer?.AnswerText}");

                Console.WriteLine( $"Correct Answer ====> " +$"{question.RightAnswer.AnswerText}");

                Console.WriteLine();
            }

            int grade =CalculateGrade();

            int totalMarks = GetTotalMarks();

            Console.WriteLine( $"Your Grade is {grade} from {totalMarks}");

            Console.WriteLine( $"Time = " +$"{ElapsedTime.TotalSeconds:F2} seconds");

            Console.WriteLine();

            Console.WriteLine("Thank You ! ('',)");
        }

        public override object Clone()
        {
            return new PracticalExam(Time, NumberOfQuestions, CloneQuestions());
        }


        

    }
}
