using System;
using System.Collections.Generic;
using System.Linq;
using static TestProject1.Ticket;

namespace TestProject1
{
    internal class TestMethods
    {
        internal enum EValueType
        {
            Two,
            Three,
            Five,
            Seven,
            Prime
        }

        internal static Stack<int> GetNextGreaterValue(Stack<int> SourceStack)
        {
            Stack<int> result = new Stack<int>();
            Stack<int> tempStack = new Stack<int>(SourceStack);
            while (tempStack.Count > 0)
            {
                int currentElemento = tempStack.Pop();
                bool foundMayor = false;
                foreach (int elemento in tempStack)
                {
                    if (elemento > currentElemento)
                    {
                        result.Push(elemento);
                        foundMayor = true;
                        break;
                    }
                }
                if (!foundMayor)
                {
                    result.Push(-1);
                }
            }

            return result;
        }

        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();
            foreach (int numero in sourceArr)
            {
                if (numero % 2 == 0)
                {
                    result[numero] = EValueType.Two;
                }
                else if (numero % 3 == 0)
                {
                    result[numero] = EValueType.Three;
                }
                else if (numero % 5 == 0)
                {
                    result[numero] = EValueType.Five;
                }
                else if (numero % 7 == 0)
                {
                    result[numero] = EValueType.Seven;
                }
                else if (IsPrime(numero))
                {
                    result[numero] = EValueType.Prime;
                }

            }

            return result;
        }

        private static bool IsPrime(int numero)
        {
            if (numero <= 1) return false;
            if (numero == 2) return true;
            for (int i = 2; i <= Math.Sqrt(numero); i++)

            {
                if (numero % i == 0) return false;
            }
            return true;
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        {
            int count = 0;
            foreach (KeyValuePair<int, EValueType> entry in sourceDict)
            {
                if (entry.Value == type)
                {
                    count++;
                }

            }
            return count;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            var sortedDict = from entry in sourceDict orderby entry.Key descending select entry;
            return sortedDict.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            Queue<Ticket>[] result = new Queue<Ticket>[3];
            result[0] = new Queue<Ticket>();
            result[1] = new Queue<Ticket>();
            result[2] = new Queue<Ticket>();

            var sortedList = sourceList.OrderBy(ticket => ticket.Turn);
            foreach (Ticket ticket in sortedList)
            {
                switch (ticket.Request)
                {
                    case ERequestType.Payment:
                        result[0].Enqueue(ticket);
                        break;
                    case ERequestType.Subscription:
                        result[1].Enqueue(ticket);
                        break;
                    case ERequestType.Cancellation:
                        result[2].Enqueue(ticket);
                        break;
                }
            }

            return result;
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            try
            {
                targetQueue.Enqueue(ticket);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

        