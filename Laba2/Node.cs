using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    public class Node<T>
    {
        Node<T> left;
        Node<T> right;
        int key;
        T value;

        public Node(int key, T value)
        {
            left = null;
            right = null;
            this.value = value;
            this.key = key;
        }
        public void setLeft(Node<T> node)
        {
            left = node;
        }

        public void setRight(Node<T> node)
        {
            right = node;
        }

        public Node<T> getLeft()
        {
            return left;
        }

        public Node<T> getRight()
        {
            return right;
        }

        public T getValue()
        {
            return value;
        }

        public int getKey()
        {
            return key;
        }

    }
}
