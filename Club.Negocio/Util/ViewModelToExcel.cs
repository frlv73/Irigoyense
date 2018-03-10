using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OfficeOpenXml;
using System.IO;
using System.Security.Cryptography;
using Club.Negocio.Modelos;
using OfficeOpenXml.Style;


namespace Club.Desktop.Util
{
    public class ViewModelToExcel
    {
        
        /*
        public List<T> dataToPrint;
        private Application application = null;
        private Workbooks workbook = null;
        private Sheets sheets = null;
        private Worksheet sheet = null;
        private Range range = null;
        private object optionalValue = Missing.Value;
        private Workbook book = null;

        public void Generar()
        {
            try
            {
                if (null != dataToPrint)
                {
                    Mouse.SetCursor(Cursors.Wait);
                    CrearParametrosExcel();
                    CargarHoja();
                    AbrirArchivo();
                    Mouse.SetCursor(Cursors.Arrow);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error while generating Excel report");
            }

            finally
            {
                
            }
        }

        private void AbrirArchivo()
        {
            application.Visible = true;
        }

        private void CargarHoja()
        {
            Object[] header = CrearHeader();
            EscribirDatos(header);
        }

        private void EscribirDatos(object[] header)
        {
            object[,] objData = new object[dataToPrint.Count, header.Length];

            for (int j = 0; j < dataToPrint.Count; j++)
            {
                var item = dataToPrint[j];
                for (int i = 0; i < header.Length; i++)
                {
                    var y = typeof(T).InvokeMember
                        (header[i].ToString(), BindingFlags.GetProperty, null, item, null);
                    objData[j, i] = (y == null) ? "" : y.ToString();
                }
            }
            AgregarFilasDeExcel("A2", dataToPrint.Count, header.Length, objData);
            AutoFitColumns("A1", dataToPrint.Count + 1, header.Length);
        }

        private void AutoFitColumns(string rangoInicio, int cantFilas, int cantColumnas)
        {
            range = sheet.get_Range(rangoInicio, optionalValue);
            range = range.get_Resize(cantFilas, cantColumnas);
            range.Columns.AutoFit();
        }

        private void AgregarFilasDeExcel(string rangoInicio, int cantFilas, int cantColumnas, object[] values)
        {
            range = sheet.get_Range(rangoInicio, optionalValue);
            range = range.get_Resize(cantFilas, cantColumnas);
            range.set_Value(optionalValue, values);
        }

        private object[] CrearHeader()
        {
            PropertyInfo[] headerInfo = typeof(T).GetProperties();

            // Create an array for the headers and add it to the
            // worksheet starting at cell A1.
            List<object> objHeaders = new List<object>();
            for (int n = 0; n < headerInfo.Length; n++)
            {
                objHeaders.Add(headerInfo[n].Name);
            }

            var headerToAdd = objHeaders.ToArray();
            AgregarFilasDeExcel("A1", 1, headerToAdd.Length, headerToAdd);
            

            return headerToAdd;
        }

        private void CrearParametrosExcel()
        {
            application = new Microsoft.Office.Interop.Excel.Application();
            workbook = (Workbooks)application.Workbooks;
            book = (Workbook) workbook.Add(optionalValue);
            sheets = (Sheets) book.Worksheets;
            sheet = (Worksheet)sheets.get_Item(1);
        }*/

        public void ConvertirListaDeSociosExcel(IList<SocioViewModel> socios)
        {
            
            ExcelPackage pkg = new ExcelPackage();
            ExcelWorksheet hoja1 = pkg.Workbook.Worksheets.Add("Hoja 1");

            hoja1.Row(1).Height = 20;
            hoja1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            hoja1.Row(1).Style.Font.Bold = true;
            int cantFilas = socios.Count;

            hoja1.Cells[1, 1].Value = "Nro Socio";
            hoja1.Cells[1, 2].Value = "DNI";
            hoja1.Cells[1, 3].Value = "Nombre";
            hoja1.Cells[1, 4].Value = "Dirección";

            int i = 0;

            for (int fila = 2; fila <= cantFilas + 1; fila++)
            {
                hoja1.Cells[fila, 1].Value = socios[i].ID;
                hoja1.Cells[fila, 2].Value = socios[i].DNI;
                hoja1.Cells[fila, 3].Value = socios[i].Nombre;
                hoja1.Cells[fila, 4].Value = socios[i].Direccion;
                i++;
            }

            pkg.SaveAs(new FileInfo( Environment.GetFolderPath(Environment.SpecialFolder.Personal)+"\\ExportSocios.xlsx"));
        }
    }
}

