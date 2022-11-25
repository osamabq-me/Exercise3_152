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


        public void addnode()
        {
            int nim;
            string nm;
            Console.WriteLine("\n Enter the roll number of the students :");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n Enter students name");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.rollNumber = nim;
            newNode.name = nm;

            Node current = LAST;
            //if the list is empty
            if (current == null)
            {
                newNode.next = newNode;
                LAST = newNode;

            }
            //if the inputed data is  between two nods
            else if (current.rollNumber >= newNode.rollNumber)
            {
                while (current.next != LAST)
                    current = current.next;

                current.next = newNode;
                newNode.next = LAST;
                LAST = newNode;
            }
            //to input the data in the list
            else
            {
                while (current.next != LAST &&
                    current.next.rollNumber < newNode.rollNumber)
                    current = current.next;

                newNode.next = current.next;
                current.next = newNode;
            }

        }


        public void traverse()
        {
            if (ListEmpty())
            {
                Console.WriteLine("\nList is empty");
            }
            else
            {
                Console.WriteLine("\nRecordes in the list are: \n");
                Node currentNode;
                currentNode = LAST.next;
                Console.WriteLine(LAST.rollNumber + " " + LAST.name + "\n");
                while (currentNode != LAST)
                {
                    Console.WriteLine(currentNode.rollNumber + "  " +
                        currentNode.name + "\n");
                    currentNode = currentNode.next;
                }

            }
        }

        public void firstnode()
        {
            if (ListEmpty())
            {
                Console.WriteLine("\nList is empty");
            }
            else
            {
                Console.WriteLine("\n The first recorde in the list is:\n\n " +
                    LAST.next.rollNumber+ "   " + LAST.next.name);
            }

        }

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
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. View all record in list");
                    Console.WriteLine("3. View first record in list");
                    Console.WriteLine("4. Exit\n");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            obj.addnode();
                            break;
                        case '2':
                            obj.traverse();
                            break;
                        case '3':
                            obj.firstnode();
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered");
                }

            }


        }
    }
}
