using System;


namespace R5T.L0089
{
    public class WasFoundOperator : IWasFoundOperator
    {
        #region Infrastructure

        public static IWasFoundOperator Instance { get; } = new WasFoundOperator();


        private WasFoundOperator()
        {
        }

        #endregion
    }
}
