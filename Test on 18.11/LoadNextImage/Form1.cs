using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using HalconDotNet;
using System.IO;

namespace LoadNextImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string selectedFolder;
        private HTuple hv_ImageFiles;
        private HTuple hv_Null = new HTuple();
        private HObject ho_Image;


        int indexImage = -1;
        int numImages = 0;


        HWindow window;
        private void hSmartWindowControl1_Load(object sender, EventArgs e)
        {
            window = hSmartWindowControl1.HalconWindow;
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                selectedFolder = dialog.FileName;
                textBox1.Text = selectedFolder;
                buttonLoadImage.Enabled = true;
            }
        }

        void AppendMsg(string input)
        {
            textBoxLog.AppendText(input + "\r\n");
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            var hv_ImageDirectory = new HTuple(selectedFolder);
            Tools.list_image_files(hv_ImageDirectory, "default", hv_Null, out hv_ImageFiles);
            //string[] imageFiles = hv_ImageFiles.ToSArr();
            numImages = hv_ImageFiles.Length;
            if (numImages == 0)
            {
                MessageBox.Show("No image in the folder.");
            }
            else
            {
                buttonNextImage.Enabled = true;
                AppendMsg(numImages + " images loaded");
                Console.WriteLine("hel{0}","hello");
            }
        }

        private void buttonNextImage_Click(object sender, EventArgs e)
        {
            if (numImages == 0)
            {
                MessageBox.Show("No image in the folder.");
                return;
            }
            if (indexImage == -1 || indexImage == numImages - 1)
            {
                indexImage = 0;
            }
            else
            {
                indexImage += 1;
            }
            window.SetPart(0, 0, -2, -2);
            labelFileName.Text = Path.GetFileName(hv_ImageFiles[indexImage]);
            HOperatorSet.ReadImage(out ho_Image, hv_ImageFiles[indexImage]);
            ho_Image.DispObj(window);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonNextImage.Enabled = false;
            buttonLoadImage.Enabled = false;
        }
    }
}
