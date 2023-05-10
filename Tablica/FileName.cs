using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablica
{
    public class ResizableArray<T>
    {
        private T[] values;
        private int count;

        public event EventHandler<T> ItemAdded;
        public event EventHandler<int> SizeChanged;

        public ResizableArray() : this(4)
        {
        }

        public ResizableArray(int initialCapacity)
        {
            if (initialCapacity < 0)
            {
                throw new ArgumentException("The initial capacity cannot be negative.");
            }

            values = new T[initialCapacity];
            count = 0;
        }

        public void Add(T item)
        {
            if (count == values.Length)
            {
                Resize(2 * count);
            }

            values[count++] = item;
            ItemAdded?.Invoke(this, item);
            SizeChanged?.Invoke(this, count);
        }

        private void Resize(int newSize)
        {
            T[] newData = new T[newSize];

            Array.Copy(values, newData, count);

            values = newData;
        }

        public int getCount()
        {
            return count;
        }


        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return values[index];
            }
            set
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                if (index >= values.Length)
                {
                    Resize(index * 2);
                }

                values[index] = value;
                int prevCount = count;
                count = Math.Max(count, index + 1);
               
                ItemAdded?.Invoke(this, value);
                if( prevCount != count )
                {
                    SizeChanged?.Invoke(this, count);
                }
            }
        }
    }

    public class Helper
    {
        public static bool isEqual(int expected, int actual)
        {
            if (expected != actual)
            {
                throw new Exception("Expected value is not equal to actual value.");
            }

            return true;
        }
    }

}