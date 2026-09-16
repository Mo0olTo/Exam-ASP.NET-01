using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_ASP.NET_01.Classes
{
    public class TrueFalseQuestion :Question
    {

        public TrueFalseQuestion(string header, string body, int mark , Answer[] answer , Answer rightAnswer):base(header , body , mark  , answer , rightAnswer)
        {
            
        }
        public override void Display()
        {
            Console.WriteLine(Body);
            Console.WriteLine($"True or False Question : {Mark} mark");

            foreach (Answer answer in Answers)
            {
                Console.WriteLine(answer);
            }
        }
        public override object Clone()
        {
            Answer[] clonedAnswers = new Answer[Answers.Length];

            for (int i = 0; i < Answers.Length; i++)
            {
                clonedAnswers[i] = (Answer)Answers[i].Clone();
            }

            Answer clonedRightAnswer = (Answer)RightAnswer.Clone();

            return new MCQQuestion(Header, Body, Mark, clonedAnswers, clonedRightAnswer);
        }

     
    }
}
