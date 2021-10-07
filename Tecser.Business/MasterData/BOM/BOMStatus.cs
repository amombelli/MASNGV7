using System;

namespace Tecser.Business.MasterData.BOM
{
    public class BOMStatus
    {
        public enum StatusHeader
        {
            Inactiva,
            FormulaOK,
            FormulaIssues,
            Inicial,
        };
        public static StatusHeader MapStatusOfFromText2(string status)
        {
            if (status == "En Proceso")
                status = "Proceso";

            if (string.IsNullOrEmpty(status))
                status = StatusHeader.FormulaIssues.ToString();

#pragma warning disable CS0168 // The variable 'st' is declared but never used
            StatusHeader st;
#pragma warning restore CS0168 // The variable 'st' is declared but never used
            try
            {
                return (StatusHeader)Enum.Parse(typeof(StatusHeader), status, true);
            }
            catch (Exception)
            {
                return StatusHeader.FormulaIssues;
                throw;
            }
        }



    }
}
