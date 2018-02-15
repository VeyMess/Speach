using System;
using System.Xml;
using System.Windows.Forms;

namespace Speach
{
    public partial class RuleEdForm : Form
    {
        private XmlDocument doc;
        public RuleEdForm(XmlDocument fath)
        {
            InitializeComponent();
            doc = fath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
