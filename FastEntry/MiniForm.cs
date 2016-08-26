using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastEntry
{
    public partial class MiniForm : Form
    {
        public MiniForm()
        {
            InitializeComponent();
        }

        private void MiniForm_MouseHover(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            Form scalemain = null;
            foreach (Form f in fc)
            {
                if (f.Name == "ScaleMain")
                {
                    scalemain = f;
                }
            }
            scalemain = scalemain ?? new ScaleMain();

            this.Visible = false;
            scalemain.Visible = true;
            scalemain.Show();
        }
    }
}
