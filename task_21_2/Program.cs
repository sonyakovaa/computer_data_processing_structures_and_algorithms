using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_21
{
    public class BinaryTree
    {
        public class Node // вложенный класс для узлов
        {
            public object inf;
            public Node left;
            public Node right;
            public int depth;

            public Node(object nodeInf, int depth)
            {
                inf = nodeInf;
                left = null;
                right = null;
                this.depth = depth;
            }

            public static void Add(ref Node r, object nodeInf, int depth)
            {
                if (r == null) // если корень и есть место для узла, то добавляем
                {
                    r = new Node(nodeInf, depth);
                }
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0) // nodeInf < r.inf?,
                                                                       // возвращает 1, если r.inf следует в порядке возрастания за nodeInf
                    {
                        Add(ref r.left, nodeInf, depth + 1); // если да, то производим поиск места в левом
                    }
                    else
                    {
                        Add(ref r.right, nodeInf, depth + 1); // иначе в правом
                    }
                }
            }

            public static void Preorder(Node r) // прямой обход дерева - корень, левое и правое поддерево
            {
                if (r != null)
                {
                    Console.WriteLine("{0}, depth - {1}", r.inf, r.depth);
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
            Node.Add(ref tree, nodeInf, 0);
        }

        public void Preorder()
        {
            Node.Preorder(tree);
        }
    }
}
