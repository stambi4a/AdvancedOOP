namespace Problem_04.Work_Force.Factories
{
    using System;

    using Problem_04.Work_Force.Models.Interfaces;

    public class EmployeeFactory
    {
        public static IEmployee CreateEmplyee(string employeeType, string name)
        {
            var type = Type.GetType("Problem_04.Work_Force.Models." + employeeType);
            var employee = (IEmployee)Activator.CreateInstance(type, name);

            return employee;
        }
    }
}
