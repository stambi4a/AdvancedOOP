﻿namespace CS_OOP_Advanced_Exam_Prep_July_2016.Contracts
{
    public interface IProduct
    {
        int Id { get; }
        string Name { get; set; }
        int Size { get; set; }
        IShop Shop { get; set; }
    }
}
