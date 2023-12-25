using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2vst
{
    public interface ICheckSumCalculator
    {
        public BitArray CalculateVerticalParityChecksum(BitArray data);
        public BitArray CalculateHorizontalParityChecksum(BitArray data);

        public BitArray CalculateCRC(BitArray data);
    }
}
