namespace Problem_04.Work_Force.Data.Interfaces
{
    using System.Collections;
    using System.Collections.Generic;

    using Problem_04.Work_Force.Models.Interfaces;

    public interface IRepository
    {
        void Update();

        void AddJob(string jobName, IJob job);

        void AddEmployee(IEmployee employee);

        IEmployee GetEmployee(string employeeName);

        IJob GetJob(string jobName);

        void Print();
    }
}
