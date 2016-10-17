namespace Problem_04.Work_Force.Factories
{
    using System;

    using Problem_04.Work_Force.Models;
    using Problem_04.Work_Force.Models.Interfaces;

    public class JobFactory
    {
        public static IJob CreateJob(string name, int jobHours, IEmployee employee)
        {
            var type = typeof(Job);
            var job = (IJob)Activator.CreateInstance(type, name, jobHours, employee);

            return job;
        }
    }
}
