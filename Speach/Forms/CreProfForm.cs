using System.Windows.Forms;
using System.IO;
using System;
using System.Collections.Generic;

namespace Speach
{
    public partial class CreProfForm : Form
    {
        private ProfilesForm prf;
        public CreProfForm(ProfilesForm frm)
        {
            InitializeComponent();
            prf = frm;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if(prf.profDict!=null)
            {
                if(!prf.profDict.ContainsKey(textBox1.Text))
                {
                    File.Create(Application.StartupPath + "\\Profiles\\" + textBox1.Text + ".spprof");
                    this.Owner.Enabled = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Профиль с таким названием уже существует");
                }
            }
        }
    }
}
