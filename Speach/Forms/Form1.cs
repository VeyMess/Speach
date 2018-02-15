using System;
using System.Windows.Forms;
using System.Xml;
using WindowsInput;

namespace Speach
{
    public partial class Form1 : Form
    {
        private XmlDocument doc;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Speech.WordsDetected += rec_Recognized;
            Speech.Inicil();
        }

        /*
        void rec_Recognized(DetectedEventArgs recog)
        {
                InputSimulator inp = new InputSimulator();
                WindowsInput.Native.VirtualKeyCode ex = WindowsInput.Native.VirtualKeyCode.LBUTTON;

                switch (recog.Detected.Remove(0,5))
                {
                    case "навигация" : ex = WindowsInput.Native.VirtualKeyCode.VK_1;break;
                    case "системы": ex = WindowsInput.Native.VirtualKeyCode.VK_4; break;
                    case "карта галактики": ex = WindowsInput.Native.VirtualKeyCode.OEM_PLUS; break;
                    case "карта системы": ex = WindowsInput.Native.VirtualKeyCode.OEM_MINUS; break;
                    case "буст": ex = WindowsInput.Native.VirtualKeyCode.TAB; break;
                    case "стоп": ex = WindowsInput.Native.VirtualKeyCode.VK_X; break;
                    case "связь": ex = WindowsInput.Native.VirtualKeyCode.VK_2; break;
                    case "функции": ex = WindowsInput.Native.VirtualKeyCode.VK_3; break;
                    case "полный ход": ex = WindowsInput.Native.VirtualKeyCode.VK_0; break;
                    case "свет": ex = WindowsInput.Native.VirtualKeyCode.INSERT; break;
                    case "прыжок": ex = WindowsInput.Native.VirtualKeyCode.VK_J; break;
                    case "оружие": ex = WindowsInput.Native.VirtualKeyCode.VK_U; break;
                    case "назад": ex = WindowsInput.Native.VirtualKeyCode.BACK; break;
                    case "шасси": ex = WindowsInput.Native.VirtualKeyCode.VK_L;break;
                    case "теплоотвод": ex = WindowsInput.Native.VirtualKeyCode.VK_V;break;
                    case "цель": ex = WindowsInput.Native.VirtualKeyCode.VK_T;break;
                    case "враг": ex = WindowsInput.Native.VirtualKeyCode.VK_H; break;
                }

                if (ex != WindowsInput.Native.VirtualKeyCode.LBUTTON)
                {
                    inp.Keyboard.KeyDown(ex);
                    inp.Keyboard.KeyUp(ex);
                }
        }
        */
        void rec_Recognized(DetectedEventArgs recog)
        {
            MessageBox.Show(recog.Detected);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProfilesForm prof = new ProfilesForm();
            prof.ShowDialog();
            if(prof.DialogResult==DialogResult.OK)
            {
                textBox1.Text = prof.answr;
                LoadRulesFromXml();
            }
        }

        private void LoadRulesFromXml()
        {
            doc = new XmlDocument();
            listBox1.Items.Clear();

            doc.Load(Application.StartupPath + "\\Profiles\\" + textBox1.Text + ".spprof");

            XmlElement root = doc.DocumentElement;
            foreach(XmlNode temp in root.ChildNodes)
            {
                if(temp.Name=="rule")
                {
                    listBox1.Items.Add(temp.Attributes["id"].Value);
                }
            }

            button2.Enabled = button3.Enabled = button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            XmlElement rule = doc.CreateElement("rule");
            XmlAttribute id = doc.CreateAttribute("id");
            id.Value = "Testing";

            rule.Attributes.Append(id);
            doc.DocumentElement.AppendChild(rule);

            doc.Save(Application.StartupPath + "\\Profiles\\" + textBox1.Text + ".spprof");

            listBox1.Items.Clear();
            LoadRulesFromXml();
            */

            RuleEdForm crt = new RuleEdForm(doc);
            crt.ShowDialog();
        }
    }
}
