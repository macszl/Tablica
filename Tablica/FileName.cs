using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablica
{
    public class ResizableArray<T>
    {
        T[] values;
        private int count;
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
                newData[i] = data[i];
            }

            data = newData;
            SizeChanged?.Invoke(this, newSize);
        }

        public int getCount()
        {
            return count;
        }
    }

    public class Helper
    {
        public static bool isEqual(int expected, int actual)
        {

        }
    }
}
