﻿namespace Problem_01.MarketPlace.Lifecycle
{
    using System;

    using Request;

    public class RequestMappingAttribute : Attribute
    {
        private readonly string value;

        private readonly RequestMethod method;

        public RequestMappingAttribute(string value, RequestMethod method = RequestMethod.ADD)
        {
            this.value = value;
            this.method = method;
        }

        public string Value
        {
            get { return this.value; }
        }

        public RequestMethod Method
        {
            get { return this.method; }
        }
    }
}
