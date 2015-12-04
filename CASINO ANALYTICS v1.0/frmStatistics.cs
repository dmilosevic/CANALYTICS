using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace CASINO_ANALYTICS_v1._0
{
    public partial class frmStatistics : Form
    {
        public frmStatistics()
        {
            InitializeComponent();
            
        }

        
        List<Data> list; //holding all of the data form database table 'data'
        List<Data> results; //pretty straightforward xexe
        private string dmy;
        private List<Data> getStatsForYear(string table, int year) //UKUPNO I PROSECNO ZA TU GODINU
        {
            List<Data> ret = new List<Data>();
            double totalDrop = 0;
            double totalResult = 0;
            double totalHC = 0;

            int kolikoIhJe = 0;

            double avgDrop = 0;
            double avgResult = 0;
            double avgHc = 0;

            foreach (Data item in list)
            {
                if (item.tableName == table && item.year == year)
                {
                    kolikoIhJe++;
                    totalDrop += item.drop;
                    totalResult += item.result;
                    totalHC += item.headcount;
                    ret.Add(item);
                }
            }
            avgDrop = totalDrop / kolikoIhJe;
            avgResult = totalResult / kolikoIhJe;
            avgHc = totalHC / kolikoIhJe;

            tbAvgDropSelected.Text = avgDrop.ToString();
            tbAvgResultSelected.Text = avgResult.ToString();
            tbAvgHcSelected.Text = avgHc.ToString();

            totalDropSelected.Text = totalDrop.ToString();
            totalResultSelected.Text = totalResult.ToString();
            totalHeadcountSelected.Text = totalHC.ToString();

            return ret;

        }

        private List<Data> getStatsForMonth(string table, int year, int month) //UKUPNO I PROSECNO ZA TAJ MESEC
        {
            List<Data> ret = new List<Data>();
            double totalDrop = 0;
            double totalResult = 0;
            double totalHC = 0;

            int kolikoIhJe = 0;

            double avgDrop = 0;
            double avgResult = 0;
            double avgHc = 0;

            foreach (Data item in list)
            {
                if (item.tableName == table && item.year == year && item.month == month)
                {
                    kolikoIhJe++;
                    totalDrop += item.drop;
                    totalResult += item.result;
                    totalHC += item.headcount;
                    ret.Add(item);
                }
            }

            avgDrop = totalDrop / kolikoIhJe;
            avgResult = totalResult / kolikoIhJe;
            avgHc = totalHC / kolikoIhJe;

            tbAvgDropSelected.Text = avgDrop.ToString();
            tbAvgResultSelected.Text = avgResult.ToString();
            tbAvgHcSelected.Text = avgHc.ToString();

            totalDropSelected.Text = totalDrop.ToString();
            totalResultSelected.Text = totalResult.ToString();
            totalHeadcountSelected.Text = totalHC.ToString();

            return ret;

        }

        private List<Data> getStatsForDay(string table, int year, int month, int day) //UKUPNO I PROSECNO ZA TAJ DAN
        {
            List<Data> ret = new List<Data>();
            double totalDrop = 0;
            double totalResult = 0;
            double totalHC = 0;

            int kolikoIhJe = 0;

            double avgDrop = 0;
            double avgResult = 0;
            double avgHc = 0;

            foreach (Data item in list)
            {
                if (item.tableName == table && item.year == year && item.month == month && item.day == day)
                {
                    kolikoIhJe++;
                    totalDrop += item.drop;
                    totalResult += item.result;
                    totalHC += item.headcount;
                    ret.Add(item);
                }
            }
            avgDrop = totalDrop / kolikoIhJe;
            avgResult = totalResult / kolikoIhJe;
            avgHc = totalHC / kolikoIhJe;

            tbAvgDropSelected.Text = avgDrop.ToString();
            tbAvgResultSelected.Text = avgResult.ToString();
            tbAvgHcSelected.Text = avgHc.ToString();

            totalDropSelected.Text = totalDrop.ToString();
            totalResultSelected.Text = totalResult.ToString();
            totalHeadcountSelected.Text = totalHC.ToString();

            return ret;

        }

        private void frmStatistics_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            rbDaily.Checked = true;
            DataGridViewColumn c0 = dataGridView1.Columns[0];
            DataGridViewColumn c1 = dataGridView1.Columns[1];
            DataGridViewColumn c2 = dataGridView1.Columns[2];
            DataGridViewColumn c3 = dataGridView1.Columns[3];
            DataGridViewColumn c4 = dataGridView1.Columns[4];
            DataGridViewColumn c5 = dataGridView1.Columns[5];
            DataGridViewColumn c6 = dataGridView1.Columns[6];
            DataGridViewColumn c7 = dataGridView1.Columns[7];
            DataGridViewColumn c8 = dataGridView1.Columns[8];
            DataGridViewColumn c9 = dataGridView1.Columns[9];

            c1.Width = c2.Width = c3.Width = c4.Width = c5.Width = c6.Width = c7.Width = c8.Width = c9.Width = 78;

            #region Populate listbox with table names

            DbConnect conn = new DbConnect();
            List<Table> listaStolova = new List<Table>();

            conn.openConnection();
            listaStolova = conn.selectTables();
            lbTables.Items.Clear();

            foreach (Table item in listaStolova)
            {
                lbTables.Items.Add(item.getTableName());
            }

            lbTables.SelectedIndex = 0; //select first table on load

            #endregion

            list = conn.getAllData();

            //print statistics for database right upper corner
            int userCount = 0, tableCount = 0, dataCount = 0;
            foreach (Data item in list)
            {
                dataCount++;
            }
            List<Table> tablelist = new List<Table>();
            tablelist = conn.selectTables();
            foreach (Table item in tablelist)
            {
                tableCount++;
            }
            List<User> userlist = new List<User>();
            userlist = conn.selectUsers();
            foreach (User item in userlist)
            {
                userCount++;
            }
            conn.closeConnection();
            lblDataInfoData.Text = dataCount.ToString();
            lblDataInfoTables.Text = tableCount.ToString();
            lblDataInfoUsers.Text = userCount.ToString();

        }

        private void rbDaily_CheckedChanged(object sender, EventArgs e)
        {
            resetAll();
            if(rbDaily.Checked)
            {
                cbDayDaily.Text = DateTime.Today.Day.ToString();
                cbMonthDaily.Text = DateTime.Today.Month.ToString();
                tbYearDaily.Text = DateTime.Today.Year.ToString();

                cbMonthMonthly.Enabled = false;
                tbYearMonthly.Enabled = false;
                tbYearAnnual.Enabled = false;
            }
            
        }

        private void resetAll()
        {
            cbDayDaily.Text = cbMonthDaily.Text = tbYearDaily.Text = "";
            cbMonthMonthly.Text = tbYearMonthly.Text = "";
            tbYearAnnual.Text = "";

            cbDayDaily.Enabled = true;
            cbMonthDaily.Enabled = true;
            tbYearDaily.Enabled = true;
            cbMonthMonthly.Enabled = true;
            tbYearMonthly.Enabled = true;
            tbYearAnnual.Enabled = true;

        }

        private void rbMonthly_CheckedChanged(object sender, EventArgs e)
        {
            resetAll();
            if(rbMonthly.Checked)
            {
                cbDayDaily.Enabled = cbMonthDaily.Enabled = tbYearDaily.Enabled = false;
                tbYearAnnual.Enabled = false;
            }
            
        }

        private void rbAnnual_CheckedChanged(object sender, EventArgs e)
        {
            resetAll();
            if(rbAnnual.Checked)
            {
                cbDayDaily.Enabled = cbMonthDaily.Enabled = tbYearDaily.Enabled = false;
                cbMonthMonthly.Enabled = tbYearMonthly.Enabled = false;
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lbTables.SelectedIndex < 0)
                return;
            double totalDrop = 0;
            double totalResult = 0;
            double totalHC = 0;

            int kolikoIhJe = 0;

            double avgDrop = 0;
            double avgResult = 0;
            double avgHc = 0;

            string tbName = lbTables.SelectedItem.ToString();
            lblTableName.Text = tbName;
            //daily checked
            int dayDay, monthDay, yearDay;
            //monthly checked
            int monthMonth, yearMonth;
            //yearly checked
            int yearYear;

            #region checks if empty and calculate
            if (rbAnnual.Checked)
            {
                if (tbYearAnnual.Text == "")
                {
                    MessageBox.Show("Enter all the values needed", "Error");
                    return;
                }
                yearYear = Int32.Parse(tbYearAnnual.Text);

               results = getStatsForYear(tbName,yearYear); //DONJI BOXOVI ZA GODINU
               dmy = "yearly";
            }

            else if (rbMonthly.Checked)
            {
                if (cbMonthMonthly.Text == "" || tbYearMonthly.Text == "")
                {
                    MessageBox.Show("Enter all the values needed", "Error");
                    return;
                }
                monthMonth = Int32.Parse(cbMonthMonthly.Text);
                yearMonth = Int32.Parse(tbYearMonthly.Text);

                results = getStatsForMonth(tbName, yearMonth, monthMonth); //DONJI BOXOVI ZA MESEC
                dmy = "monthly";
            }
            else if (rbDaily.Checked)
            {
                if (cbDayDaily.Text == "" || cbMonthDaily.Text == "" || tbYearDaily.Text == "")
                {
                    MessageBox.Show("Enter all the values needed", "Error");
                    return;
                }
                dayDay = Int32.Parse(cbDayDaily.Text);
                monthDay = Int32.Parse(cbMonthDaily.Text);
                yearDay = Int32.Parse(tbYearDaily.Text);

               results = getStatsForDay(tbName, yearDay, monthDay, dayDay); //DONJI BOXOVI ZA DAN
               dmy = "daily";
            }
            #endregion

            #region overall for table
            
            foreach (Data d in list)
            {
                if (d.tableName == tbName)
                {
                    kolikoIhJe++;
                    totalDrop += d.drop;
                    totalResult += d.result;
                    totalHC += d.headcount;
                }
            }
            avgDrop = totalDrop / kolikoIhJe;
            avgResult = totalResult / kolikoIhJe;
            avgHc = totalHC / kolikoIhJe;

            tbAvgDrop.Text = avgDrop.ToString();
            tbAvgResult.Text = avgResult.ToString();
            tbAvgHc.Text = avgHc.ToString();

            tbTotalDrop.Text = totalDrop.ToString();
            tbTotalHeadcount.Text = totalHC.ToString();
            tbTotalResult.Text = totalResult.ToString();
            #endregion

            //do magic
            dataGridView1.Rows.Clear();

            foreach(Data d in results)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = d.tableName;
                row.Cells[1].Value = d.year;
                row.Cells[2].Value = d.month;
                row.Cells[3].Value = d.day;
                row.Cells[4].Value = d.fromH;
                row.Cells[5].Value = d.toH;
                row.Cells[6].Value = d.drop;
                row.Cells[7].Value = d.result;
                row.Cells[8].Value = d.headcount;
                row.Cells[9].Value = d.user;

                dataGridView1.Rows.Add(row);
            }

            


        }

        private void btnSavetotxtSpec_Click(object sender, EventArgs e)
        {
            //if empty - there's nothing to save
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Data grid needs to have at least 1 row to enable saving to .txt", "Information");
                return;
            }
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            string date = DateTime.Today.ToShortDateString();
            int m = DateTime.Today.Month;
            int y = DateTime.Today.Year;
            string tbl = lbTables.SelectedItem.ToString();
            if (rbDaily.Checked)
            {
                
                saveFileDialog1.FileName = tbl+"-"+date.Replace('/', '.') + "-canalyticsStats";
            }
            else if (rbMonthly.Checked)
            {

                saveFileDialog1.FileName = tbl + "-" + m.ToString() + "." + y.ToString() + "-canalyticsStats";

            }
            else if (rbAnnual.Checked)
            {
                saveFileDialog1.FileName = tbl + "-" + y.ToString() + "-canalyticsStats";
            }
            saveFileDialog1.ShowDialog();
            

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string path = saveFileDialog1.FileName;

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("Table\tYear\tMonth\tDay\tStart\tEnd\tDrop\tResult\tHC\tUser");

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                object dat1 = row.Cells[0].Value;
                object dat2 = row.Cells[1].Value;
                object dat3 = row.Cells[2].Value;
                object dat4 = row.Cells[3].Value;
                object dat5 = row.Cells[4].Value;
                object dat6 = row.Cells[5].Value;
                object dat7 = row.Cells[6].Value;
                object dat8 = row.Cells[7].Value;
                object dat9 = row.Cells[8].Value;
                object dat10 = row.Cells[9].Value;

                sw.WriteLine(dat1 + "\t" + dat2 + "\t" + dat3 + "\t" + dat4 + "\t" + dat5 + "\t" + dat6 + "\t" + dat7 + "\t" + dat8 + "\t" + dat9 + "\t" + dat10, true);
            }

            sw.Close();
        }
        StringFormat strFormat;
        ArrayList arrColumnLefts = new ArrayList();
        ArrayList arrCOlumnWidths = new ArrayList();
        int iCellHeight = 0;
        int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        int iHeaderHeight = 0;
        int iCount = 0;

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrCOlumnWidths.Clear();
                iCellHeight = 0;
                iCount = 0;
                bFirstPage = true;
                bNewPage = true;

                iTotalWidth = 0;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    iTotalWidth += col.Width;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                            (double)iTotalWidth * (double)iTotalWidth *
                            ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrCOlumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Casino Analytics",
                                new Font(dataGridView1.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left,
                                e.MarginBounds.Top - e.Graphics.MeasureString("Casino Analytics",
                                new Font(dataGridView1.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " +
                                DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font(dataGridView1.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                new Font(dataGridView1.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString("Casino Analytics",
                                new Font(new Font(dataGridView1.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrCOlumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrCOlumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrCOlumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(),
                                    Cel.InheritedStyle.Font,
                                    new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrCOlumnWidths[iCount], (float)iCellHeight),
                                    strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrCOlumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        private void btnPrintSpec_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Data grid needs to have at least 1 row to be enabled to print.", "Information");
                return;
            }

            //print

            PrintDialog pd = new PrintDialog();
            pd.Document = printDocument1;
            pd.UseEXDialog = true;

            if (DialogResult.OK == pd.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmGraphStatistics frmgraph = new frmGraphStatistics(lbTables.SelectedItem.ToString(),dmy,results);
            frmgraph.ShowDialog();
        }
    }
}
