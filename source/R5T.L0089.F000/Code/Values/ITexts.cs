using System;

using R5T.T0131;


namespace R5T.L0089.F000
{
    [ValuesMarker]
    public partial interface ITexts : IValuesMarker
    {
        /// <summary>
        /// <para><value>&lt;Not-Found&gt;</value></para>
        /// </summary>
        public string Not_Found => "<Not-Found>";
    }
}
