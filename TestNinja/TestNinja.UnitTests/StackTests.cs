using NUnit.Framework;
using System;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class StackTests
    {
        [Test]
        public void Push_NullObject_ThrowsException()
        {
            var stack = new Stack<string>();

            Assert.That(() => stack.Push(null), Throws.ArgumentNullException); 
        }

        [Test]
        public void Push_ValidObject_PushIntoStack()
        {
            var stack = new Stack<string>();

            stack.Push("a");

            Assert.That(stack.Count,Is.EqualTo(1));
        }

        [Test]
        public void Pop_FromEmptyStack_ThrowsException()
        {
            var stack = new Stack<string>();

            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithObjects_ReturnsObjectFromTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            var result = stack.Pop();

            Assert.That(result,Is.EqualTo("b"));
        }

        [Test]
        public void Pop_StackWithObjects_RemovesObjectFromTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(1));
        }
        [Test]
        public void Peek_StackWithoutObjects_ThrowsException()
        {
            var stack = new Stack<string>();

            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithObjects_ReturnsObjectFromTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");

            var result = stack.Peek();

            Assert.That(result, Is.EqualTo("b"));
        }
    }
}
