namespace Problem_08.Military_Elite.Models
{
    using System;
    using System.Text;

    using Problem_08.Military_Elite.Interfaces;
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            var spyBuilder = new StringBuilder();
                spyBuilder.Append(base.ToString()).AppendLine();
                spyBuilder.Append($"Code Number: {this.CodeNumber}");

            return spyBuilder.ToString();
        }
    }
}
