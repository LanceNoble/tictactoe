using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeList
{
    internal class CustomList<T>
    {
        private T[] items;
        public CustomList() 
        {
            items = new T[0];
        }
        public T GetItem(int index)
        {
            return items[index];
        }
        public void Add(T item)
        {
            // Make a new bigger array with room to store the new item
            T[] newItems = new T[items.Length + 1];

            // Copy all of the old items over to the new array
            for (int i = 0; i < items.Length; i++)
                newItems[i] = items[i];

            // Put the new item at the end
            newItems[items.Length - 1] = item;

            // Update our instance variable to hold this new array instead of the old array
            items = newItems;
        }
    }
}
