using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_ASP.NET_01.Classes
{
    public class MCQQuestion : Question
    {

        public MCQQuestion(string header, string body, int mark, Answer[] answers, Answer rightAnswer) 
                           : base(header, body, mark, answers, rightAnswer)
        {
        }

        public override void Display()
        {
            Console.WriteLine(Body);
            Console.WriteLine($"MCQ Question : {Mark} mark");

            foreach(Answer answer in Answers)
            {
                Console.WriteLine(answer);
            }
        }


        public override object Clone()
        {
            return new MCQQuestion(Header, Body, Mark, CloneAnswers(), CloneRightAnswer());
        }





    }
}
