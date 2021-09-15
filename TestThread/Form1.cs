using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.Geoprocessor;

namespace TestThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Threading.Thread.Sleep(1000);
            Splasher.Status = "正在初始化界面...";

            System.Threading.Thread.Sleep(1000);
            Splasher.Status = "正在读取数据..";

            System.Threading.Thread.Sleep(1000);
            Splasher.Status = "正在干活...";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            Splasher.Status = "正在加载窗体...";

            System.Threading.Thread.Sleep(1000);
            Splasher.Status = "正在打开文档...";

            Splasher.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //显示你定义要执行的GP工具的对话框 和空间插值那些一样

            SplasherGP.Show();
            System.Threading.Thread.Sleep(400);
            SplasherGP.Status = "正在创建GP执行工具...";
            System.Threading.Thread.Sleep(400);

            GPMessageEventHandler gpEventHandler = new GPMessageEventHandler();

            //get an instance of the geoprocessor
            Geoprocessor GP = new Geoprocessor();
            //register the event helper in order to be able to listen to GP events
            GP.RegisterGeoProcessorEvents(gpEventHandler);

            //wire the GP events
            gpEventHandler.GPMessage += new MessageEventHandler(OnGPMessage);
            gpEventHandler.GPPreToolExecute += new PreToolExecuteEventHandler(OnGPPreToolExecute);
            gpEventHandler.GPToolboxChanged += new ToolboxChangedEventHandler(OnGPToolboxChanged);
            gpEventHandler.GPPostToolExecute += new PostToolExecuteEventHandler(OnGPPostToolExecute);

            //instruct the geoprocessing engine to overwrite existing datasets
            GP.OverwriteOutput = true;

            System.Threading.Thread.Sleep(500);
            SplasherGP.Status = "工具创建完毕...";
            
            //create instance of the 'create random points' tool. Write the output to the machine's temp directory
            CreateFeatureclass createFeatureClass = new CreateFeatureclass("C:\\", "RandomPoints.shp");
           
            //execute the tool

            GP.Execute(createFeatureClass, null);

            //unwire the GP events
            gpEventHandler.GPMessage -= new MessageEventHandler(OnGPMessage);
            gpEventHandler.GPPreToolExecute -= new PreToolExecuteEventHandler(OnGPPreToolExecute);
            gpEventHandler.GPToolboxChanged -= new ToolboxChangedEventHandler(OnGPToolboxChanged);
            gpEventHandler.GPPostToolExecute -= new PostToolExecuteEventHandler(OnGPPostToolExecute);

            //unregister the event helper
            GP.UnRegisterGeoProcessorEvents(gpEventHandler);

            if (SplasherGP.bIsClose())
            {
                SplasherGP.Close();
            }


        }

        static void OnGPPostToolExecute(object sender, GPPostToolExecuteEventArgs e)
        {

            System.Threading.Thread.Sleep(200);
            SplasherGP.Status = e.Result.ToString() + "...\r\n";
        }

        static void OnGPToolboxChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            SplasherGP.Status =  "GP工具发生了改变...\r\n";
           
        }

        static void OnGPPreToolExecute(object sender, GPPreToolExecuteEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            SplasherGP.Status = e.Description + "...\r\n";

        }

        static void OnGPMessage(object sender, GPMessageEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            SplasherGP.Status = e.Message + "...\r\n";
           
        }

    }
}
