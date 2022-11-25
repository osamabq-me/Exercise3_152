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


        public bool deleteNode(int rollNumber)
        {

            if (LAST == null)
                return false;

            // Find the required node
            Node curr = LAST, prev = new Node();
            while (curr.rollNumber != rollNumber)
            {
                if (curr.next == LAST)
                {
                    Console.Write("\nGiven node is not found in the list!!!");
                    break;
                }

                prev = curr;
                curr = curr.next;
            }

            // it is first node
            if (curr == LAST)
            {
                prev = LAST;
                while (prev.next != LAST)
                    prev = prev.next;
                LAST = curr.next;
                prev.next = LAST;
                return true;
            }

            // check if node is last node
            else if (curr.next == LAST)
            {
                prev.next = LAST;
                return true;
            }
            else
            {
                prev.next = curr.next;
            }
            return true;
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
                    LAST.rollNumber+ "   " + LAST.name);
            }

        }


        public bool Search(int rollNumber, ref Node previous, ref Node current)
        {
            previous = current = LAST;
            while (current != null && rollNumber != current.rollNumber)
            {
                previous = current;
                current = current.next;
            }
            return (current != null);
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
                    Console.WriteLine("2. Delete a record in list");
                    Console.WriteLine("3. View all record in the list");
                    Console.WriteLine("4. search for a record in list ");
                    Console.WriteLine("5. Dispaly the first record in list");
                    Console.WriteLine("6. Exit\n");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            obj.addnode();
                            break;
                        case '2':
                            {
                                if (obj.ListEmpty())
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student " + " whose record is to be deleted:");
                                int rollNumber = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.deleteNode(rollNumber) == false)
                                {
                                    Console.WriteLine("Record not found");
                                }
                                else
                                    Console.WriteLine("Record with roll number " + rollNumber + " deleted\n");
                            }
                            break;
                        case '3':
                            obj.traverse();
                            break;
                        case '4':
                            if (obj.ListEmpty()== true)
                            {
                                Console.WriteLine("\n List is empty");
                                break;
                            }
                            Node prev, curr;
                            prev = curr = null;
                            Console.Write("\nEnter the roll number of the student whoses rocord is to be searched:");
                            int num = Convert.ToInt32(Console.ReadLine());
                            if (obj.Search(num, ref prev, ref curr) == false)
                                Console.WriteLine("\nRecord not found");
                            else
                            {
                                Console.WriteLine("\nRecord found");
                                Console.WriteLine("\nRoll number " + curr.rollNumber);
                                Console.WriteLine("\nName: " + curr.name);
                            }
                                break;
                        case '5':
                            obj.firstnode();
                            break;
                        case '6':
                            break;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
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
