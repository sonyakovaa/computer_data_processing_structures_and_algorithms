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

        public struct Returns
        {
            public bool idealBalanced;
            public int count;
            public bool canRemove;
            public Node deepestNode;
        }

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
            Returns r = fImpl(tree);

            Console.WriteLine("Ideal balanced: {0}, can remove: {1}", r.idealBalanced, r.canRemove);
            if (r.canRemove == true)
            {
                Console.WriteLine("Node to remove: {0}", r.deepestNode.inf);
            }
        }

        Returns fImpl(Node node)
        {
            if (node == null)
            {
                Returns r = new Returns();
                r.idealBalanced = true;
                r.count = 0;
                r.canRemove = false;
                r.deepestNode = null;

                return r;
            }

            Returns leftS = fImpl(node.left);
            Returns rightS = fImpl(node.right);

            int delta = Math.Abs(leftS.count - rightS.count);
            Returns result;
            result.idealBalanced = leftS.idealBalanced && rightS.idealBalanced && (delta <= 1);
            result.count = leftS.count + rightS.count + 1;
            result.canRemove = !result.idealBalanced && (delta <= 2) && ((!leftS.canRemove && !rightS.canRemove) || (rightS.canRemove != leftS.canRemove));

            if (leftS.deepestNode == null && rightS.deepestNode == null)
            {
                result.deepestNode = node;
            }
            else if (leftS.deepestNode != null && rightS.deepestNode == null)
            {
                result.deepestNode = leftS.deepestNode;
            }
            else if (leftS.deepestNode == null && rightS.deepestNode != null)
            {
                result.deepestNode = rightS.deepestNode;
            }
            else
            {
                if (leftS.count > rightS.count)
                {
                    result.deepestNode = leftS.deepestNode;
                }
                else
                {
                    result.deepestNode = rightS.deepestNode;
                }
            }
            return result;
        }
    }
}
