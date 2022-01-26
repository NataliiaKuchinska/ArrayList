using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysLibrary
{
    public interface IArrayList : IEnumerable<int>
    {
        /// <summary>
        /// Add element to List begining
        /// </summary>
        /// <param name="value">Value to add</param>
        void AddFront(int value);

        /// <summary>
        /// Add element to List end
        /// </summary>
        /// <param name="value">Value to add</param>
        void AddBack(int value);

        /// <summary>
        /// Add element to List by index (in index position)
        /// </summary>
        /// <param name="index">Position to insert value</param>
        ///<param name="value">Value to insert in index position</param>
        void AddByIndex(int index, int value);
        
        /// <summary>
        /// Add arrayList to List begining
        /// </summary>
        /// <param name="arrayList">List to add</param>
        void AddFront(IArrayList arrayList);

        /// <summary>
        /// Add arrayList to List end
        /// </summary>
        /// <param name="arrayList">List to add</param>
        void AddBack(IArrayList arrayList);

        /// <summary>
        /// Removing element from begining
        /// </summary>
        /// <returns>Returns removed element</returns>
        int RemoveFront();
        int RemoveBack();
        int RemoveByIndex(int index);//2
        int[] RemoveFront(int count);
        int[] RemoveBack(int count);
        int[] RemoveByIndex(int index, int count);//3
        int Length { get; }//4
        int this[int index] { get; set; }//5,6
        int IndexOf(int element);//7
        void Reverse();//8
        int Max();
        int Min();
        int MaxIndex();//9
        int MinIndex();//10
        void Sort(bool ascending = true);//11
        /// <summary>
        /// Remove first element by value
        /// </summary>
        /// <param name="value">Value to remove</param>
        /// <returns>Index of removed element</returns>
        int Remove(int value);//12
        /// <summary>
        /// Remove all elements by value
        /// </summary>
        /// <param name="value">Value to remove</param>
        /// <returns>Count of removed elements</returns>
        int RemoveAll(int value);//13

        void AddByIndex(int index, IArrayList arrayList);//14

        int[] ToArray();
    }
}