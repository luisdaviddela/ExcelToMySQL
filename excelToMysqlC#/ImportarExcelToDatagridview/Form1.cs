using System;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;



namespace ImportarExcelToDatagridview
{
    public partial class Form1 : Form
    {
        string Label1;
        #region GuardarArchivo
        StreamWriter str = new StreamWriter(@"archivo.txt");
        string query = "";
        double divMin = 0;
        double divSeg = 0;
        //------
        double divMin1 = 0;
        double divSeg1 = 0;
        int latitud = 0;
        int longitud = 0;
        double minutos = 60;
        double segundos = 3600;

        //------------------------DATOS PARA EL CICLO FOR
        double m1 = 0;
        double m11 = 0;
        double m2 = 0;
        double m22 = 0;
        double m3 = 0;
        double m33 = 0;
        //-----------------------------------------------
        string digitos = "10000";
        #endregion

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void BBrowse_Click(object sender, EventArgs e)
        {

            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Selección Archivo";
            file.InitialDirectory = @"C:\";
            file.Filter = "Archivo Excel|*.xlsx;*.xls;*.xlsm;";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.ShowDialog();
            string dicArchiv = file.FileName;
            string NombreArchivo = @file.FileName;
            //label1.Text = file.FileName;
            Label1 = file.FileName;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int CONT = 1;

            var excel = new Excel.Application();
            Excel.Workbook librodetrabajo = excel.Workbooks.Open(Label1);
            //string conString = @"Data Source=" + Server.Text + ";Initial Catalog=" + DataBase.Text + ";User Id=" + User.Text + ";password=" + Password.Text;
            //string segundacadena = conString;
            foreach (Microsoft.Office.Interop.Excel.Worksheet Hojas in librodetrabajo.Sheets)
            {
                Excel._Worksheet xlWorksheet = librodetrabajo.Sheets[CONT];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                CONT += 1;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                //string okf = "";
                //string POS = "";
                //for (int i = 1; i <= colCount; i++)
                //{
                //    POS += "`" + xlRange.Cells[1, i].Value2.ToString() + "`,";

                //}
                //okf = POS.Substring(0, POS.Length - 1);
                
                for (int b = 2; b <= rowCount; b++)
                {
                    string value = "";
                    string resultExcel = "";
                    for (int c = 1; c <= colCount; c++)
                    {

                        value +=xlRange.Cells[b, c].Value2.ToString() + ",";
                        resultExcel = value.Substring(0, value.Length - 1);
                    }
                    string[] valores = resultExcel.Split(',');
                    string contratoarea = valores[0];
                    string verticePoligono = valores[1];
                    latitud = Convert.ToInt32(valores[3]);
                    longitud = Convert.ToInt32(valores[2]);
                    m1 = latitud / 10000; //Primeros 2 números
                    int m4 = latitud % Convert.ToInt32(digitos);
                    string result = m4.ToString();
                    int ZeroConditional = int.Parse(result);
                    string sub = "";
                    if (ZeroConditional == 0)
                    {
                        try
                        {
                            divMin = 0;
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                    else
                    {
                        try
                        {
                            sub = result.Substring(0, result.Length - 2); // Segundos dos números de en medio
                            if (sub =="")
                            {
                                sub = "0";
                            }
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                    m2 = (latitud % (10000));
                    m3 = latitud % 100;
                    //--------------------------------------------
                    //Console.WriteLine(m1+" "+sub+" "+m3);
                    if (ZeroConditional == 0)
                    {
                        divMin = 0;
                    }
                    else
                    {
                        divMin = Convert.ToDouble(sub) / minutos; //Números de en medio entre minutos
                    }

                    divSeg = m3 / segundos;
                    //--------------Asignar valor  a LATITUD Y LONGITUD

                    //Console.WriteLine(m1 + " " + divMin + " " + divSeg);
                    double suma = m1 + divMin + divSeg;
                    if (contratoarea == "CNH-R01-L03-A18/2015" && verticePoligono =="10")
                    {

                    }
                    m11 = longitud / 10000;
                    int m44 = longitud % Convert.ToInt32(digitos);
                    string result2 = m44.ToString();
                    string sub1 = "";
                    if (result2 == "0")
                    {
                        sub1 = "0";
                    }
                    else
                    {
                        sub1=result2.Substring(0, result2.Length - 2);
                        if (sub1=="")
                        {
                            sub1 = "0";
                        }
                    }
                    
                    m22 = (longitud % (10000));
                    m33 = longitud % 100;
                    //--------------------------------------------
                    //Console.WriteLine(m1+" "+sub+" "+m3);
                    divMin1 = Convert.ToDouble(sub1) / minutos;
                    divSeg1 = m33 / segundos;
                    //--------------Asignar valor  a LATITUD Y LONGITUD

                    //Console.WriteLine(m1 + " " + divMin + " " + divSeg);
                    double suma2 = m11 + divMin1 + divSeg1;
                    query = $"insert into CO_Coordenadas (IdAreaContractual,lat,lng, poligono) values ({contratoarea},'{suma}','-{suma2}',{verticePoligono})";
                    str.WriteLine(query);
                }
            }
            str.Close();
            librodetrabajo.Close();
            MessageBox.Show("final");
        }
    }
}

