﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CASINO_ANALYTICS_v1._0
{
    public partial class frmGraphStatistics : Form
    {
        public frmGraphStatistics()
        {
            InitializeComponent();
        }
        List<Data> dataList;
        private string tableName;
        private string dmy;

        public frmGraphStatistics(string pushedTableName, string pushedDmy, List<Data> pushedDataList)
        {
            tableName = pushedTableName;
            dmy = pushedDmy;
            dataList = new List<Data>(pushedDataList);
            /*foreach (Data item in pushedDataList)
            {
                dataList.Add(item);
            }*/
            
        }

        private void frmGraphStatistics_Load(object sender, EventArgs e)
        {
            
        }
    }
}
