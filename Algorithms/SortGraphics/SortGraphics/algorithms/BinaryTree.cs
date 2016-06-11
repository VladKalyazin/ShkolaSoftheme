using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortGraphics
{
    public interface ISortingBinaryTree<T> where T : IComparable<T>
    {
        T Value { get; set; }
        BinaryTree<T> Right { get; set; }
        BinaryTree<T> Left { get; set; }
        BinaryTree<T> Parent { get; set; }

        void Insert(T item);
    }

    public class BinaryTree<T> : ISortingBinaryTree<T>
        where T : IComparable<T>
    {
        private bool _HasValue;

        public T Value { get; set; }

        public BinaryTree<T> Right { get; set; }

        public BinaryTree<T> Left { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public BinaryTree()
        {
            _HasValue = false;
        }

        public BinaryTree(T head)
        {
            Value = head;
            _HasValue = true;
        }

        public void Insert(T item)
        {
            BinaryTree<T> pointer = this;

            if (!_HasValue)
            {
                Value = item;
                _HasValue = true;
                return;
            }

            while (pointer != null)
            {
                if (item.CompareTo(pointer.Value) <= 0)
                {
                    if (pointer.Left == null)
                    {
                        pointer.Left = new BinaryTree<T>(item);
                        pointer.Left.Parent = pointer;
                        break;
                    }
                    else
                    {
                        pointer = pointer.Left;
                    }
                }
                else
                {
                    if (pointer.Right == null)
                    {
                        pointer.Right = new BinaryTree<T>(item);
                        pointer.Right.Parent = pointer;
                        break;
                    }
                    else
                    {
                        pointer = pointer.Right;
                    }
                }
            }
        }

        public void InsertList(List<T> array)
        {
            foreach (var value in array)
                Insert(value);
        }

        public void RewriteSortedList(List<T> array)
        {
            int iterator = 0;
            BinaryTree<T> pointer = this;

            while (pointer != null)
            {
                if (pointer.Left != null)
                {
                    pointer = pointer.Left;
                }
                else
                {
                    array[iterator++] = pointer.Value;
                    if (pointer.Parent?.Left == pointer)
                    {
                        pointer.Parent.Left = pointer.Right;
                    }
                    else if (pointer.Parent?.Right == pointer)
                    {
                        pointer.Parent.Right = pointer.Right;
                    }
                    if (pointer.Right != null)
                        pointer.Right.Parent = pointer.Parent;
                    pointer = pointer.Right ?? pointer.Parent;
                }
            }
        }

        public void InsertList(List<T> array, int begin, int end)
        {
            for (int i = begin; i <= end; i++)
                Insert(array[i]);
        }

        public void RewriteSortedList(List<T> array, int begin, int end)
        {
            int iterator = begin;
            BinaryTree<T> pointer = this;

            while (pointer != null)
            {
                if (pointer.Left != null)
                {
                    pointer = pointer.Left;
                }
                else
                {
                    array[iterator++] = pointer.Value;
                    if (pointer.Parent?.Left == pointer)
                    {
                        pointer.Parent.Left = pointer.Right;
                    }
                    else if (pointer.Parent?.Right == pointer)
                    {
                        pointer.Parent.Right = pointer.Right;
                    }
                    if (pointer.Right != null)
                        pointer.Right.Parent = pointer.Parent;
                    pointer = pointer.Right ?? pointer.Parent;
                }
            }
        }

    }

    public static class SortingBinaryTree
    {
        public static void Sort<T>(List<T> array)
            where T: IComparable<T>
        {
            var sortingTree = new BinaryTree<T>();
            sortingTree.InsertList(array);
            sortingTree.RewriteSortedList(array);
        }

        public static void Sort<T>(List<T> array, int begin, int end)
            where T : IComparable<T>
        {
            var sortingTree = new BinaryTree<T>();
            sortingTree.InsertList(array, begin, end);
            sortingTree.RewriteSortedList(array, begin, end);
        }
    }
}