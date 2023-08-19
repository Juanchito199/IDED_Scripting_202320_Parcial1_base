using System;
using System.Collections.Generic;

namespace TestProject1
{
    internal class Sandbox
    {
        public static void Main(string[] args)
        {
            Stack<int> inputStack = new Stack<int>();
            inputStack.Push(26);
            inputStack.Push(3);
            inputStack.Push(6);
            inputStack.Push(5);

            Stack<int> resultStack = TestMethods.GetNextGreaterValue(inputStack);

            Console.WriteLine("Original Stack:");
            foreach (int num in inputStack)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("Result Stack:");
            foreach (int num in resultStack)
            {
                Console.WriteLine(num);
            }

            int[] sourceArr = { 2, 3, 5, 7, 10, 11, 15, 21 };
            Dictionary<int, TestMethods.EValueType> valueDictionary = TestMethods.FillDictionaryFromSource(sourceArr);

            Console.WriteLine("Value Dictionary:");
            foreach (var kvp in valueDictionary)
            {
                Console.WriteLine($"Number: {kvp.Key}, Value Type: {kvp.Value}");
            }
            List<Ticket> ticketList = new List<Ticket>
            {
                new Ticket { Turn = 2, Request = TestMethods.ERequestType.Payment },
                new Ticket { Turn = 1, Request = TestMethods.ERequestType.Subscription },
                new Ticket { Turn = 3, Request = TestMethods.ERequestType.Cancellation },
                new Ticket { Turn = 2, Request = TestMethods.ERequestType.Payments },
                new Ticket { Turn = 1, Request = TestMethods.ERequestType.Subscriptions },
            };

            Queue<Ticket>[] ticketQueues = TestMethods.ClassifyTickets(ticketList);

            Console.WriteLine("Classified Tickets:");
            for (int i = 0; i < ticketQueues.Length; i++)
            {
                Console.WriteLine($"Queue {i + 1}:");
                foreach (var ticket in ticketQueues[i])
                {
                    Console.WriteLine($"Turn: {ticket.Turn}, Request Type: {ticket.Request}");
                }
            }

            Queue<Ticket> targetQueue = new Queue<Ticket>();
            Ticket newTicket = new Ticket { Turn = 4, Request = TestMethods.ERequestType.Payments };
            bool added = TestMethods.AddNewTicket(targetQueue, newTicket);

            Console.WriteLine($"New Ticket Added: {added}");
        }
    }
}
        }
    }
}
