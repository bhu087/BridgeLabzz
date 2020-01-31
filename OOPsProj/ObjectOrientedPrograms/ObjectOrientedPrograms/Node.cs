////...................................
////<copyright file="Node.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////...................................
namespace ObjectOrientedPrograms
{
    /// <summary>
    /// This is the Node class.
    /// </summary>
    /// <typeparam name="T">T is a generics type</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// The next Node;
        /// </summary>
        public Node<T> Next;

        /// <summary>
        /// The data
        /// </summary>
        public T Data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public Node(T data)
        {
            this.Data = data;
        }
    }
}
