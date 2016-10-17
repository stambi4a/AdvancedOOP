namespace Problem_08.Custom_List_Sorter
{
    using System;
    using System.Net.NetworkInformation;

    public class CommandInterpreter<T> where T: IComparable<T>
    {
        private CustomList<T> list;
        public CommandInterpreter(CustomList<T> list)
        {
            this.list = list;
        }

        public void Add(T element)
        {
            this.list.Add(element);
        }

        public void Remove(int index)
        {
            this.list.Remove(index);
        }

        public void Contains(T element)
        {
            Console.WriteLine(this.list.Contains(element));
        }

        public void Swap(int first, int second)
        {
            this.list.Swap(first, second);
        }

        public void Greater(T element)
        {
            Console.WriteLine(this.list.CountGreaterThan(element));
        }

        public void Max()
        {
            Console.WriteLine(this.list.Max());
        }

        public void Min()
        {
            Console.WriteLine(this.list.Min());
        }

        public void Sort()
        {
            this.list.Sort();
        }

        public void Print()
        {
            Console.WriteLine(this.list);
        }

        public void END()
        {
            System.Environment.Exit(0);
        }
    }
}
