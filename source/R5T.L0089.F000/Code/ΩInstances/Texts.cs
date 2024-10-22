using System;


namespace R5T.L0089.F000
{
    public class Texts : ITexts
    {
        #region Infrastructure

        public static ITexts Instance { get; } = new Texts();


        private Texts()
        {
        }

        #endregion
    }
}
