using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_ASP.NET_01.Classes
{
    public abstract class Question : ICloneable, IComparable
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }

        public Answer[] Answers { get; set; }

        public Answer RightAnswer { get; set; }
        public Answer? UserAnswer { get; set; }

        protected Question(string header, string body, int mark, Answer[] answers, Answer rightAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = answers;
            RightAnswer = rightAnswer;
           
        }

        protected Question() : this(string.Empty, string.Empty, 0, new Answer[0], new Answer())
        {

        }

        public abstract void Display();

        public abstract object Clone();


        public virtual int CompareTo(object? obj)
        {
            if (obj is not Question other)
            {
                return 1;
            }

            return Mark.CompareTo(other.Mark);
        }


        public bool IsCorrect()
        {
            return UserAnswer != null && UserAnswer.AnswerID == RightAnswer.AnswerID;
        }


        public override string ToString()
        {
            return $"{Header}: {Body} - Mark: {Mark}";
        }



    }
}
