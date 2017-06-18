using System;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

public class ExportToExcel
{
    public static void Main()
    {
        var xlsPackage = new ExcelPackage();
        var workSheet = xlsPackage.Workbook.Worksheets.Add("Sample");
        workSheet.Cells[1, 1, 1, 11].Merge = true;
        workSheet.Cells[1, 1, 1, 11].Style.Font.Size = 18;
        workSheet.Cells[1, 1].Value = "SoftUni OOP Results";

        using (var reader = new StreamReader("../../StudentData.txt"))
        {
            var line = reader.ReadLine();
            var row = 2;
            while (line != null)
            {
                var columns = line.Split('\t');
                for (int i = 1; i <= columns.Length; i++)
                {
                    workSheet.Cells[row, i].Value = columns[i - 1];
                }
                row++;
                line = reader.ReadLine();
            }
        }

        var output = new FileStream("../../sample.xlsx", FileMode.Create);
        xlsPackage.SaveAs(output);
    }
}