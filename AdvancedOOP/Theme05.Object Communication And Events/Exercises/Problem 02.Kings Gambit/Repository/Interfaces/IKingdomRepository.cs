namespace Problem_02.Kings_Gambit.Repository
{
    using System.Collections.Generic;

    using Problem_02.Kings_Gambit.Interfaces;
    using Problem_02.Kings_Gambit.Models;

    public interface IKingdomRepository
    {
        IAttackable King { get; set; }
        
        IDictionary<string, Guard> Guards { get; }

        void AssignKing(IAttackable king);

        void AddGuard(Guard guard);

        void RemoveGuard(string guardName);
    }
}
