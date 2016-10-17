namespace Problem_04.Work_Force.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Problem_04.Work_Force.Data.Interfaces;
    using Problem_04.Work_Force.Events;
    using Problem_04.Work_Force.Models.Interfaces;

    public class Repository : IRepository
    {
        public event RepositoryUpdateEventHandler WeekUpdate;

        private IDictionary<string, IJob> jobs;

        private IDictionary<string, IEmployee> employees;

        public Repository()
        {
            this.jobs = new Dictionary<string, IJob>();
            this.employees = new Dictionary<string, IEmployee>();
        }

        public void Update()
        {
            this.OnWeekUpdate();
        }

        private void OnWeekUpdate()
        {
            this.WeekUpdate?.Invoke(this, EventArgs.Empty);
        }

        public IEmployee GetEmployee(string employeeName)
        {
            return this.employees[employeeName];
        }

        public IJob GetJob(string jobName)
        {
            return this.jobs[jobName];
        }

        public void AddJob(string name, IJob job)
        {
            this.jobs.Add(name, job);
            job.JobDone += this.RemoveJob;
            this.WeekUpdate += job.Update;
        }

        public void Print()
        {
            //Console.WriteLine(string.Join(Environment.NewLine, this.jobs.Values));
            this.jobs.Values.ToList().ForEach(Console.WriteLine);
        }

        public void AddEmployee(IEmployee employee)
        {
            this.employees.Add(employee.Name, employee);
        }

        private void RemoveJob(object sender, JobEventArgs args)
        {
            this.WeekUpdate -= this.jobs[args.Name].Update;
            this.jobs.Remove(args.Name);
            Console.WriteLine($"Job {args.Name} done!");
        }
    }
}
