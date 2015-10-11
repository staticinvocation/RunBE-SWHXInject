using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWHXInject
{
    public partial class InjectMain : Form
    {

        public enum HookType : int
        {
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }


        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetWindowsHookEx(HookType hookType, IntPtr lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string sClass, string sWindow);

        string[] targetClassnames = { "ArmA 2 OA", "DayZ", "ArmA 3" };

        public InjectMain()
        {
            InitializeComponent();
        }

        private string ExecuteAndRead(string program, string args)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = program;
            proc.StartInfo.Arguments = args;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            return proc.StandardOutput.ReadToEnd();
        }

        private bool CreateService()
        {
            string cwd = System.IO.Directory.GetCurrentDirectory();
            Process.Start("sc", "create RunBE type= kernel start= demand binPath= \"" + cwd + "\\RunBE.sys\"");
            string result = ExecuteAndRead("sc", "start RunBE");
            return result.Contains("maximum number of secrets");
        }

        private void Cleanup()
        {
            Process.Start("sc", "stop RunBE");
            Process.Start("sc", "delete RunBE");
            Process.Start("wevtutil", "cl System");
        }

        public void SetHook(IntPtr ipdl, IntPtr addr)
        {

            IntPtr handle = SetWindowsHookEx(HookType.WH_MOUSE, addr, ipdl, (uint)0);
            if (handle == IntPtr.Zero)
            {
                MessageBox.Show("Injection failed to set hook.");
                return;
            }
            Thread.Sleep(10000);
        }

        public void SilentThread(IntPtr ipdl, IntPtr addr)
        {
            while (true)
            {
                Thread.Sleep(1000);
                foreach(string s in targetClassnames) {
                    if(FindWindow(s, null) > 0) {
                        SetHook(ipdl, addr);
                        return;
                    }
                }
            }
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
            string file = s[0];
            if (!file.EndsWith(".dll"))
            {
                MessageBox.Show("The filetype provided is not supported by RunBE.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new LoadingBox("Initializing driver...", () =>
            {
                if (!CreateService())
                {
                    MessageBox.Show("The RunBE driver could not be loaded. Make sure RunBE.sys is in the same directory as the injector.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cleanup();
                    Application.Exit();
                }
                Cleanup();
            }).ShowDialog();
            IntPtr ipdl = (IntPtr)0, addr = (IntPtr)0;
            new LoadingBox("Preparing DLL for injection...", () =>
            {
                ipdl = LoadLibrary(file);
                if (ipdl == IntPtr.Zero)
                {
                    MessageBox.Show("Injection failed: could not load target DLL.");
                    Application.Exit();
                    return;
                }
                addr = GetProcAddress(ipdl, txtFunction.Text);
                if (addr == IntPtr.Zero)
                {
                    MessageBox.Show("Injection failed: could not DLL entrypoint (did you read the documentation?).");
                    Application.Exit();
                    return;
                }
            }).ShowDialog();
            MessageBox.Show("Injection has been queued successfully. Press OK and then launch the target game.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            var thread = new Thread(() => SilentThread(ipdl, addr));
            thread.Start();
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InjectMain_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            if (random.Next(9) == 1)
            {
                panel1.BackgroundImage = SWHXInject.Properties.Resources.realicon;
            }
        }
    }
}
