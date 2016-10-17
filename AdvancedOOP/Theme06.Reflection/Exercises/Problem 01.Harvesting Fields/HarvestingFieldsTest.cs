namespace Problem_01.Harvesting_Fields
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Numerics;
    using System.Reflection;
    using System.Text;
    using System.Threading;

    public class HarvestingFieldsTest
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "HARVEST")
                {
                    break;
                }

                switch (input)
                {
                    case "private":
                        {
                            HarvestPrivateFields();
                        }
                        break;

                    case "protected":
                        {
                            HarvestProtectedFields();
                        }
                        break;

                    case "public":
                        {
                            HarvestPublicFields();
                        }
                        break;

                    case "all":
                        {
                            HarvestAllFields();
                        }
                        break;
                }
            }
        }

        private static void HarvestPrivateFields()
        {
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var fieldInfo = typeof(HarvestingFields).GetFields(bindingFlags);
            var fields = new List<string>();
            foreach (var field in fieldInfo)
            {
                if (field.IsPrivate)
                {
                    var fieldName = "private" + " " + field.FieldType.Name + " " + field.Name;
                    fields.Add(fieldName);

                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, fields));
        }

        private static void HarvestProtectedFields()
        {
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var fieldInfo = typeof(HarvestingFields).GetFields(bindingFlags);
            var fields = new List<string>();
            foreach (var field in fieldInfo)
            {
                if (field.IsFamily)
                {
                    var fieldName = "protected" + " " + field.FieldType.Name + " " + field.Name;
                    fields.Add(fieldName);
                }

            }
            Console.WriteLine(string.Join(Environment.NewLine, fields));
        }

        private static void HarvestPublicFields()
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var fieldInfo = typeof(HarvestingFields).GetFields(bindingFlags);
            var fields = new List<string>();
            foreach (var field in fieldInfo)
            {
                var fieldName = "public" + " " + field.FieldType.Name + " " + field.Name;
                fields.Add(fieldName);
            }

            Console.WriteLine(string.Join(Environment.NewLine, fields));
        }
        private static void HarvestAllFields()
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var fieldInfo = typeof(HarvestingFields).GetFields(bindingFlags);
            var fields = new List<string>();
            foreach (var field in fieldInfo)
            {
                var fieldAccess = "private";
                if (field.IsFamily)
                {
                    fieldAccess = "protected";
                }
                if (field.IsPublic)
                {
                    fieldAccess = "public";
                }

                var fieldName = fieldAccess + " " + field.FieldType.Name + " " + field.Name;
                fields.Add(fieldName);
            }

            Console.WriteLine(string.Join(Environment.NewLine, fields));
        }

    }

    class HarvestingFields
    {
        private int testInt;
        public double testDouble;
        protected string testString;
        private long testLong;
        protected double aDouble;
        public string aString;
        private Calendar aCalendar;
        public StringBuilder aBuilder;
        private char testChar;
        public short testShort;
        protected byte testByte;
        public byte aByte;
        protected StringBuilder aBuffer;
        private BigInteger testBigInt;
        protected BigInteger testBigNumber;
        protected float testFloat;
        public float aFloat;
        private Thread aThread;
        public Thread testThread;
        private object aPredicate;
        protected object testPredicate;
        public object anObject;
        private object hiddenObject;
        protected object fatherMotherObject;
        private string anotherString;
        protected string moarString;
        public int anotherIntBitesTheDust;
        private Exception internalException;
        protected Exception inheritableException;
        public Exception justException;
        public Stream aStream;
        protected Stream moarStreamz;
        private Stream secretStream;
    }
}
