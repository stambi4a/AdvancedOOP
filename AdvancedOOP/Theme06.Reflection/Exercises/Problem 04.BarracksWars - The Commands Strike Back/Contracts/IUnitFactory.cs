﻿namespace Problem_04.BarracksWars___The_Commands_Strike_Back.Contracts
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}
