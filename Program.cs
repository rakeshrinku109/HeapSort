using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HeapSort
{ 
    class Program
    {
        static void Main(string[] args)
        {
            int[] array =new int[] { 5, 90, 0, 20, 57, 1, 90,300 };
            Heap<int> MaxHeap = new Heap<int>(array);
            MaxHeap.InsertKey(300);
            MaxHeap.Sort();
            string str = MaxHeap.Display();
            Console.WriteLine(str);
            Console.ReadLine();
        }
    }
}

namespace HeapSort
{
    public class Heap<T> : IOperation<T> where T: IComparable
    {
        private T[] array;
        private int size = 0;

        public Heap(T[] array)
        {
            this.array = array;
            this.size = array.Length -1;
        }

        // Builds the heap
        private void BuildHeap(T[] array)
        {
            for (int i =size/2; i >=0; i--)
            {
                Heapify(i);
            }
        }

        public void Deltekey(int Index)
        {
            throw new NotImplementedException();
        }

        private void Heapify(int Index)
        {
            int LeftChildIndex = 2 * Index + 1;
            int RightChildIndex = 2 * Index + 2;
            int largest = Index;


            if (LeftChildIndex <= size)
            {
                if (array[LeftChildIndex].CompareTo(array[largest]) >= 0)
                {
                    largest = LeftChildIndex;
                }
            }
            if(RightChildIndex <= size)
            { 
                if (array[RightChildIndex].CompareTo(array[largest]) >= 0)  
                {
                    largest = RightChildIndex;
                }
            }

            if (largest !=Index)
            {
                Swap(largest, Index);
                Heapify(largest);
            }
        }

        public void InsertKey(T Key)
        {
            T[] _array = new T[size*2];
            this.array.CopyTo(_array,0);
            this.array = _array;
            this.array[size] = Key;
            BuildHeap(array);
        }

        public void Sort()
        {
            BuildHeap(this.array);

            for (int i = size; i >0; i--)
            {
                Swap(0, size);
                size--;
                Heapify(0);
            }
            
        }

        private void Swap(int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public string Display()
        {
            string str ="";
            for (int i = 0; i < array.Length; i++)
            {
                str += array[i] + ", ";
            }

            return str;

        }
    }
}

namespace HeapSort
{
    public interface IOperation<T>
    {
        void InsertKey(T Key);

        void Deltekey(int Index);

        void Sort();

        string Display();


    }
}