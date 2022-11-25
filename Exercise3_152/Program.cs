using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_152
{
    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;

    }
    class CircularList
    {
        Node LAST;

        public bool ListEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {



        }
    }
}
