using System;
using System.Windows.Forms;

namespace Speach
{
    public partial class ProfilesForm : Form
    {
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
    }
}
