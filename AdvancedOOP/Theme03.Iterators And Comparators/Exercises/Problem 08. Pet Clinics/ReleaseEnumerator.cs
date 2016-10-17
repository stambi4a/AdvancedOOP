namespace Problem_08.Pet_Clinics
{
    using System.Collections;
    using System.Collections.Generic;

    public class ReleaseEnumerator<T> : IEnumerable<T>
    {
        private readonly T[] elements;

        public ReleaseEnumerator(T[] elements)
        {
            this.elements = elements;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentIndex = this.elements.Length / 2 + 1;
            for (var i = currentIndex - 1; i < this.elements.Length; i++)
            {
                yield return this.elements[i];
            }

            for (var i = 0; i < currentIndex - 1; i++)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
