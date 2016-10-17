namespace Problem_08.Military_Elite.Models
{
    using System;

    using Enums;
    using Interfaces;

    using Problem_08.Military_Elite.Exceptions;

    public class Mission : IMission
    {
        private string state;
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }
        public string CodeName { get; }

        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new InvalidMissionStateException();
                }

                this.state = value;
            }
        }
        public void CompleteMission()
        {
            this.State = "Finished";
        }


        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
