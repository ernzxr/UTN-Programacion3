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
    public partial class ExerciseFormTwo : Form
    {
        public ExerciseFormTwo()
        {
            InitializeComponent();
        }

        private void btnReturm2_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm formMenuPrincipal = new MainForm();
            formMenuPrincipal.Show();
        }
    }
}
