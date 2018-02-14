using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Speach
{
    public partial class ProfilesForm : Form
    {
        Dictionary<string,string> profDict;
        public ProfilesForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreProfForm cpf = new CreProfForm();
            cpf.ShowDialog();
        }

        private void ProfilesForm_Load(object sender, EventArgs e)
        {
            string profDirector = Application.StartupPath + "\\Profiles";

            if (!Directory.Exists(profDirector))
                Directory.CreateDirectory(profDirector);

            foreach (string prof in Directory.GetFiles(profDirector, "*.spprof", SearchOption.TopDirectoryOnly))
            {
                string n = prof.Substring(profDirector.Length);
                profDict.Add(n.Remove(n.Length - 8), prof);
            }

            listBox1.DataSource = profDict;
        }
    }
}
