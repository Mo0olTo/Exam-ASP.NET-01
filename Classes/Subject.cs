using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_ASP.NET_01.Classes
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public Exam? Exam { get; private set; }

        public Subject()
            : this(0, string.Empty)
        {
        }

        public Subject(
            int subjectId,
            string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam(Exam exam)
        {
            Exam = exam;

            Exam.Subject = this;
        }

        public override string ToString()
        {
            return $"{SubjectId} - {SubjectName}";
        }
    }
}
