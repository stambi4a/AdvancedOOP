namespace Problem_05.Kings_Gambit_Extended.Repository
{
    using System.Collections.Generic;

    using Problem_05.Kings_Gambit_Extended.Interfaces;
    using Problem_05.Kings_Gambit_Extended.Models;
    using Problem_05.Kings_Gambit_Extended.Repository.Interfaces;

    public class KingdomRepository : IKingdomRepository
    {
        public KingdomRepository()
        {
            this.King = null;
            this.Guards = new Dictionary<string, Guard>();
        }

        public IAttackable King { get; set; }

        public IDictionary<string, Guard> Guards { get; }


        public void AssignKing(IAttackable king)
        {
            this.King = king;
        }

        public void AddGuard(Guard guard)
        {
            this.Guards.Add(guard.Name, guard);
        }

        public void TryRemoveGuard(string guardName)
        {
            var guard = this.Guards[guardName];
            if (guard.GetAttacked())
            {
                this.Guards.Remove(guardName);
            }
        }
    }
}
