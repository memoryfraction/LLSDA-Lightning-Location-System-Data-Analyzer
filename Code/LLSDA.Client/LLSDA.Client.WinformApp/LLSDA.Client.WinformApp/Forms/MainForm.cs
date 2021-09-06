using System;
using System.Windows.Forms;

namespace LlsDataanalyzer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            string srcPathFile = Environment.CurrentDirectory + @"\data\Shps\World\world.shp";
            meteoInfoUserControl1.AddLayer(srcPathFile);


            //meteoInfoUserControl1.AddLayer(srcPathFile);
            meteoInfoUserControl1.ZoomExtent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
