
using ArraysLibrary;
using NUnit.Framework;
using System;

namespace TestArrayList
{
    public class ArrayListTests
    {
        private IArrayList resultArrayList;

        private ArrayList Initialize(int[] array)
        {
            ArrayList arrayList = new ArrayList(array);
            return arrayList;
        }

        [SetUp]
        public void Setup()
        {
            resultArrayList = new ArrayList();
        }

        [TestCase(-1)]
        public void IndexerGet_WhenIndexIsOutOfRange_ShouldThrowIndexIsOutOfRangeException(int index)
        {
            try
            {
                var item = resultArrayList[index];
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(-1)]
        public void IndexerSet_WhenIndexIsOutOfRange_ShouldThrowIndexIsOutOfRangeException(int index)
        {
            try
            {
                resultArrayList[index] = 1;
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[0] { }, 0, new[] { 0 })]
        [TestCase(new[] { 0 }, 1, new[] { 1, 0 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 10, new[] { 10, 1, 2, 3, 4 })]
        public void AddFront_WhenElementAdded_ShouldFillArray(int[] initArray, int value, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            resultArrayList.AddFront(value);

            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(sourceArray[i], resultArrayList[i]);
            }
        }

        [TestCase(new int[0] { }, 0, new[] { 0 })]
        [TestCase(new[] { 0 }, 1, new[] { 0, 1 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 10, new[] { 1, 2, 3, 4, 10 })]
        public void AddBack_WhenElementAdded_ShouldFillArray(int[] initArray, int value, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            resultArrayList.AddBack(value);

            for (int i = 0; i < resultArrayList.Length; i++)
            {
                Assert.AreEqual(sourceArray[i], resultArrayList[i]);
            }
        }

        [TestCase(new int[0] { }, 1, 100)]
        [TestCase(new[] { 0 }, 2, 100)]
        [TestCase(new[] { 1, 2, 3, 4 }, 10, 10)]
        public void AddByIndex_Element_WhenIndexIsOutOFRange_ShouldTrowIndexOutOfRangeException(int[] initArray, int index, int value)
        {
            ArrayList resultArrayList = Initialize(initArray);

            try
            {
                resultArrayList.AddByIndex(index, value);
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.AreEqual("Index is out of range", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[0] { }, 0, 100, new[] { 100 })]
        [TestCase(new[] { 0 }, 0, 100, new[] { 100, 0 })]
        [TestCase(new[] { 0 }, 1, 100, new[] { 0, 100 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 2, 100, new[] { 1, 2, 100, 3, 4 })]
        public void AddByIndex_WhenElementsAdded_ShouldFillArray(int[] initArray, int index, int value, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            resultArrayList.AddByIndex(index, value);

            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(sourceArray[i], resultArrayList[i]);
            }
        }

        [TestCase(new int[0] { }, new[] { 100 }, new[] { 100 })]
        [TestCase(new[] { 0 }, new[] { 100 }, new[] { 100, 0 })]
        [TestCase(new[] { 100 }, new[] { 0 }, new[] { 0, 100 })]
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 100, 200 }, new[] { 100, 200, 1, 2, 3, 4 })]
        public void AddFront_ArrayList_WhenElementsAddedAsArray_ShouldFillArray(int[] initArray, int[] insertArray, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            ArrayList insertArrayList = Initialize(insertArray);
            resultArrayList.AddFront(insertArrayList);
            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(sourceArray[i], resultArrayList[i]);
            }
        }

        [TestCase(new int[0] { }, new[] { 100 }, new[] { 100 })]
        [TestCase(new[] { 0 }, new[] { 100 }, new[] { 0, 100 })]
        [TestCase(new[] { 100 }, new[] { 0 }, new[] { 100, 0 })]
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 100, 200 }, new[] { 1, 2, 3, 4, 100, 200 })]
        public void AddBack_ArrayList_WhenElementsAddedAsArray_ShouldFillArray(int[] initArray, int[] insertArray, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            ArrayList insertArrayList = Initialize(insertArray);
            resultArrayList.AddBack(insertArrayList);
            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(sourceArray[i], resultArrayList[i]);
            }
        }

        [TestCase(new int[0] { }, 0, new[] { 100 }, new[] { 100 })]
        [TestCase(new[] { 0 }, 0, new[] { 100 }, new[] { 100, 0 })]
        [TestCase(new[] { 0 }, 1, new[] { 100 }, new[] { 0, 100 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 3, new[] { 100, 200 }, new[] { 1, 2, 3, 100, 200, 4 })]
        public void AddByIndex_ArrayList_WhenElementsAddedAsArray_ShouldFillArray(int[] initArray, int index, int[] insertArray, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            ArrayList insertArrayList = Initialize(insertArray);
            resultArrayList.AddByIndex(index, insertArrayList);
            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(sourceArray[i], resultArrayList[i]);
            }
        }

        [TestCase(new int[0] { }, 10, new[] { 100 })]
        [TestCase(new[] { 0 }, 10, new[] { 100 })]
        [TestCase(new[] { 0 }, -10, new[] { 100 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 100, new[] { 100, 200 })]
        public void AddByIndex_ArrayList_WhenIndexIsOutOFRange_ShouldTrowIndexOutOfRangeException(int[] initArray, int index, int[] insertArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            ArrayList insertArrayList = Initialize(insertArray);
            try
            {
                resultArrayList.AddByIndex(index, insertArrayList);
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.AreEqual("Index is out of range", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }


        [TestCase(new int[0] { }, 0, new int[0] { })]
        [TestCase(new[] { 0, 100 }, 0, new[] { 100 })]
        [TestCase(new[] { 0, 100 }, 100, new[] { 0 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 3, new[] { 1, 2, 4 })]
        public void DeleteByValue_ShouldDeleteElementByValue(int[] initArray, int value, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            resultArrayList.DeleteByValue(value);
            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(sourceArray[i], resultArrayList[i]);
            }
        }

        [TestCase(new[] { 0, 100 }, 0)]
        [TestCase(new[] { 0, -100 }, -100)]
        [TestCase(new[] { 1, 2, 3, 4 }, 1)]
        public void GetMinElement_ShouldGetMinIndex(int[] initArray, int resultMin)
        {
            ArrayList resultArrayList = Initialize(initArray);
            var actualMin = resultArrayList.Min();
            Assert.AreEqual(actualMin, resultMin);
        }

        [Test]
        public void GetMinElement_WhenArrayIsEmpty_ShouldTrowArgumentException()
        {

            try
            {
                resultArrayList.Min();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Array is empty!", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new[] { 0, 100 }, 100)]
        [TestCase(new[] { 0, -100 }, 0)]
        [TestCase(new[] { 1, 2, 3, 4 }, 4)]
        public void GetMaxElement_ShouldGetMaxIndex(int[] initArray, int resultMax)
        {
            ArrayList resultArrayList = Initialize(initArray);
            var actualMax = resultArrayList.Max();
            Assert.AreEqual(actualMax, resultMax);
        }

        [TestCase(new int[0] { })]
        public void GetMaxElement_WhenArrayIsEmpty_ShouldTrowArgumentException(int[] initArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            try
            {
                resultArrayList.Max();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Array is empty!", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new[] { 0, 100 }, 0)]
        [TestCase(new[] { 0, -100 }, 1)]
        [TestCase(new[] { 1, 2, 3, -4 }, 3)]
        public void GetMinElementIndex_ShouldGetMinIndex(int[] initArray, int resultMinIndex)
        {
            ArrayList resultArrayList = Initialize(initArray);
            var actualMinIndex = resultArrayList.MinIndex();
            Assert.AreEqual(actualMinIndex, resultMinIndex);
        }

        [TestCase(new int[0] { })]
        public void GetMinElementIndex_WhenArrayIsEmpty_ShouldTrowArgumentException(int[] initArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            try
            {
                resultArrayList.MinIndex();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Array is empty!", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new[] { 0, 100 }, 1)]
        [TestCase(new[] { 0, -100 }, 0)]
        [TestCase(new[] { 1, 2, 3, 4 }, 3)]
        public void GetMaxElementIndex_ShouldGetMaxIndex(int[] initArray, int resultMaxIndex)
        {
            ArrayList resultArrayList = Initialize(initArray);
            var actualMaxIndex = resultArrayList.MaxIndex();
            Assert.AreEqual(actualMaxIndex, resultMaxIndex);
        }

        [TestCase(new int[0] { })]
        public void GetMaxElementIndex_WhenArrayIsEmpty_ShouldTrowArgumentException(int[] initArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            try
            {
                resultArrayList.MaxIndex();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Array is empty!", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[0] { }, 1)]
        [TestCase(new[] { 0, 1 }, 2)]
        [TestCase(new[] { 0, 1 }, -1)]
        public void RemoveByIndex_WhenArrayIsEmptyOrIndexIsOutOfRange_ShouldTrowArgumentException(int[] initArray, int index)
        {
            ArrayList resultArrayList = Initialize(initArray);
            try
            {
                resultArrayList.RemoveByIndex(index);
            }
            catch (IndexOutOfRangeException ex)
            {

                Assert.Pass();
            }

            Assert.Fail();
        }



        [TestCase(new int[0] { })]
        public void RemoveFront_WhenArrayIsEmpty_ShouldTrowArgumentException(int[] initArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            try
            {
                resultArrayList.RemoveFront();
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[0] { })]
        public void RemoveBack_WhenArrayIsEmpty_ShouldTrowArgumentException(int[] initArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            try
            {
                resultArrayList.RemoveBack();
            }
            catch (IndexOutOfRangeException)
            {

                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new[] { 0 }, 0, new int[0] { })]
        [TestCase(new[] { 0, 1 }, 0, new[] { 1 })]
        [TestCase(new[] { 0, 1 }, 1, new[] { 0 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 1, 2, 4 })]
        public void RemoveByIndex_ShouldRemoveElementByIndex(int[] initArray, int index, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            resultArrayList.RemoveByIndex(index);
            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(sourceArray[i], resultArrayList[i]);
            }
        }


        [TestCase(new[] { 0 }, new int[0] { })]
        [TestCase(new[] { 0, 1 }, new[] { 1 })]
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 2, 3, 4 })]
        public void RemoveFront_ShouldRemoveFirstElementOfArrayList(int[] initArray, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            resultArrayList.RemoveFront();
            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(sourceArray[i], resultArrayList[i]);
            }
        }

        [TestCase(new[] { 0 }, new int[0] { })]
        [TestCase(new[] { 0, 1 }, new[] { 0 })]
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3 })]
        public void RemoveBack_ShouldRemoveLastElementOfArrayList(int[] initArray, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            resultArrayList.RemoveBack();
            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(sourceArray[i], resultArrayList[i]);
            }
        }

        [TestCase(new[] { 0 }, 0, 1, new int[0] { }, new[] { 0 })]
        [TestCase(new[] { 0, 1 }, 0, 1, new int[0] { }, new[] { 0, 1 })]
        [TestCase(new[] { 0, 1 }, 1, 1, new[] { 0 }, new[] { 1 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 1, 2, new[] { 1, 4 }, new[] { 2, 3 })]
        public void RemoveByIndex_ShouldRemoveNElementsByIndex(int[] initArray, int index, int count, int[] sourceArrayList, int[] resultArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            int[] returnArray = resultArrayList.RemoveByIndex(index, count);
            for (int i = 0; i < sourceArrayList.Length; i++)
            {
                Assert.AreEqual(sourceArrayList[i], resultArrayList[i]);
            }
            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(returnArray[i], resultArray[i]);
            }
        }

        [TestCase(new int[0] { }, 1, 1)]

        public void RemoveByIndex_WhenArrayIsEmpty_ShouldTrowArgumentException(int[] initArray, int index, int count)
        {
            ArrayList resultArrayList = Initialize(initArray);

            try
            {
                int[] returnArray = resultArrayList.RemoveByIndex(index, count);
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new[] { 0 }, 1, 1)]
        [TestCase(new[] { 0, 1 }, 0, 3)]
        [TestCase(new[] { 1, 2, 3, 4 }, 3, 2)]
        public void RemoveByIndex_WhenArrayIndexIsOutOfRange_ShouldTrowArgumentException(int[] initArray, int index, int count)
        {
            ArrayList resultArrayList = Initialize(initArray);

            try
            {
                int[] returnArray = resultArrayList.RemoveByIndex(index, count);
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new[] { 0 }, 1, new int[0] { }, new[] { 0 })]
        [TestCase(new[] { 0, 1 }, 2, new int[0] { }, new[] { 0, 1 })]
        [TestCase(new[] { 0, 1 }, 1, new[] { 1 }, new[] { 0 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 3, 4 }, new[] { 1, 2 })]
        public void RemoveFront_ShouldRemoveNElementsFromStartArrayList(int[] initArray, int count, int[] sourceArrayList, int[] resultArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            int[] returnArray = resultArrayList.RemoveFront(count);
            for (int i = 0; i < sourceArrayList.Length; i++)
            {
                Assert.AreEqual(sourceArrayList[i], resultArrayList[i]);
            }
            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(returnArray[i], resultArray[i]);
            }
        }

        [TestCase(new int[0] { }, 1)]

        public void RemoveFront_WhenArrayIsEmpty_ShouldTrowArgumentException(int[] initArray, int count)
        {
            ArrayList resultArrayList = Initialize(initArray);

            try
            {
                int[] returnArray = resultArrayList.RemoveFront(count);
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new[] { 0 }, 2)]
        [TestCase(new[] { 0, 1 }, 3)]
        [TestCase(new[] { 1, 2, 3, 4 }, 5)]
        public void RemoveFront_WhenNumberOfElementsGreaterThanNumberOfElementsInArrayList_ShouldTrowArgumentException(int[] initArray, int count)
        {
            ArrayList resultArrayList = Initialize(initArray);

            try
            {
                int[] returnArray = resultArrayList.RemoveFront(count);
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new[] { 0 }, 1, new int[0] { }, new[] { 0 })]
        [TestCase(new[] { 0, 1 }, 1, new[] { 0 }, new[] { 1 })]
        [TestCase(new[] { 0, 1 }, 2, new int[0] { }, new[] { 1, 0 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 1, new[] { 1, 2, 3 }, new[] { 4 })]
        [TestCase(new[] { 0, 1, 2, 3, 4, 5, 6 }, 3, new[] { 0, 1, 2, 3 }, new[] { 6, 4, 2 })]//Unreal trash
        public void RemoveBack_ShouldRemoveNElementsFromBackOfArrayList(int[] initArray, int count, int[] sourceArrayList, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);
            int[] returnArray = resultArrayList.RemoveBack(count);
            for (int i = 0; i < sourceArrayList.Length; i++)
            {
                Assert.AreEqual(sourceArrayList[i], resultArrayList[i]);
            }
            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(returnArray[i], sourceArray[i]);
            }
        }

        [TestCase(new int[0] { }, 1)]

        public void RemoveBack_WhenArrayIsEmpty_ShouldTrowArgumentException(int[] initArray, int count)
        {
            ArrayList resultArrayList = Initialize(initArray);

            try
            {
                int[] returnArray = resultArrayList.RemoveBack(count);
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new[] { 0 }, 2)]
        [TestCase(new[] { 0, 1 }, 3)]
        [TestCase(new[] { 1, 2, 3, 4 }, 5)]
        public void RemoveBack_WhenNumberOfElementsGreaterThanNumberOfElementsInArrayList_ShouldTrowArgumentException(int[] initArray, int count)
        {
            ArrayList resultArrayList = Initialize(initArray);

            try
            {
                int[] returnArray = resultArrayList.RemoveBack(count);
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new[] { 0 }, 0, 0)]
        [TestCase(new[] { 0, 1 }, 1, 1)]
        [TestCase(new[] { 0, 1 }, 2, -1)]
        [TestCase(new[] { 1, 2, 3, 4 }, 4, 3)]
        [TestCase(new[] { 0, 1, 2, 3, 4, 5, 6 }, 5, 5)]
        public void IndexOf_ShouldReturnIndexOfFirstElement(int[] initArray, int element, int sourceIndex)
        {
            ArrayList resultArrayList = Initialize(initArray);
            Assert.AreEqual(resultArrayList.IndexOf(element), sourceIndex);
        }

        [TestCase(new[] { 0 }, 0, 0, new int[0] { })]
        [TestCase(new[] { 0, 1 }, 1, 1, new[] { 0 })]
        [TestCase(new[] { 0, 1, 2, 3, 2 }, 2, 2, new[] { 0, 1, 3, 2 })]
        [TestCase(new[] { 0, 1, 2, 3, 4, 5, 5, 6 }, 5, 5, new[] { 0, 1, 2, 3, 4, 5, 6 })]
        public void Remove_ShouldRemoveValueFromArrayListMeetFirst_ReturnsIndexOfDeletedElementWithValue
            (int[] initArray, int value, int sourceindex, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);

            Assert.AreEqual(resultArrayList.Remove(value), sourceindex);
            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(resultArrayList[i], sourceArray[i]);
            }
        }

        [TestCase(new[] { 0 }, 10)]
        [TestCase(new[] { 0, 1 }, 10)]
        [TestCase(new[] { 0, 1, 2, 3, 2 }, 10)]
        [TestCase(new[] { 0, 1, 2, 3, 4, 5, 5, 6 }, 10)]
        public void Remove_ValueIsNotInArray_ShouldThrowArgumentException(int[] initArray, int value)
        {
            ArrayList resultArrayList = Initialize(initArray);
            try
            {
                resultArrayList.Remove(value);
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new[] { 0 }, 0, 1, new int[0] { })]
        [TestCase(new[] { 0, 1 }, 1, 1, new[] { 0 })]
        [TestCase(new[] { 0, 1 }, 2, 0, new[] { 0, 1 })]
        [TestCase(new[] { 1, 2, 3, 2 }, 2, 2, new[] { 1, 3 })]
        [TestCase(new[] { 0, 1, 2, 0, 4, 5, 0 }, 0, 3, new[] { 1, 2, 4, 5 })]
        public void RemoveAll_ShouldRemoveValueFromAllArrayList_ReturnsCountOfElementsWithValue
            (int[] initArray, int value, int sourceCount, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);

            Assert.AreEqual(resultArrayList.RemoveAll(value), sourceCount);
            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(resultArrayList[i], sourceArray[i]);
            }
        }

        [TestCase(new[] { 0 }, new[] { 0 })]
        [TestCase(new[] { 0, 1 }, new[] { 1, 0 })]
        [TestCase(new[] { 0, 1, 2 }, new[] { 2, 1, 0 })]
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1 })]
        public void Reverse_ShouldReverseArrayList(int[] initArray, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);

            resultArrayList.Reverse();
            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(resultArrayList[i], sourceArray[i]);
            }
        }

        [TestCase(new[] { 0 }, new[] { 0 })]
        [TestCase(new[] { 0, 1 }, new[] { 0, 1 })]
        [TestCase(new[] { 2, 1, 0 }, new[] { 0, 1, 2 })]
        [TestCase(new[] { 4, 3, 2, 1 }, new[] { 1, 2, 3, 4 })]
        [TestCase(new[] { 10, 2, 23, 14, -3 }, new[] { -3, 2, 10, 14, 23 })]
        public void SortW_ShouldShouldSortArrayList_Ascending(int[] initArray, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);

            resultArrayList.Sort();
            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(resultArrayList[i], sourceArray[i]);
            }
        }

        [TestCase(new[] { 0 }, new[] { 0 })]
        [TestCase(new[] { 0, 1 }, new[] { 1, 0 })]
        [TestCase(new[] { 2, 1, 0 }, new[] { 2, 1, 0 })]
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 1, 2 }, new[] { 4, 3, 2, 2, 1, 1 })]
        public void SortWhithBoolAscendingEqualFalse_ShouldShouldSortArrayList_Descending(int[] initArray, int[] sourceArray)
        {
            ArrayList resultArrayList = Initialize(initArray);

            resultArrayList.Sort(false);
            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(resultArrayList[i], sourceArray[i]);
            }
        }

    }
}