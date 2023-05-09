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

            for (int i = 0; i < count; i++)
            {
                newData[i] = values[i];
            }

            values = newData;
            SizeChanged?.Invoke(this, newSize);
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
                    throw new ArgumentOutOfRangeException();
                }

                return values[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                values[index] = value;
                ItemAdded?.Invoke(this, value);
            }
        }
    }

    public class Helper
    {
        public static bool isEqual(int expected, int actual)
        {
            return expected == actual;
        }
    }

}