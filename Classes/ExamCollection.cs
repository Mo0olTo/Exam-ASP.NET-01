using Exam_ASP.NET_01.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_ASP.NET_01.Classes
{
    internal class ExamCollection<T> : IRepository<T>
    {
        private T[] Items;
        public int Count { get; private set; }

        public ExamCollection(int size)
        {
            Items = new T[size];
            Count = 0;
        }

        public void Add(T item)
        {
            if (Count < Items.Length)
            {
                Items[Count] = item;

                Count++;
            }
        }

        public T Get(int index)
        {
            if (index < 0 ||index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            return Items[index];
        }

        public T[] GetAll()
        {
            T[] result =new T[Count];

            for (int i = 0; i < Count;i++)
            {
                result[i] =Items[i];
            }

            return result;
        }
    }
}
