using System;
using System.Collections;
using System.Collections.Generic;

namespace ArraysLibrary
{
    public class ArrayList : IArrayList
    {
        private int[] _array;

        private int _currentCount;

        public int Length => _currentCount;

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < _currentCount)
                {
                    return _array[index];
                }

                throw new IndexOutOfRangeException("Index was out of range!");
            }

            set
            {
                if (index >= 0 && index < _currentCount)
                {
                    _array[index] = value;
                }

                throw new IndexOutOfRangeException("Index was out of range!");
            }

        }

        public ArrayList(int capacity = 4)
        {
            _array = new int[capacity];
            _currentCount = 0;
        }

        public ArrayList(int[] array)
        {
            int size = (int)(array.Length * 2);
            _array = new int[size];
            _currentCount = array.Length;

            for (int i = 0; i < _currentCount; i++)
            {
                _array[i] = array[i];
            }
        }

        public void AddFront(int value)
        {
            AddByIndex(0, value);
        }

        public void AddBack(int value)
        {
            UpdateSize();
            _array[_currentCount++] = value;

        }

        public void AddByIndex(int index, int value)
        {
            if (index < 0 || index > _currentCount)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            UpdateSize();

            for (int i = _currentCount; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[index] = value;
            _currentCount++;
        }

        public void AddFront(IArrayList arrayList)
        {
            var array = arrayList.ToArray();
            UpdateSize(array.Length);

            for (int i = _currentCount + array.Length, j = _currentCount; j > 0; i--, j--)
            {
                _array[i - 1] = _array[j - 1];
            }
            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }

            _currentCount += array.Length;
        }

        public void AddBack(IArrayList arrayList)
        {
            var array = arrayList.ToArray();
            UpdateSize(array.Length);

            for (int i = _currentCount, j = 0; j < array.Length; i++, j++)
            {
                _array[i] = array[j];
            }

            _currentCount += array.Length;
        }

        public void AddByIndex(int index, IArrayList arrayList)
        {
            if (index < 0 || index > _currentCount)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            UpdateSize(arrayList.Length);

            for (int i = 0; i < arrayList.Length; i++)
            {
                _array[_currentCount++] = _array[index + i];
            }
            for (int i = index, k = 0; k < arrayList.Length; ++i, ++k)
            {
                _array[i] = arrayList[k];
            }

        }

        public int DeleteByValue(int value)
        {
            int index = -1;
            for (int i = 0; i < _currentCount; i++)
            {
                if (_array[i] == value)
                {
                    index = i;
                    break;
                }
            }

            --_currentCount;
            for (int i = index; i < _currentCount; i++)
            {
                _array[i] = _array[i + 1];
            }

            return index;
        }

        public int Max()
        {
            int maxI = MaxIndex();

            return _array[maxI];
        }

        public int MaxIndex()
        {
            if (_currentCount == 0)
            {
                throw new ArgumentException("Array is empty!");
            }

            int maxI = 0;
            for (int i = 1; i < _currentCount; i++)
            {
                if (_array[maxI] < _array[i])
                {
                    maxI = i;
                }
            }

            return maxI;
        }

        public int Min()
        {
            int minI = MinIndex();
            return _array[minI];
        }

        public int MinIndex()
        {
            if (_currentCount == 0)
            {
                throw new ArgumentException("Array is empty!");
            }

            int minI = 0;
            for (int i = 1; i < _currentCount; i++)
            {
                if (_array[minI] > _array[i])
                {
                    minI = i;
                }
            }

            return minI;
        }

        public int RemoveFront()
            => RemoveByIndex(0);

        public int RemoveBack()
            => RemoveByIndex(_currentCount - 1);

        public int RemoveByIndex(int index)
        {
            int result;
            try
            {
                result = this[index];
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException(
                    "Array is empty or index is incorrect!");
            }
            for (int i = index; i < _currentCount - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            --_currentCount;

            return result;
        }

        public int[] RemoveFront(int count)
            => RemoveByIndex(0, count);


        public int[] RemoveBack(int count)
        {

            int[] result = new int[count];
            if (count > _currentCount)
            {
                throw new ArgumentException("Invalid index or count!");
            }
            for (int i = 0; i < count; i++)
            {
                result[i] = _array[--_currentCount - i];
            }

            return result;
        }

        public int[] RemoveByIndex(int index, int count)
        {
            int[] result = new int[count];
            if ((index + count) > _currentCount)
            {
                throw new ArgumentException("Invalid index or count!");
            }

            for (int i = index, j = 0; j < count; i++, j++)
            {
                result[j] = _array[i];
            }
            for (int i = index; i < _currentCount - count; i++)
            {
                _array[i] = _array[i + count];
            }

            _currentCount -= count;

            return result;
        }

        public int IndexOf(int element)
        {
            int result = -1;
            for (int i = 0; i < _currentCount; i++)
            {
                if (_array[i] == element)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public int RemoveAll(int value)
        {
            int result = 0;

            for (int i = 0; i < _currentCount; i++)
            {
                if (_array[i] == value)
                {
                    result++;
                }
            }
            if (result != 0)
            {
                int[] tempArray = new int[_currentCount - result];
                int j = 0;
                for (int i = 0; i < _currentCount; i++)
                {
                    if (_array[i] != value)
                    {
                        tempArray[j++] = _array[i];
                    }
                }
                for (int i = 0; i < _currentCount - result; i++)
                {
                    _array[i] = tempArray[i];
                }
                _currentCount -= result;
            }

            return result;
        }

        public void Reverse()
        {
            for (int i = 0; i < _currentCount / 2; i++)
            {
                var tmp = _array[i];
                _array[i] = _array[_currentCount - i - 1];
                _array[_currentCount - i - 1] = tmp;
            }
        }

        public void Sort(bool ascending = true)
        {
            for (int i = 1; i < _currentCount; ++i)
            {
                int temp = _array[i];
                int j = i - 1;
                while (j >= 0 && (((_array[j] < temp) == ascending) == false))
                {
                    _array[j + 1] = _array[j--];
                }

                _array[j + 1] = temp;
            }
        }

        public int Remove(int value)
        {
            int index = IndexOf(value);
            try
            {
                return RemoveByIndex(index);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException("Value is Not in ArrayList.");
            }
        }


        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _currentCount; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int[] ToArray()
        {
            int[] result = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                result[i] = _array[i];
            }

            return result;
        }

        private void UpdateSize(int countToAdd = 1)
        {
            if ((_currentCount + countToAdd) >= _array.Length)
            {
                int newSize = (int)((_array.Length + countToAdd) * 2);
                int[] newArray = new int[newSize];
                for (int i = 0; i < _currentCount; i++)
                {
                    newArray[i] = _array[i];
                }

                _array = newArray;
            }
        }
    }
}