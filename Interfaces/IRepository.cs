using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_ASP.NET_01.Interfaces
{
    public interface IRepository <T>
    {

        void Add(T item);

        T Get(int index);

        int Count { get; }
    }
}
