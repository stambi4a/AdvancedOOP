namespace Problem_08.Pet_Clinics
{
    using System.Collections;
    using System.Collections.Generic;
    public class AddEnumerator<T> : IEnumerable<T>
    {
        private readonly T[] elements;

        public AddEnumerator(T[] elements)
        {
            this.elements = elements;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentIndex = this.elements.Length / 2 + 1;
            yield return this.elements[currentIndex - 1];
            for (var i = 1; i < currentIndex; i++)
            {
                yield return this.elements[currentIndex - i - 1];
                yield return this.elements[currentIndex + i - 1];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
