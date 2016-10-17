namespace Problem_06.Mirror_Image.Events
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CastMagicEventArgs : EventArgs
    {
        public CastMagicEventArgs(string expression)
        {
            this.Expression = expression;
            this.CastedWizardsIds = new List<int>();
        }

        public string Expression { get; }

        public ICollection<int> CastedWizardsIds { get; }
    }
}
