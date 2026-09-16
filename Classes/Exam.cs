using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Exam_ASP.NET_01.Classes
{
    public abstract class Exam : ICloneable , IComparable 
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }
        public Subject? Subject { get; set; }
        public TimeSpan ElapsedTime { get; protected set; }

        protected Exam() : this(0, 0, new Question[0])
        {
        }
        protected Exam(int time , int numberOfQuestions , Question[] questions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = questions;
        }

        public virtual void ShowExam()
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

                int answerId =Program.ReadInt(1, question.Answers.Length);

                question.UserAnswer = question.Answers[answerId - 1];
            }
        }

       

        public virtual int CalculateGrade()
        {
            int grade = 0;

            foreach (Question question in Questions)
            {
                if (question.IsCorrect())
                {
                    grade += question.Mark;
                }
            }

            return grade;
        }


        public virtual void StartExam()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            ShowExam();

            stopwatch.Stop();

            ElapsedTime = stopwatch.Elapsed;
        }


        public virtual int GetTotalMarks()
        {
            int totalMarks = 0;

            foreach (Question question in Questions)
            {
                totalMarks += question.Mark;
            }

            return totalMarks;
        }

        protected Question[] CloneQuestions()
        {
            Question[] clonedQuestions = new Question[Questions.Length];

            for (int i = 0;i < Questions.Length; i++)
            {
                clonedQuestions[i] = (Question)Questions[i].Clone();
            }

            return clonedQuestions;
        }
        public abstract void ShowResults();

        public abstract object Clone();
        public virtual int CompareTo(object? obj)
        {
            if (obj is not Exam other)
                return 1;

            return Time.CompareTo(other.Time);
        }

        public override string ToString()
        {
            return $"Time: {Time} minutes, Questions: {NumberOfQuestions}";
        }


    }
}
