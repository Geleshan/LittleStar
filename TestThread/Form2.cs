using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestThread
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string StatusInfo
        {
            set
            {
                _StatusInfo = value;
                ChangeStatusText();
            }
            get
            {
                return _StatusInfo;
            }
        }

        public void ChangeStatusText()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(this.ChangeStatusText));
                    return;
                }

                lStatusInfo.Text = _StatusInfo;
                if (progressBar1.Value >= progressBar1.Maximum)
                {
                    progressBar1.Value = 5;
                }
                else
                {
                    progressBar1.Value += 5;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Slpash ChangeStatusText:Error " + ex.Message);
            }
        }
        private string _StatusInfo = "";

    }
}
