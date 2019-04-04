using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;



namespace ImportarExcelToDatagridview
{
    public partial class Form1 : Form
    {
        string Label1;
        public Form1()
        {
            InitializeComponent();

        }
     

       


        private void Form1_Load(object sender, EventArgs e)
        {
            Server.Text = "localhost";
            DataBase.Text = "";
            User.Text = "root";
            Password.Text = "";
            DataBase.Text = "lalala";
            

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
            string conString = @"Data Source=" + Server.Text + ";Initial Catalog=" + DataBase.Text + ";User Id=" + User.Text + ";password=" + Password.Text;
            string segundacadena = conString;
            foreach (Microsoft.Office.Interop.Excel.Worksheet Hojas in librodetrabajo.Sheets)
            {
                Excel._Worksheet xlWorksheet = librodetrabajo.Sheets[CONT];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                CONT += 1;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                string okf = "";
                string POS = "";
                for (int i = 1; i <= colCount; i++)
                {
                    POS += "`" + xlRange.Cells[1, i].Value2.ToString() + "`,";
             
                }
                okf = POS.Substring(0, POS.Length - 1);
                

                string value = "";
                string result = "";

                value = "";
                
                


                for (int b = 2; b <= rowCount; b++)
                {
                    value = "";
                    result = "";
                    
                    for (int c = 1; c <= colCount; c++)
                    {
                       
                        value += "\"" + xlRange.Cells[b, c].Value2.ToString() + "\",";                       
                       result = value.Substring(0, value.Length - 1);
                        

                  }

                    


                    string[] campos = okf.Split(',');
                    string[] valores = result.Split(',');


                    string wek = "";
                    string query2 = "Select count(*) from " + Hojas.Name + " where ";

                    for (int j = 0; j < 1; j++)
                    {
                        query2 = "Select count(*) from " + Hojas.Name + " where ";

                        for (int i = 0; i < 3; i++)
                        {

                            query2 += campos[i] + "=" + valores[i] + " and ";


                        }

                        wek = query2.Substring(0, query2.Length - 4);
                        int ifs = 0;
                        using (var conn = new MySqlConnection(segundacadena))
                        {
                            conn.Open();
                            using (var cmd = new MySqlCommand(wek, conn))
                            {
                                int count = Convert.ToInt32(cmd.ExecuteScalar());

                                ifs = count;
                            }
                            conn.Close();
                        }
                        if (ifs == 1)
                        {

                        }
                        if (ifs == 0)
                        {

                            string Query = "insert into " + Hojas.Name + "(" + okf + " ) values(" + result + ")";
                            MessageBox.Show(Query);
                            MySqlConnection MyConn2 = new MySqlConnection(conString);
                            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                            MySqlDataReader MyReader2;
                            MyConn2.Open();
                            MyReader2 = MyCommand2.ExecuteReader();
                            MyConn2.Close();
                        }

                    }

                }
            }
            string proc = "call proc2()";
            MySqlConnection MyConn1 = new MySqlConnection(conString);
            MySqlCommand MyCommand1 = new MySqlCommand(proc, MyConn1);
            MyConn1.Open();
            var cmd1 = new MySqlCommand(proc, MyConn1);
            MyConn1.Close();
           
            MessageBox.Show("final");
        }
    }
}

