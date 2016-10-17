namespace Problem_04.Work_Force.Commands
{
    using Problem_04.Work_Force.Data.Interfaces;
    using Problem_04.Work_Force.Factories;

    public abstract class EmployeeCommand : Command
    {
        public override void Execute(string[] commandParams, IRepository repository)
        {
            var employeeName = commandParams[1];
            var employeeType = commandParams[0];

            var employee = EmployeeFactory.CreateEmplyee(employeeType, employeeName);
            repository.AddEmployee(employee);
        }
    }
}
