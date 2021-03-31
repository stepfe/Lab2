using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    public class Tree<T>
    {
        Node<T> head;

        public Node<T> getRoot()
        {
            return head;
        }
        public void add(int key, T value)
        {
            Node<T> newNode = new Node<T>(key, value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                bool isNewNodePlaced = false;
                Node<T> curNode = head;
                while (!isNewNodePlaced)
                {
                    if (key >= curNode.getKey())
                    {
                        if (curNode.getRight() == null)
                        {
                            curNode.setRight(newNode);
                            isNewNodePlaced = true;
                        }
                        else
                        {
                            curNode = curNode.getRight();
                        }
                    }
                    else
                    {
                        if (curNode.getLeft() == null)
                        {
                            curNode.setLeft(newNode);
                            isNewNodePlaced = true;
                        }
                        else
                        {
                            curNode = curNode.getLeft();
                        }
                    }
                }
            }
        }

        void removeNode(Node<T> nodeToDelete, Node<T> parent)
        {
            bool isLeft = false;
            if (parent.getLeft() == nodeToDelete)
                isLeft = true;

            if (nodeToDelete.getRight() == null)
            {
                if (nodeToDelete.getLeft() == null)
                {
                    if (isLeft)
                        parent.setLeft(null);
                    else
                        parent.setRight(null);
                }
                else
                {
                    if (isLeft)
                        parent.setLeft(nodeToDelete.getLeft());
                    else
                        parent.setRight(nodeToDelete.getLeft());
                }
            }
            else
            {
                if (nodeToDelete.getLeft() == null)
                {
                    if(isLeft)
                        parent.setLeft(nodeToDelete.getRight());
                    else
                        parent.setRight(nodeToDelete.getRight());
                }
                else
                {
                    if (isLeft)
                        parent.setLeft(nodeToDelete.getRight());
                    else
                        parent.setRight(nodeToDelete.getRight());

                    getMinNode(nodeToDelete.getRight()).setLeft(nodeToDelete.getLeft());
                }
            }
        }

        Node<T> getMinNode(Node<T> root)
        {
            while (root.getLeft() != null)
            {
                root = root.getLeft();
            }
            return root;
        }

        public void removeByKey(int key)
        {
            Node<T> nodeToDelete = null;
            Node<T> parent = null;
            if (head != null)
            {
                Node<T> curNode = head;
                bool isSearchCompleted = false;
                while (!isSearchCompleted)
                {
                    if (key == curNode.getLeft().getKey())
                    {
                        nodeToDelete = curNode.getLeft();
                        parent = curNode;
                        isSearchCompleted = true;
                    }
                    else if (key == curNode.getRight().getKey())
                    {
                        nodeToDelete = curNode.getRight();
                        parent = curNode;
                        isSearchCompleted = true;
                    }
                    else if (key > curNode.getKey())
                    {
                        if (curNode.getRight() == null)
                        {
                            isSearchCompleted = true;
                        }
                        else
                        {
                            curNode = curNode.getRight();
                        }
                    }
                    else
                    {
                        if (curNode.getLeft() == null)
                        {
                            isSearchCompleted = true;
                        }
                        else
                        {
                            curNode = curNode.getLeft();
                        }
                    }
                }
                removeNode(nodeToDelete, parent);
            }

            
        }

        public Node<T> find(int key)
        {
            Node<T> findedNode = null;
            if (head != null)
            {
                Node<T> curNode = head;
                bool isSearchCompleted = false;
                while (!isSearchCompleted)
                {
                    if(key == curNode.getKey())
                    {
                        findedNode = curNode;
                        isSearchCompleted = true;
                    }
                    else if (key > curNode.getKey())
                    {
                        if (curNode.getRight() == null)
                        {
                            isSearchCompleted = true;
                        }
                        else
                        {
                            curNode = curNode.getRight();
                        }
                    }
                    else
                    {
                        if (curNode.getLeft() == null)
                        {
                            isSearchCompleted = true;
                        }
                        else
                        {
                            curNode = curNode.getLeft();
                        }
                    }
                }
            }
            return findedNode;
        }
    }
}
