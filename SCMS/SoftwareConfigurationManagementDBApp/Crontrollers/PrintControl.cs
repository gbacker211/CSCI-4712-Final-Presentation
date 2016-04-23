using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace SoftwareConfigurationManagementDBApp
{
    class PrintControl
    {
        private DataGridView _dataGrid;
        private string _dataview;

        public PrintControl(DataGridView grid, string dataview)
        {
            _dataGrid = grid;
            _dataview = dataview;

        }

        public void ExportGridData()
        {
            if(_dataGrid.ColumnCount > 0)
            { 
                copyGridData();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new MSExcel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (MSExcel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                MSExcel.Range CR = (MSExcel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
               
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                MSExcel.Range formatRange;
                formatRange = xlWorkSheet.get_Range("a1");
                formatRange.EntireRow.Font.Bold = true;
                //xlWorkSheet.Cells[1, 5] = "Bold";

                MSExcel.Worksheet myWorksheet;
                myWorksheet = xlWorkSheet;

               
                  
                myWorksheet.Range["A1:A2", "Z1:Z2"].Columns.AutoFit();

                MSExcel.Range Line = (MSExcel.Range)xlWorkSheet.Rows[1];
                Line.Insert();


            
               

                xlWorkSheet.get_Range("A1").Rows[1] = _dataview;

                MSExcel.Range centeRange;

                if (_dataview == "Software View")
                {
                    xlWorkSheet.get_Range("A1:D1").Merge();
                    centeRange = xlWorkSheet.get_Range("A1:D1");
                }
                else
                {
                    xlWorkSheet.get_Range("A1:H1").Merge();
                    centeRange = xlWorkSheet.get_Range("A1:H1");
                }

              
                centeRange.EntireRow.Cells.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;
                centeRange.Font.Bold = true;
                centeRange.Font.Size = 14;
                 

             

                _dataGrid.RowHeadersVisible = true;

            }
            else
            {
                MessageBox.Show("No data is selected, please select a view", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void copyGridData()
        {
            _dataGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
         //   _dataGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            _dataGrid.MultiSelect = true;

            _dataGrid.RowHeadersVisible = false;

            _dataGrid.SelectAll();

            DataObject dataObject = _dataGrid.GetClipboardContent();
            if (dataObject != null)
                Clipboard.SetDataObject(dataObject);
        }

    }
}
