namespace Problem_01.Database
{
    using System;

    public class Database : IDatabase
    {
        public const int ArrayCapacity = 16;
        private int[] elements;

        private int currentIndex;
        public Database(params int[] elements)
        {
            this.Elements = new int[ArrayCapacity];
            this.currentIndex = 0;
            this.AddInputELements(elements);
        }

        private int[] Elements
        {
            get
            {
                return this.elements;
            }

            set
            {
                if (value.Length != ArrayCapacity)
                {
                    throw new InvalidOperationException();
                }

                this.elements = value;
            }
        }

        private void AddInputELements(params int[] elements)
        {
            foreach (var element in elements)
            {
                this.AddElement(element);
            }
        }

        public void AddElement(int element)
        {
            if (this.currentIndex == ArrayCapacity)
            {
                throw new InvalidOperationException();
            }

            this.elements[this.currentIndex] = element;
            this.currentIndex++;
        }

        public int RemoveElement()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException();
            }

            var element = this.elements[this.currentIndex - 1];
            this.elements[this.currentIndex] = 0;
            this.currentIndex--;

            return element;
        }

        public int[] Fetch()
        {
            var newArray = new int[ArrayCapacity];
            Array.Copy(this.elements, newArray, ArrayCapacity);

            return newArray;
        }
    }
}
