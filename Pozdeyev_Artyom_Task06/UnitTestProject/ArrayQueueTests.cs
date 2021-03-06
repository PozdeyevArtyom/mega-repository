﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary;

namespace MyLibraryTests
{
    [TestClass]
    public class ArrayQueueTests
    {
        [TestMethod]
        public void DefaultInitTest()
        {
            MyQueue<int> Queue = new MyArrayQueue<int>();
            Assert.AreEqual(Queue.Count, 0);
            Assert.AreEqual((Queue as MyArrayQueue<int>).Capacity, 10);
        }

        [TestMethod]
        public void CustomCapacityInitTest()
        {
            int actualCapacity = 24;
            MyQueue<int> Queue = new MyArrayQueue<int>(actualCapacity);
            Assert.AreEqual(Queue.Count, 0);
            Assert.AreEqual((Queue as MyArrayQueue<int>).Capacity, actualCapacity);
        }

        [TestMethod]
        public void CustomCapacityLessThanZeroInitTest()
        {
            int actualCapacity = -83;
            try
            {
                MyQueue<int> Queue = new MyArrayQueue<int>(actualCapacity);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "Вместимость очереди должна быть натуральным числом.");
            }
        }

        [TestMethod]
        public void CopyConstructorTest()
        {
            MyQueue<int> Queue = new MyArrayQueue<int>();
            Queue.Enqueue(1);
            Queue.Enqueue(2);
            MyQueue<int> Queue2 = new MyArrayQueue<int>(Queue);
            Assert.AreEqual(Queue2, Queue);
        }

        [TestMethod]
        public void ClearTest()
        {
            MyQueue<int> Queue = new MyArrayQueue<int>();
            Queue.Enqueue(1);
            Queue.Enqueue(2);
            Queue.Clear();
            Assert.AreEqual(Queue.Count, 0);
            Assert.AreEqual((Queue as MyArrayQueue<int>).Capacity, 10);
        }

        [TestMethod]
        public void ContainTest()
        {
            MyQueue<int> Queue = new MyArrayQueue<int>();
            Queue.Enqueue(31);
            Queue.Enqueue(9);
            Assert.AreEqual(Queue.Contains(31), true);
        }

        [TestMethod]
        public void NotContainTest()
        {
            MyQueue<int> Queue = new MyArrayQueue<int>();
            Queue.Enqueue(31);
            Queue.Enqueue(9);
            Assert.AreEqual(Queue.Contains(63), false);
        }

        [TestMethod]
        public void CopyToArray()
        {
            int[] array = new int[2];
            MyQueue<int> Queue = new MyArrayQueue<int>();
            Queue.Enqueue(51);
            Queue.Enqueue(94);
            Queue.CopyTo(array, 0);
            Assert.AreEqual(array[0], 51);
            Assert.AreEqual(array[1], 94);
        }

        [TestMethod]
        public void InvalidCopyToArray()
        {
            int[] array = new int[2];
            MyQueue<int> Queue = new MyArrayQueue<int>();
            Queue.Enqueue(51);
            Queue.Enqueue(94);
            try
            {
                Queue.CopyTo(array, 2);
            }
            catch (IndexOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "Индекс вне диапазона.");
            }
        }

        [TestMethod]
        public void EnqueueDequeueTest()
        {
            MyQueue<int> Queue = new MyArrayQueue<int>();
            Queue.Enqueue(85);
            Queue.Enqueue(48);
            Assert.AreEqual(Queue.Dequeue(), 85);
            Assert.AreEqual(Queue.Dequeue(), 48);
        }

        public void EnqueueMoreThanCapacityTest()
        {
            int actualCapacity = 1;
            MyQueue<int> Queue = new MyArrayQueue<int>(actualCapacity);
            Queue.Enqueue(70);
            Queue.Enqueue(52);
            Assert.AreEqual(Queue.Count, 2);
            Assert.AreEqual((Queue as MyArrayQueue<int>).Capacity, actualCapacity + 10);
        }

        [TestMethod]
        public void DequeueFromEmptyQueueTest()
        {
            MyQueue<int> Queue = new MyArrayQueue<int>();
            try
            {
                Queue.Dequeue();
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "Очередь пуста.");
            }
        }

        [TestMethod]
        public void PeekTest()
        {
            MyQueue<int> Queue = new MyArrayQueue<int>();
            Queue.Enqueue(98);
            Queue.Enqueue(20);
            Assert.AreEqual(Queue.Peek(), 98);
        }

        [TestMethod]
        public void PeekFromEmptyTest()
        {
            MyQueue<int> Queue = new MyArrayQueue<int>();
            try
            {
                Queue.Peek();
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "Очередь пуста.");
            }

        }
    }
}
