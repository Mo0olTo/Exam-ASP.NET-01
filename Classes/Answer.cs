using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_ASP.NET_01.Classes
{
    internal class Answer :ICloneable , IComparable
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }

        public Answer(int answerId, string answerText)
        {
            AnswerID = answerId;
            AnswerText = answerText;

        }
        public Answer() : this(0, string.Empty)
        {

        }


     

        public int CompareTo(object? obj)
        {
            if(obj is not Answer other)
            {
                return 1;
            }
            return AnswerID.CompareTo(other.AnswerID);
        }

        public object Clone()
        {
            return new Answer(AnswerID, AnswerText);
        }


        public override string ToString()
        {
            return $"{AnswerID}- {AnswerText}";
        }

    }
}
