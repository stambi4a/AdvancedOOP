namespace Problem_01.MarketPlace.Lifecycle.Controller
{
    using System;

    public class UriParameterAttribute : Attribute
    {
        private readonly string value;

        public UriParameterAttribute(string value)
        {
            this.value = value;
        }

        public string Value
        {
            get { return this.value; }
        }
    }
}
