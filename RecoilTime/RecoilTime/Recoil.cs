using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecoilTime
{
    class Recoil
    {
        public static bool Enabled = true;
        public static int sleeptime = 1;
        public static int strength = 2;

        public static void Loop()
        {
            while (true)
            {
                Thread.Sleep(sleeptime);

                if ((Win32.GetKeyState(0x2D) & 0x8000) > 0)
                {
                    Enabled = !Enabled;
                    if (Enabled)
                    {
                        Win32.Beep(800, 500);
                    } else
                    {
                        Win32.Beep(300, 500);
                    }
                    Thread.Sleep(1000);
                }

                if (!Enabled) continue;

                if ((Win32.GetKeyState(0x01) & 0x8000) > 0)
                {
                    for (int i = 0; i < strength; i++)
                    {
                        Win32.Move(0, 1);
                    }
                }
            }
        }
    }
}
