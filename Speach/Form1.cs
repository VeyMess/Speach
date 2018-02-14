using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using WindowsInput;

namespace Speach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Speech.dop = rec_Recognized;
            Speech.Inicil();
        }

        void rec_Recognized(string recog)
        {
            Task ts = Task.Factory.StartNew(() =>
            {
                InputSimulator inp = new InputSimulator();
                WindowsInput.Native.VirtualKeyCode ex = WindowsInput.Native.VirtualKeyCode.LBUTTON;

                switch (recog.Remove(0,5))
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
                    inp.Keyboard.Sleep(30);
                    inp.Keyboard.KeyUp(ex);
                }
            });
        }
    }
}
