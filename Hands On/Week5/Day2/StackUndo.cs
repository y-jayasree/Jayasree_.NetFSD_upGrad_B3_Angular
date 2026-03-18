using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp2
{
    internal class StackUndo
    {
        //array
        private string[] stack;
        private int top;
        
        //constrctor
        public StackUndo(int size)
        {
            stack = new string[size]; 
            top = -1;
        }
        public void push(string action)
        {
            if (top == stack.Length - 1)
            {
                Console.WriteLine("Stack Overflow Cannot add more actions.");
                return;
            }
            top++;
            stack[top] = action;
            Console.WriteLine("Action performed:" + action);
            Display();
        }
        public void pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Nothing to undo Stack is empty");
                return;
            }
            Console.WriteLine("undo action:" + stack[top]);
            top--;
            Display();
        }
        public void Display()
        {
            Console.WriteLine("Current state:");
            if(top == -1)
            {
                Console.WriteLine("empty");
                return;
            }
            for(int i = 0; i <= top; i++)
            {
                Console.WriteLine(stack[i]);
                if (i == top)
                    Console.WriteLine(stack[i]);
                if (i != top)
                    Console.WriteLine("->");
            }
            Console.WriteLine();
        }
    }
}


namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] arg)
        { 
            StackUndo editor = new StackUndo(5);
            editor.push("Type A");
            editor.push("Type B");
            editor.push("Type C");

            editor.pop(); // Undo
            editor.pop(); // Undo

            Console.WriteLine("\nFinal State:");
            editor.Display();
        }
            
    }
}
