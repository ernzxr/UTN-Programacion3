﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public partial class ExerciseFormThree : Form
    {
        public ExerciseFormThree()
        {
            InitializeComponent();
        }

        private void btnReturnMenu3_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm formMenuPrincipal = new MainForm();
            formMenuPrincipal.Show();
        }
    }
}
