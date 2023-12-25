using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2vst
{
    public class CheckSumCalculator :ICheckSumCalculator
    {
        private const int rowSize = 8;
        private BitArray generator = new BitArray(new bool[] { true, false, true, false, false, true });
        public  BitArray CalculateVerticalParityChecksum(BitArray data)
        {
            int colCount = rowSize;

            BitArray verticalParity = new BitArray(rowSize);

            for (int col = 0; col < colCount; col++)
            {
                for (int row = 0; row < data.Length / rowSize; row++)
                {
                    if (data[row * rowSize + col])
                    {
                        verticalParity.Set(col, !verticalParity[col]);
                    }
                }
            }

            return verticalParity;
        }


       

        public  BitArray CalculateHorizontalParityChecksum(BitArray data)
        {
            int rowCount = data.Length / rowSize;

            BitArray horizontalParity = new BitArray(rowCount);

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < rowSize; col++)
                {
                    if (data[row * rowSize + col])
                    {
                        horizontalParity.Set(row, !horizontalParity[row]);
                    }
                }
            }

            return horizontalParity;
        }

        

        public  BitArray CalculateCRC(BitArray data)
        {
            int dataLength = data.Length;
            int generatorLength = generator.Length;

            BitArray result = new BitArray(dataLength + generatorLength - 1);

            for (int i = 0; i < dataLength; i++)
            {
                if (data[i])
                {
                    for (int j = 0; j < generatorLength; j++)
                    {
                        result.Set(i + j, result[i + j] ^ generator[j]);
                    }
                }
            }

            return new BitArray(result);
        }

        
    }
}
