using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Speach
{
    public partial class ProfilesForm : Form
    {
        public Dictionary<string,string> profDict = new Dictionary<string, string>();
        public ProfilesForm()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreProfForm cpf = new CreProfForm(this);
            this.Enabled = false;
            cpf.Show(this);
        }

        private void DirectCheck()
        {
            string profDirector = Application.StartupPath + "\\Profiles";

            if (!Directory.Exists(profDirector))
                Directory.CreateDirectory(profDirector);

            profDict.Clear();
            foreach (string prof in Directory.GetFiles(profDirector+'\\', "*.spprof", SearchOption.TopDirectoryOnly))
            {
                string n = prof.Substring(profDirector.Length+1);
                profDict.Add(n.Remove(n.Length - 7), prof);
            }

            if (profDict.Count != 0)
            {
                listBox1.Items.Clear();
                foreach(string k in profDict.Keys)
                {
                    listBox1.Items.Add(k);
                }
            }
        }

        private void ProfilesForm_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled == true)
                DirectCheck();
        }

        private void ProfilesForm_Shown(object sender, EventArgs e)
        {
            DirectCheck();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex>=0)
                button1.Enabled = true;
        }
    }
}
