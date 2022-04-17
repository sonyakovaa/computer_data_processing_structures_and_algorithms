using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_21_3
{
    public class BinaryTree
    {
        public class Node // вложенный класс для узлов
        {
            public object inf;
            public Node left;
            public Node right;

            public Node(object nodeInf)
            {
                inf = nodeInf;
                left = null;
                right = null;
            }

            public static void Add(ref Node r, object nodeInf)
            {
                if (r == null) // если корень и есть место для узла, то добавляем
                {
                    r = new Node(nodeInf);
                }
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0) // nodeInf < r.inf?,
                                                                       // возвращает 1, если r.inf следует в порядке возрастания за nodeInf
                    {
                        Add(ref r.left, nodeInf); // если да, то производим поиск места в левом
                    }
                    else
                    {
                        Add(ref r.right, nodeInf); // иначе в правом
                    }
                }
            }

            public static void Preorder(Node r) // прямой обход дерева - корень, левое и правое поддерево
            {
                if (r != null)
                {
                    Console.WriteLine("{0}", r.inf);
                    Preorder(r.left);
                    Preorder(r.right);
                }
            }

        }

        Node tree;

        public object Inf
        {
            set { tree.inf = value; }
            get { return tree.inf; }
        }

        public BinaryTree() // открытый конструктор
        {
            tree = null;
        }

        private BinaryTree(Node r) // закрытый конструктор
        {
            tree = r;
        }

        public void Add(object nodeInf)
        {
            Node.Add(ref tree, nodeInf);
        }

        public void Preorder()
        {
            Node.Preorder(tree);
        }

        public void outputInformation()
        {
            bool idealBalanced = false, canRemove = false;
            int count = 0;
            Node deepestNode = null;
            fImpl(ref tree, ref idealBalanced, ref count, ref canRemove, ref deepestNode);

            Console.WriteLine("Ideal balanced: {0}, can remove: {1}, node to remove: {2}", idealBalanced, canRemove, deepestNode);
        }

        private void fImpl(ref Node node, ref bool idealBalanced, ref int count, ref bool canRemove, ref Node deepestNode)
        {
            if (node == null)
            {
                idealBalanced = true;
                count = 0;
                canRemove = false;
                deepestNode = null;
                return;
            }

            bool leftIdealBalanced = false, leftCanRemove = false;
            int leftCount = 0;
            Node leftDeepestNode = null;
            fImpl(ref node.left, ref leftIdealBalanced, ref leftCount, ref leftCanRemove, ref leftDeepestNode);

            bool rightIdealBalanced = false, rightCanRemove = false;
            int rightCount = 0;
            Node rightDeepestNode = null;
            fImpl(ref node.right, ref rightIdealBalanced, ref rightCount, ref rightCanRemove, ref rightDeepestNode);

            int delta = Math.Abs(leftCount - rightCount);
            idealBalanced = leftIdealBalanced && rightIdealBalanced && (delta <= 1);
            count = leftCount + rightCount + 1;
            canRemove = !idealBalanced && (delta <= 2) && ((!leftCanRemove && !rightCanRemove) || (rightCanRemove != leftCanRemove));

            if (leftDeepestNode == null && rightDeepestNode == null)
            {
                deepestNode = node;
            }
            else if (leftDeepestNode != null && rightDeepestNode == null)
            {
                deepestNode = leftDeepestNode;
            }
            else if (leftDeepestNode == null && rightDeepestNode != null)
            {
                deepestNode = rightDeepestNode;
            }
            else
            {
                if (leftCount > rightCount)
                {
                    deepestNode = leftDeepestNode;
                }
                else
                {
                    deepestNode = rightDeepestNode;
                }
            }
        }

    }
}
