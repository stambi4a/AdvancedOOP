namespace Problem_05.Kings_Gambit_Extended.Repository.Interfaces
{
    using System.Collections.Generic;

    using Problem_05.Kings_Gambit_Extended.Interfaces;
    using Problem_05.Kings_Gambit_Extended.Models;

    public interface IKingdomRepository
    {
        IAttackable King { get; set; }
        
        IDictionary<string, Guard> Guards { get; }

        void AssignKing(IAttackable king);

        void AddGuard(Guard guard);

        void TryRemoveGuard(string guardName);
    }
}
