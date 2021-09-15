using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestThread
{
    //显示启动画面 测试改动
    public class Splasher
    {
        static Form2 MySplashForm = null;
        static Thread MySplashThread = null;

        //	internally used as a thread function - showing the form and
        //	starting the messageloop for it
        static void ShowThread()
        {
            MySplashForm = new Form2();
            Application.Run(MySplashForm);
        }

        //	public Method to show the SplashForm
        static public void Show()
        {
            if (MySplashThread != null)
                return;

            MySplashThread = new Thread(new ThreadStart(Splasher.ShowThread));
            MySplashThread.IsBackground = true;
            MySplashThread.GetApartmentState();
            MySplashThread.Start();
        }

        //	public Method to hide the SplashForm
        static public void Close()
        {
            if (MySplashThread == null) return;
            if (MySplashForm == null) return;

            try
            {
                MySplashForm.Invoke(new MethodInvoker(MySplashForm.Close));
            }
            catch (Exception)
            {
            }
            MySplashThread = null;
            MySplashForm = null;
        }

        //	public Method to set or get the loading Status
        static public string Status
        {
            set
            {
                if (MySplashForm == null)
                {
                    return;
                }

                MySplashForm.StatusInfo = value;
            }
            get
            {
                if (MySplashForm == null)
                {
                    throw new InvalidOperationException("Splash Form not on screen");
                }
                return MySplashForm.StatusInfo;
            }
        }
    }
    //监测GP执行信息
    public class SplasherGP
    {
        static SplashFormGP MySplashForm = null;
        static Thread MySplashThread = null;
        static public bool bIsShow = false;
        //	internally used as a thread function - showing the form and
        //	starting the messageloop for it
        static void ShowThreadGP()
        {
            MySplashForm = new SplashFormGP();
            Application.Run(MySplashForm);
        }

        //	public Method to show the SplashForm
        static public void Show()
        {
            if (MySplashThread != null)
            {
                if (MySplashThread.ThreadState != ThreadState.Stopped)
                    return;
            }
            MySplashThread = new Thread(new ThreadStart(SplasherGP.ShowThreadGP));
            bIsShow = true;
            MySplashThread.IsBackground = true;
            MySplashThread.GetApartmentState();
            MySplashThread.Start();
        }
        static public void Hide()
        {
            if (MySplashThread == null) return;
            if (MySplashForm == null) return;

            try
            {
                bIsShow = false;
                MySplashForm.Invoke(new MethodInvoker(MySplashForm.Hide));
            }
            catch (Exception)
            {
            }
        }
        static public bool bIsClose()
        {
            if (MySplashThread == null) return false;
            if (MySplashForm == null) return false;

            try
            {
                return MySplashForm.chkClose.Checked;
            }
            catch (Exception)
            {
            }
            return false;
        }
        static public void Show2()
        {
            if (MySplashThread == null)
            {
                Show();
                return;
            }
            if (MySplashForm == null) return;

            try
            {
                bIsShow = true;
                MySplashForm.Invoke(new MethodInvoker(MySplashForm.Show));
            }
            catch (Exception)
            {
            }
        }
        //	public Method to hide the SplashForm
        static public void Close()
        {
            if (MySplashThread == null) return;
            if (MySplashForm == null) return;

            try
            {
                bIsShow = false;
                MySplashForm.Invoke(new MethodInvoker(MySplashForm.Close));
            }
            catch (Exception)
            {
            }
            MySplashThread = null;
            MySplashForm = null;
        }

        //	public Method to set or get the loading Status
        static public string Status
        {
            set
            {
                if (MySplashForm == null)
                {
                    return;
                }

                MySplashForm.StatusInfo = value;
            }
            get
            {
                if (MySplashForm == null)
                {
                    throw new InvalidOperationException("Splash Form not on screen");
                }
                return MySplashForm.StatusInfo;
            }
        }
        static public string Title
        {
            set
            {
                if (MySplashForm == null)
                {
                    return;
                }

                 MySplashForm.Text = value;
            }
            get
            {
                if (MySplashForm == null)
                {
                    throw new InvalidOperationException("Splash Form not on screen");
                }
                return MySplashForm.Text;
            }
        }
        static public void FullOver()
        {
            if (MySplashForm == null)
            {
                return;
            }

            MySplashForm.FullProgressbar();
        }
    }
}
