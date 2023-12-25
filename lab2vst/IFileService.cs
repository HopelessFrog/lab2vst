using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2vst
{
    public interface IFileService
    {
        public void ExportData(string HorizontalCS, string VerticalCS, string CyclicCS);

        public string ImortData();


    }
}
