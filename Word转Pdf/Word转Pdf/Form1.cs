using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace Word转Pdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string fileName = string.Empty;
        private string filePath = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog InvokeDialog = new OpenFileDialog();
                InvokeDialog.Title = "选择需要转换的word文件";
                InvokeDialog.Filter = "Word|*.doc";
                InvokeDialog.RestoreDirectory = true;
                if (InvokeDialog.ShowDialog(this) == DialogResult.OK)
                {
                    filePath = InvokeDialog.FileName;
                    fileName = Path.GetFileNameWithoutExtension(filePath);
                    label1.Text = fileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileName) || string.IsNullOrWhiteSpace(filePath))
                {
                    throw new Exception("请选择word");
                }
                SaveFileDialog InvokeDialog = new SaveFileDialog();
                InvokeDialog.Title = "选择导出的pdf地址";
                InvokeDialog.Filter = "PDF文件|*.pdf";
                InvokeDialog.RestoreDirectory = true;
                InvokeDialog.FileName = fileName + ".pdf";
                if (InvokeDialog.ShowDialog(this) == DialogResult.OK)
                {
                    WordToPDF(filePath, InvokeDialog.FileName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        public bool WordToPDF(string sourcePath, string pdfPath)
        {
            bool result = false;
            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            Document document = null;
            try
            {
                application.Visible = false;
                document = application.Documents.Open(sourcePath);
                //string PDFPath = sourcePath.Replace(".doc", ".pdf");//pdf存放位置
                //if (!File.Exists(@PDFPath))//存在PDF，不需要继续转换
                //{
                //    document.ExportAsFixedFormat(PDFPath, Word.WdExportFormat.wdExportFormatPDF);
                //}
                string PDFPath = pdfPath;
                document.ExportAsFixedFormat(PDFPath, WdExportFormat.wdExportFormatPDF);
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            finally
            {
                document.Close();
            }
            return result;
        }
    }
}
