namespace Problem_04.Work_Force.Commands
{
    using Problem_04.Work_Force.Data.Interfaces;
    using Problem_04.Work_Force.Factories;

    public class JobCommand : Command
    {
        public override void Execute(string[] commandParams, IRepository repository)
        {
            var jobName = commandParams[1];
            var jobHours = int.Parse(commandParams[2]);
            var employee = repository.GetEmployee(commandParams[3]);

            var job = JobFactory.CreateJob(jobName, jobHours, employee);
            repository.AddJob(jobName, job);
        }
    }
}
