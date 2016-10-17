namespace Problem_08.Military_Elite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Problem_08.Military_Elite.Interfaces;
    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        public LeutenantGeneral(string id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<Private>();
        }

        public List<Private> Privates { get; }

        public void AddPrivate(Private privat)
        {
            this.Privates.Add(privat);
        }

        public override string ToString()
        {
            var leutenantGeneralBuilder = new StringBuilder();
            leutenantGeneralBuilder.Append(base.ToString()).AppendLine();
            leutenantGeneralBuilder.Append("Privates:");
            foreach (var privat in this.Privates)
            {
                leutenantGeneralBuilder.AppendLine().Append(new string(' ', 2) + privat);
            }

            return leutenantGeneralBuilder.ToString();
        }
    }
}
