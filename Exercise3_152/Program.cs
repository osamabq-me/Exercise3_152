﻿using System;
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



        }
    }
}
