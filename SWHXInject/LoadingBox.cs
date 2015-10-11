using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWHXInject
{
    public partial class LoadingBox : Form
    {
        Action action;

        public LoadingBox(string caption, Action action)
        {
            InitializeComponent();
            SetCaption(caption);
            SetAction(action);
        }

        public void SetCaption(string caption) {
            this.lblCaption.Text = caption;
        }

        public void SetAction(Action action) {
            this.action = action;
        }

        private void LoadingBox_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                action.Invoke();
                this.Invoke(new MethodInvoker(delegate
                {
                    this.Close();
                }));
            });
        }
    }
}
