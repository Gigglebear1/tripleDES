using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHA1
{
    /// <summary>
    /// takes in any length string of bits and produces a hash of that binary string
    /// </summary>
    class SHA1
    {
        //variables
        private static string[] keys = new string[4];
        private static string[] W = new string[80];


        private static void setKeys()
        {
            int[] i = { 2, 3, 5, 10 };
            int index = 0;

            foreach (int item in i)
            {
                long num = (long)(Math.Pow(2, 30) * Math.Pow(item, 0.5));
                string hex = Convert.ToString(num, 16);

                keys[index++] = Convert.ToString(Convert.ToInt64(hex, 16), 2).PadLeft(32, '0');

            }
        }

        private static string keyRound(int round)
        {

            if (round >= 0 && round <= 19)
            {
                return keys[0];
            }
            else if (round >= 20 && round <= 39)
            {
                return keys[1];
            }
            else if (round >= 40 && round <= 59)
            {
                return keys[2];
            }
            else if (round >= 60 && round <= 79)
            {
                return keys[3];
            }
            else
            {
                return "";
            }


        }

        private static string function(int round, string B, string C, string D)
        {
            string result = "";

            if (round >= 0 && round <= 19)
            {
                result = OR(AND(B, C), AND(NOT(B), D));
            }
            else if (round >= 20 && round <= 39)
            {
                result = XOR(XOR(B, C), D);
            }
            else if (round >= 40 && round <= 59)
            {
                string BandC = AND(B, C);
                string BandD = AND(B, D);
                string CandD = AND(C, D);
                result = OR(OR(BandC, BandD), CandD);
            }
            else
            {
                result = XOR(XOR(B, C), D);
            }

            return result;


        }

        private static void preProcess(string toProcess)
        {

            //empty W
            for (int i = 0; i < 80; ++i)
            {
                W[i] = "";
            }

            //break up the 512 into 32bit chunks
            for (int i = 0; i < 16; ++i)
            {
                W[i] = toProcess.Substring(i * 32, 32);
            }

            for (int i = 16; i < 80; ++i)
            {
                string half1 = XOR(W[i - 16], W[i - 14]);
                string half2 = XOR(W[i - 8], W[i - 3]);
                W[i] = leftShift(XOR(half1, half2), 1);
            }
        }

        public static string hashString(string input)
        {
            setKeys();

            //convert message into binay
            string messageBit = "";
            foreach (char ch in input)
            {
                string charBitStr = Convert.ToString((int)ch, 2);

                //make sure that it is a byte that comes out
                while (charBitStr.Length < 8)
                {
                    charBitStr = '0' + charBitStr;
                }

                messageBit += charBitStr;
            }
            int originalBitLength = messageBit.Length;

            //pad to a multiple of 512
            int toPad = messageBit.Length % 512;
            toPad = 512 - toPad - 65;
            //add the one
            messageBit += '1';

            //add the correct number of 0's
            messageBit = messageBit.PadRight(messageBit.Length + toPad, '0');

            //add 64bits of message lenght
            string size64 = Convert.ToString(originalBitLength, 2);

            toPad = size64.Length % 64;
            toPad = 64 - toPad;
            size64 = size64.PadLeft(64, '0');

            messageBit += size64;

            //predefine the registers
            string A = "01100111010001010010001100000001";
            string B = "11101111110011011010101110001001";
            string C = "10011000101110101101110011111110";
            string D = "00010000001100100101010001110110";
            string E = "11000011110100101110000111110000";

            string A2 = "";
            string B2 = "";
            string C2 = "";
            string D2 = "";
            string E2 = "";

            string tempA = "";
            string tempB = "";
            string tempC = "";
            string tempD = "";
            string tempE = "";


            for (int i = 0; i < messageBit.Length / 512; ++i)
            {

                //preprocess make the W
                preProcess(messageBit.Substring(i * 512, 512));

                A2 = A;
                B2 = B;
                C2 = C;
                D2 = D;
                E2 = E;

                //the 80 rounds
                for (int j = 0; j < 80; ++j)
                {
                    tempA = ADD(E, leftShift(A, 5), W[j], keyRound(j), function(j, B, C, D));
                    tempB = A;
                    tempC = leftShift(B, 30);
                    tempD = C;
                    tempE = D;

                    A = tempA.Substring(tempA.Length - 32, 32);
                    B = tempB;
                    C = tempC;
                    D = tempD;
                    E = tempE;
                }

                A = ADD(A, A2);
                B = ADD(B, B2);
                C = ADD(C, C2);
                D = ADD(D, D2);
                E = ADD(E, E2);
            }


            string finalBinary = A + B + C + D + E;

            string finalHex = "";
            for (int j = 0; j < 40; ++j)
            {
                finalHex += Convert.ToInt64(finalBinary.Substring(j * 4, 4), 2).ToString("X");
            }

            return finalHex;
        }

        #region bitwise_functions


        private static string ADD(string A, string B, string C, string D, string E)
        {
            long intA = Convert.ToInt64(A, 2);
            long intB = Convert.ToInt64(B, 2);
            long intC = Convert.ToInt64(C, 2);
            long intD = Convert.ToInt64(D, 2);
            long intE = Convert.ToInt64(E, 2);

            long num = intA + intB + intC + intD + intE;

            string result = Convert.ToString(num, 2);

            //make sure we return a minimum of 32 bit string
            while (result.Length < 32)
            {
                result = '0' + result;
            }

            //truncate if it is over 32 bits
            if (result.Length > 32)
            {
                result = result.Substring(result.Length - 32, 32);
            }

            return result;

        }

        private static string ADD(string A, string B)
        {
            long intA = Convert.ToInt64(A, 2);
            long intB = Convert.ToInt64(B, 2);

            long num = intA + intB;

            string result = Convert.ToString(num, 2);

            //make sure we return a minimum of 32 bit string
            while (result.Length < 32)
            {
                result = '0' + result;
            }

            //truncate if it is over 32 bits
            if (result.Length > 32)
            {
                result = result.Substring(result.Length - 32, 32);
            }



            return result;

        }

        private static string XOR(string A, string B)
        {
            string result = "";
            for (int i = 0; i < A.Length; ++i)
            {
                result += A[i] ^ B[i];
            }

            return result;
        }

        private static string AND(string A, string B)
        {
            string result = "";
            for (int i = 0; i < A.Length; ++i)
            {
                if (A[i] == B[i])
                {
                    result += A[i];
                }
                else
                {
                    result += "0";
                }
            }

            return result;
        }

        private static string OR(string A, string B)
        {
            string result = "";
            for (int i = 0; i < A.Length; ++i)
            {
                if (A[i] == '1' || B[i] == '1')
                {
                    result += '1';
                }
                else
                {
                    result += '0';
                }
            }

            return result;
        }

        private static string NOT(string A)
        {
            string result = "";
            for (int i = 0; i < A.Length; ++i)
            {
                if (A[i] == '1')
                {
                    result += '0';
                }
                else
                {
                    result += '1';
                }

            }

            return result;
        }

        private static string leftShift(string input, int amount)
        {

            return input.Substring(amount, input.Length - amount) + input.Substring(0, amount);
        }

        #endregion
    }
}
