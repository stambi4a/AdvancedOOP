namespace Problem_08.Military_Elite.Interfaces
{
    using System.Collections.Generic;

    using Problem_08.Military_Elite.Models;

    public interface ILeutenantGeneral
    {
        List<Private> Privates { get; }

        void AddPrivate(Private privat);
    }
}
