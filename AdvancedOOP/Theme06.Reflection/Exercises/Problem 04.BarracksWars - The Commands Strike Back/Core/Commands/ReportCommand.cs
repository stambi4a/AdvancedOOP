namespace Problem_04.BarracksWars___The_Commands_Strike_Back.Core.Commands
{
    using Problem_04.BarracksWars___The_Commands_Strike_Back.Contracts;

    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
