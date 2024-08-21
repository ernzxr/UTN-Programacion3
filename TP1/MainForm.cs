using System;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void btnExerciseOne_Click(object sender, EventArgs e)
        {
            ExerciseFormOne form1 = new ExerciseFormOne();
            form1.ShowDialog();
        }

        private void btnExerciseTwo_Click(object sender, EventArgs e)
        {
            ExerciseFormTwo form2 = new ExerciseFormTwo();
            form2.ShowDialog();
        }
        private void btnExerciseThree_Click(object sender, EventArgs e)
        {
            ExerciseFormThree form = new ExerciseFormThree();
            form.ShowDialog();
        }
    }
}
