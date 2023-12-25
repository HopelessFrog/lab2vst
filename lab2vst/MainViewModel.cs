using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using DevExpress.Mvvm;

namespace lab2vst
{
    public class MainViewModel : ViewModelBase
    {
        public string CheckSum { get; set; }
        public string Data { get; set;}


        public bool StatusData1 { get; set; } = false;
        public bool StatusData2 { get; set; } = false;

        private IFileService _fileService;
        private ICheckSumCalculator _checkSumCalculator;

        public MainViewModel()
        {
            _checkSumCalculator = new CheckSumCalculator();
            _fileService = new FileService();
        }

        public ICommand OpenData1
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    StatusData1 = false;
                    var path = _fileService.ImortData();
                    if (string.IsNullOrWhiteSpace(path))
                        return;

                    Data = File.ReadAllText(path);
                    
                    StatusData1 = true;
                });
            }



        }
        public ICommand OpenData2
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    StatusData2 = false;
                    var path = _fileService.ImortData();
                    if(string.IsNullOrWhiteSpace(path))
                        return;

                    CheckSum = File.ReadAllText(path);

                    StatusData2 = true;
                });
            }



        }

        public ICommand Compare
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    string message = "";
                    if (StatusData1 && StatusData2)
                    {
                        var horSum = CheckSum.Split("\n")[1];
                        var verSum = CheckSum.Split("\n")[3];
                        var cSum = CheckSum.Split("\n")[5];
                        byte[] bytes = Encoding.UTF8.GetBytes(Data);
                        BitArray datArray =  new BitArray(bytes);
                        var sum1 = Something.BitArrayToHexString(
                            _checkSumCalculator.CalculateVerticalParityChecksum(datArray));
                        if (verSum == sum1 )
                        {
                            message += "Vertical check sum match\n";
                        }
                        else
                        {
                            message += "Vertical check sum don`t match\n";
                        }
                        if (horSum == Something.BitArrayToHexString(_checkSumCalculator.CalculateHorizontalParityChecksum(datArray)))
                        {
                            message += "Horizontal check sum match\n";
                        }
                        else
                        {
                            message += "Horizontal check sum don`t match\n";
                        }

                        var qwe = Something.BitArrayToHexString(
                            _checkSumCalculator.CalculateCRC(datArray));
                        if (cSum == Something.BitArrayToHexString(_checkSumCalculator.CalculateCRC(datArray)))
                        {
                            message += "CRC check sum match\n";
                        }
                        else
                        {
                            message += "CRC check sum don`t match\n";
                        }

                        MessageBox.Show(message);
                    }
                    else
                    {
                        MessageBox.Show("Set data end Check sum");
                    }
                });
            }
        }

        public ICommand GetCheckSum
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var path = _fileService.ImortData();
                    if (string.IsNullOrWhiteSpace(path))
                        return;
                    var data = new BitArray(File.ReadAllBytes(path));

                    _fileService.ExportData(
                       Something.BitArrayToHexString(_checkSumCalculator.CalculateHorizontalParityChecksum(data)),
                          Something.BitArrayToHexString(_checkSumCalculator.CalculateVerticalParityChecksum(data)),
                        Something.BitArrayToHexString(_checkSumCalculator.CalculateCRC(data))
                        );
                });
            }
        }
    }
}
