using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestThread
{
    public partial class SplashFormGP : Form
    {
        delegate void SetValueCallback(int iValue);
        public SplashFormGP()
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
        public void FullProgressbar()
        {
            PBar.Value = PBar.Maximum;
        }
        public void SetValue(int iValue)
        {
            if (PBar.InvokeRequired)
            {
                SetValueCallback d = new SetValueCallback(SetValue);
                this.Invoke(d, new object[] { iValue });
            }
            else
            {
                PBar.Value = iValue;
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
                if (PBar.Value < 100)
                {
                    PBar.Value += 10;
                }
                else
                {
                    PBar.Value = 0;
                }
                txtInfo.Text += _StatusInfo ;
                txtInfo.SelectionStart = txtInfo.Text.Length;
                txtInfo.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Slpash ChangeStatusText:Error " + ex.Message);
            }
        }

        private Label lStatusInfo;
        public CheckBox chkClose;
        private ProgressBar PBar;
        private string _StatusInfo = "";

        private void SplashForm_Load(object sender, EventArgs e)
        {

        }

        private void txtInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void SplashForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    MessageBox.Show(this,"确定要关闭该窗体，若处理过程没有运行完毕，则处理过程将在后台继续运行！","提示...",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //}
        }

     

        private TextBox txtInfo;

        private void InitializeComponent()
        {
            this.lStatusInfo = new System.Windows.Forms.Label();
            this.chkClose = new System.Windows.Forms.CheckBox();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lStatusInfo
            // 
            this.lStatusInfo.AutoSize = true;
            this.lStatusInfo.Location = new System.Drawing.Point(27, 23);
            this.lStatusInfo.Name = "lStatusInfo";
            this.lStatusInfo.Size = new System.Drawing.Size(58, 24);
            this.lStatusInfo.TabIndex = 0;
            this.lStatusInfo.Text = "状态";
            // 
            // chkClose
            // 
            this.chkClose.AutoSize = true;
            this.chkClose.Checked = true;
            this.chkClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClose.Location = new System.Drawing.Point(31, 145);
            this.chkClose.Name = "chkClose";
            this.chkClose.Size = new System.Drawing.Size(186, 28);
            this.chkClose.TabIndex = 1;
            this.chkClose.Text = "执行完毕关闭";
            this.chkClose.UseVisualStyleBackColor = true;
            // 
            // PBar
            // 
            this.PBar.Location = new System.Drawing.Point(31, 66);
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(984, 48);
            this.PBar.TabIndex = 2;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(31, 196);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInfo.Size = new System.Drawing.Size(984, 323);
            this.txtInfo.TabIndex = 3;
            // 
            // SplashFormGP
            // 
            this.ClientSize = new System.Drawing.Size(1060, 552);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.PBar);
            this.Controls.Add(this.chkClose);
            this.Controls.Add(this.lStatusInfo);
            this.Name = "SplashFormGP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}