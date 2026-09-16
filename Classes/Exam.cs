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

        public abstract void ShowExam();

        public abstract void ShowResults();

        public abstract object Clone();

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
