namespace Problem_02.Kings_Gambit.Repository
{
    using System.Collections.Generic;

    using Problem_02.Kings_Gambit.Interfaces;
    using Problem_02.Kings_Gambit.Models;

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

        public void RemoveGuard(string guardName)
        {
            var guard = this.Guards[guardName];
            guard.GetKilled();
            this.Guards.Remove(guardName);
        }
    }
}
