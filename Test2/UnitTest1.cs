using NUnit.Framework;
using Laba2;

namespace Test2
{
    
    public class Tests
    {
        private Tree<int> tree;
        [SetUp]
        public void Setup()
        {
            tree = new Tree<int>();
        }

        [Test]
        public void ADD_IN_EMPTY()
        {
            tree.add(1, 1);
            Assert.AreEqual(1, tree.getRoot().getValue());
        }

        [Test]
        public void ADD_LEFT()
        {
            tree.add(2, 2);
            tree.add(1, 1);
            Assert.AreEqual(1, tree.getRoot().getLeft().getValue());
        }

        [Test]
        public void ADD_RIGHT()
        {
            tree.add(2, 2);
            tree.add(3, 3);
            Assert.AreEqual(3, tree.getRoot().getRight().getValue());
        }

        [Test]
        public void REMOVE_EMPTY()
        {
            tree.removeByKey(0);
            Assert.AreEqual(null, tree.getRoot());
        }

        public void REMOVE_ROOT()
        {
            tree.add(0, 0);
            tree.removeByKey(0);
            Assert.AreEqual(null, tree.getRoot());
        }

        [Test]
        public void REMOVE_ONLY_CHILDREN()
        {
            bool isOk = false;
            tree.add(2, 2);
            tree.add(1, 1);
            tree.add(3, 3);
            tree.removeByKey(3);
            if (tree.getRoot().getLeft().getValue() == 1 && tree.getRoot().getRight() == null)
                isOk = true;
            Assert.AreEqual(true, isOk);
        }

        [Test]
        public void REMOVE_WITH_LEFT_CHILD()
        {
            bool isOk = false;
            tree.add(3, 3);
            tree.add(2, 2);
            tree.add(1, 1);
            tree.removeByKey(2);
            if (tree.getRoot().getLeft().getValue() == 1 && tree.getRoot().getRight() == null)
                isOk = true;
            Assert.AreEqual(true, isOk);
        }

        [Test]
        public void REMOVE_WITH_RIGHT_CHILD()
        {
            bool isOk = false;
            tree.add(3, 3);
            tree.add(1, 1);
            tree.add(2, 2);
            tree.removeByKey(1);
            if (tree.getRoot().getLeft().getValue() == 2 && tree.getRoot().getRight() == null)
                isOk = true;
            Assert.AreEqual(true, isOk);
        }

        [Test]
        public void REMOVE_WITH_LEFT_AND_RIGHT_CHILD()
        {
            bool isOk = false;
            tree.add(4, 4);
            tree.add(2, 2);
            tree.add(9, 9);
            tree.add(7, 7);
            tree.add(15, 15);
            tree.add(14, 14);
            tree.add(6, 6);
            tree.add(8, 8);
            tree.removeByKey(9);
            if (tree.getRoot().getLeft().getValue() == 2 && tree.getRoot().getRight().getValue() == 15 && tree.getRoot().getRight().getLeft().getValue() == 14 && tree.getRoot().getRight().getLeft().getLeft().getValue() == 7)
                isOk = true;
            Assert.AreEqual(true, isOk);
        }

        [Test]
        public void FIND()
        {
            tree.add(4, 4);
            tree.add(2, 2);
            tree.add(9, 9);
            tree.add(7, 7);
            tree.add(15, 15);
            tree.add(14, 14);
            tree.add(6, 6);
            tree.add(8, 8);
            Assert.AreEqual(6, tree.find(6).getValue());
        }

        [Test]
        public void FIND_WHEN_CANT()
        {
            tree.add(4, 4);
            tree.add(2, 2);
            tree.add(9, 9);
            tree.add(7, 7);
            tree.add(15, 15);
            tree.add(14, 14);
            tree.add(6, 6);
            tree.add(8, 8);
            Assert.AreEqual(null, tree.find(3));
        }
    }
}