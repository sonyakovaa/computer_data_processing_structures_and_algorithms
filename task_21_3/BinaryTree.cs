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
            public int height;

            public Node(object nodeInf)
            {
                inf = nodeInf;
                left = null;
                right = null;
                this.height = 0;
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
                    Console.WriteLine("{0} - {1}", r.inf, r.height);
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

        private bool idealBalance(int h, int n)
        {
            return h == Math.Ceiling(Math.Log(n + 1, 2));
        }

        public void f()
        {
            List<List<Node>> levels = new List<List<Node>>();
            int n = f2(tree, levels, 0);
            int h = levels.Count;

            if (idealBalance(h, n))
            {
                Console.WriteLine("Дерево идеально сбалансировано");
                return;
            }

            if (levels[levels.Count - 1].Count == 1)
            {
                if (idealBalance(h - 1, n - 1))
                {
                    Node node_todelete = levels[levels.Count - 1][0];
                    Console.WriteLine("Надо удалить узел {0}", node_todelete.inf);
                    return;
                }
            }

            Console.WriteLine("Нельзя удалить так, чтобы дерево стало идеально сбалансированным");
        }

        private int f2(Node n, List<List<Node>> levels, int level)
        {
            if (n == null)
                return 0;

            if (levels.Count <= level)
            {
                levels.Add(new List<Node>());
            }

            levels[level].Add(n);

            return 1 + f2(n.left, levels, level + 1) + f2(n.right, levels, level + 1);
        }
    }
}
