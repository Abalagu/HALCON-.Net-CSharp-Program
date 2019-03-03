using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace ExportProgram1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
        public void button1_Click(object sender, EventArgs e)
        {
            HWindow hWindow = hSmartWindowControl1.HalconWindow;
            new HDevelopExport(hWindow);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
    }
}
