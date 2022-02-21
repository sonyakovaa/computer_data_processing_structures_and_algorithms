using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_21
{
    public class BinaryTree
    {
        private class Node // вложенный класс для узлов
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
                    Console.Write("{0} ", r.inf);
                    Preorder(r.left);
                    Preorder(r.right);
                }
            }

            public static void Search(Node r, object key, out Node item)
            {
                if (r == null)
                {
                    item = null;
                }
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(key) == 0)
                    {
                        item = r;
                    }
                    else
                    {
                        if (((IComparable)(r.inf)).CompareTo(key) > 0)
                        {
                            Search(r.left, key, out item);
                        }
                        else
                        {
                            Search(r.right, key, out item);
                        }
                    }
                }
            }

            public static void Depth(Node t, int b, ref int res)
            {
                res++;
                if (((IComparable)(t.inf)).CompareTo(b) == 0) // если найден узел, то завершаем работу
                {
                    return;
                }
                else
                {
                    if (((IComparable)(t.inf)).CompareTo(b) > 0)
                    {
                        Depth(t.left, b, ref res);
                    }
                    else
                    {
                        Depth(t.right, b, ref res);
                    }
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

        public void DepthBinaryTree(int a, int b, ref int res)
        {
            Node itemA;
            Node.Search(tree, a, out itemA);
            Node.Depth(itemA, b, ref res);
        }
    }
}
