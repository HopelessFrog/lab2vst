using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace lab2vst
{
    public class FileService : IFileService
    {
        public void ExportData(string HorizontalCS, string VerticalCS, string CyclicCS)
        {
            string FilePath = "";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.OverwritePrompt = true;
            dialog.Filter = "Css|*.css";
            if (dialog.ShowDialog() == true)
            {
                FilePath = dialog.FileName;
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Wrong path", "",
                    MessageBoxButton.OK, MessageBoxImage.Asterisk);
               
                return;
                
            }

            Stream stream = new FileStream(FilePath, FileMode.Create);
            StreamWriter sw = new StreamWriter(stream);
            sw.Write("H\n");
            sw.Write(HorizontalCS);
            sw.Write("\n");
            sw.Write("V \n");
          
            sw.Write(VerticalCS);
            sw.Write("\n");
            sw.Write("C \n");
           
            sw.Write(CyclicCS);
            sw.Flush();
            sw.Close();
        }

        public string ImortData()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                 return  dialog.FileName;
            }
            else
            {
               

                return "";
            }
        }

      
    }
}
