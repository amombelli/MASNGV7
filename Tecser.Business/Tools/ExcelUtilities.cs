using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;

namespace Tecser.Business.Tools
{
    public class ExcelUtilities
    {
        /// <summary>
        /// FUNCTION FOR EXPORT TO EXCEL
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="worksheetName"></param>
        /// <param name="saveAsLocation"></param>
        /// <returns></returns>
        public bool WriteDataTableToExcel(DataTable dataTable, string worksheetName, string saveAsLocation, string reporType)
        {
            Application excel;
            Workbook excelworkBook;
            Worksheet excelSheet;
            Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;


                excelSheet.Cells[1, 1] = reporType;
                excelSheet.Cells[1, 2] = "Date : " + DateTime.Now.ToShortDateString();

                // loop through each row and add values to our sheet
                int rowcount = 2;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        // on the first iteration we add the column headers
                        if (rowcount == 3)
                        {
                            excelSheet.Cells[2, i] = dataTable.Columns[i - 1].ColumnName;
                            excelSheet.Cells.Font.Color = Color.Black;

                        }

                        excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();

                        //for alternate rows
                        if (rowcount > 3)
                        {
                            if (i == dataTable.Columns.Count)
                            {
                                if (rowcount % 2 == 0)
                                {
                                    excelCellrange = excelSheet.Range[excelSheet.Cells[rowcount, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                                    FormattingExcelCells(excelCellrange, "#CCCCFF", Color.Black, false);
                                }

                            }
                        }

                    }

                }

                // now we resize the columns
                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                excelCellrange.EntireColumn.AutoFit();
                Borders border = excelCellrange.Borders;
                border.LineStyle = XlLineStyle.xlContinuous;
                border.Weight = 2d;


                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[2, dataTable.Columns.Count]];
                FormattingExcelCells(excelCellrange, "#000099", Color.White, true);


                //now save the workbook and exit Excel


                excelworkBook.SaveAs(saveAsLocation); ;
                excelworkBook.Close();
                excel.Quit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }

        }

        /// <summary>
        /// FUNCTION FOR FORMATTING EXCEL CELLS
        /// </summary>
        /// <param name="range"></param>
        /// <param name="htmLcolorCode"></param>
        /// <param name="fontColor"></param>
        /// <param name="isFontbool"></param>
        public void FormattingExcelCells(Range range, string htmLcolorCode, Color fontColor, bool isFontbool)
        {
            range.Interior.Color = ColorTranslator.FromHtml(htmLcolorCode);
            range.Font.Color = ColorTranslator.ToOle(fontColor);
            if (isFontbool)
            {
                range.Font.Bold = isFontbool;
            }
        }


        public void ExportDataToExcel()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0154_CHEQUES.Where(c => c.DISPONIBLE).OrderBy(c => c.CHE_FECHA).ToList();

                //Excel.ExcelUtlity obj = new Excel.ExcelUtlity();
                DataTable dt = new StructureConversion().ConvertIListToDataTable(data);
                WriteDataTableToExcel(dt, "Listado Cheques", @"D:\Temporal\listadoCheques.xlsx", "Details");

            }
        }


    }
}
