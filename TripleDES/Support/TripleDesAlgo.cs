using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleDES.Support
{
    class TripleDesAlgo
    {
        private static int[,] s1 = new int[4, 16]  { { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 },
    { 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8 },
    { 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 },
    { 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 } };

        private static int[,] s2 = new int[4, 16] { { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 },
    { 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 },
    { 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 },
    { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 } };

        private static int[,] s3 = new int[4, 16] { { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 },
    { 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1 },
    { 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 },
    { 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 } };

        private static int[,] s4 = new int[4, 16] { { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 },
    { 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 },
    { 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 },
    { 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 } };

        private static int[,] s5 = new int[4, 16] { { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 },
    { 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6 },
    { 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 },
    { 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 } };

        private static int[,] s6 = new int[4, 16]{ { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 },
    { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 },
    { 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 },
    { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 } };

        private static int[,] s7 = new int[4, 16] { { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 },
    { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 },
    { 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 },
    { 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 } };

        private static int[,] s8 = new int[4, 16] { { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 },
    { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 },
    { 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8 },
    { 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 } };
        //for conversion
        private static string intToBinary(int a)
        {
            string outs;
            string[] binary = new string[16] { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
            outs = binary[a];
            return outs;
        }
        //for conversion
        private static int binaryToInt(string ins)
        {
            int outs = 0;
            string[] row = new string[4] { "00", "01", "10", "11" };
            string[] column = new string[16] { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
            if (ins.Length == 2)
            {
                int i = 0;
                while (row[i] != ins)
                {
                    i++;
                }
                return outs = i;
            }
            else
            {
                int j = 0;
                while (column[j] != ins)
                {
                    j++;
                }
                return outs = j;
            }
        }
        //does initial perm of message
        private static string initialPerm(string ins)
        {
            int[] xArray = { 57, 59, 61, 63, 56, 58, 60, 62 };
            string outs = null;

            foreach (int num in xArray)
            {
                int x = num;
                for (int i = 0; i < 8; i++)
                {
                    outs += ins.Substring(x, 1);
                    x = x - 8;
                }
            }            
            return outs;
        }
        //final permutation
        private static string finalPerm(string ins)
        {
            string outs = null;
            int a = 39;
            int b = 7;
            int c = 47;
            int d = 15;
            int e = 55;
            int f = 23;
            int g = 63;
            int h = 31;
            for (int i = 0; i < 8; i++)
            {
                outs += ins.Substring(a--, 1);
                outs += ins.Substring(b--, 1);
                outs += ins.Substring(c--, 1);
                outs += ins.Substring(d--, 1);
                outs += ins.Substring(e--, 1);
                outs += ins.Substring(f--, 1);
                outs += ins.Substring(g--, 1);
                outs += ins.Substring(h--, 1);
              
            }
            return outs;
        }
        //expands right side
        private static string expansionFunction(string ins)
        {
            //48bit return string
            string outs = null;
            int x = 3;
            //first 6 bits append to out
            outs += ins.Substring(31, 1);
            outs += ins.Substring(0, 5);
            
            //creates the other 6 chunks
            for (int i = 0; i < 6; i++)
            {
                outs += ins.Substring(x, 6);
                x += 4;
            }
            outs += ins.Substring(27, 5);
            outs += ins.Substring(0, 1);

            //return expansion string
            return outs;
        }
        //XOR function
        private static string xorFunction(string ins, string key)
        {
            string outs = null;
            //comapres 2 values for xor operation
            for (int i = 0; i < key.Length; i++)
            {
                char a = ins[i];
                char b = key[i];
                if (a == b)
                {
                    outs += ("0");
                }
                else
                {
                    outs += ("1");
                }
            }
            return outs;
        }
        //permutation after sBox lookup
        private static string permutation(string ins)
        {
            string outs = null;
            int[] perm = {15,6,19,20,28,11,27,16,0,14,22,25,4,17,30,9,1,7,23,13,31,26,2,8,18,12,29,5,21,10,3,24};

            foreach (int x in perm)
            {
                outs += ins.Substring(x, 1);
            }            
            return outs;
        }
        //takes right and key, send to expansionFunction, xor function,
        //  finds Sbox value, send value to perm
        private static string desFunction(string ins, string key)
        {
            //expand right side
            ins = expansionFunction(ins);
            //xor with left
            ins = xorFunction(ins, key);
            string mangler = null;
            string chunk = null;
            string[] xorArray = new string[8];
            int x = 0;
            //CHECKED
            //creates 8-6bit chuncks for sBox lookup, stores in xorArray
            for (int i = 0; i < 8; i++)
            {
                chunk += ins.Substring(x, 6);
                x += 6;
                xorArray[i] = chunk;
                chunk = null;                
            }
            //loops chunks and gets values from sBox lookup
            for (int i = 0; i < 8; i++)
            {
                string a = xorArray[i];
                string row = null;
                string column = null;
                int value = 0;
                int r = 0;
                int c = 0;
                //gets first and last bit for row
                row += a.Substring(0, 1);
                row += a.Substring(5, 1);

                r = binaryToInt(row);
                column += a.Substring(1, 4);
                c = binaryToInt(column);
                //lookup in sBox
                switch (i)
                {
                    case 0:
                        value = s1[r, c];
                        mangler += intToBinary(value);
                        break;
                    case 1:
                        value = s2[r, c];
                        mangler += intToBinary(value);
                        break;
                    case 2:
                        value = s3[r, c];
                        mangler += intToBinary(value);
                        break;
                    case 3:
                        value = s4[r, c];
                        mangler += intToBinary(value);
                        break;
                    case 4:
                        value = s5[r, c];
                        mangler += intToBinary(value);
                        break;
                    case 5:
                        value = s6[r, c];
                        mangler += intToBinary(value);
                        break;
                    case 6:
                        value = s7[r, c];
                        mangler += intToBinary(value);
                        break;
                    case 7:
                        value = s8[r, c];
                        mangler += intToBinary(value);
                        break;
                    default:
                        break;
                }
            }
            //gets permutation of mangler
            mangler = permutation(mangler);
            return mangler;
        }
        private static string keyFinalPerm(string key)
        {
            string outs = null;
            
            int[] perm = new int[48] { 13, 16, 10, 23, 0, 4, 2, 27, 14, 5, 20, 9, 22, 18, 11, 3, 25, 7, 15
		    , 6, 26, 19, 12, 1, 40, 51, 30, 36, 46, 54, 29, 39, 50, 44, 32, 47,
		    43, 48, 38, 55, 33, 52, 45, 41, 49, 35, 28, 31 };
            //uses array to find which bit to append
            for (int i = 0; i < 48; i++)
            {
                int num = perm[i];
                outs += key.Substring(num, 1);
            }
            return outs;

        }
        //initial key perm
        private static string keyInitialPerm(string key)
        {
            string outs = key;
            int x = 0;
            //split key 2 parts
            string c = null;
            string d = null;
            //sets all values for perm
            int y = 56;
            int z = 57;
            int a = 58;
            int b = 59;
            //initial permutation
            //iterates to append c and decrease varaibles
            for (int i = 0; i < 28; i++)
            {
                if (i < 8)
                {
                    c += outs.Substring(y, 1);
                    y -= 8;
                }
                if (i >= 8 && i < 16)
                {
                    c += outs.Substring(z, 1);
                    z -= 8;
                }
                if (i >= 16 && i < 24)
                {
                    c += outs.Substring(a, 1);
                    a -= 8;
                }
                if (i >= 24)
                {
                    c += outs.Substring(b, 1);
                    b -= 8;
                }
            }
            //Same as above just with d
            y = 62;
            z = 61;
            a = 60;
            b = 27;
            for (int i = 0; i < 28; i++)
            {
                if (i < 8)
                {
                    d += outs.Substring(y, 1);
                    y -= 8;
                }
                if (i >= 8 && i < 16)
                {
                    d += outs.Substring(z, 1);
                    z -= 8;
                }
                if (i >= 16 && i < 24)
                {
                    d += outs.Substring(a, 1);
                    a -= 8;
                }
                if (i >= 24)
                {
                    d += outs.Substring(b, 1);
                    b -= 8;
                }
            }            
            outs = null;
            outs = c + d;
            c = null;
            d = null;
            return outs;
        }
        //performs shifts and key perms for 16 rounds
        private static string[] keyRounds(string key_in, string[] arr)
        {
            string outs = null;
            string c = null;
            string d = null;
            string key = null;
            key = keyInitialPerm(key_in);

            c += key.Substring(0, 28);
            d += key.Substring(28, 28);
            string e = null;
            string f = null;
            //strings e & f are left shifted after inital permutation
            for (int i = 0; i < 16; i++)
            {

                if (i == 0 || i == 1 || i == 8 || i == 15)
                {
                    e += c.Substring(1, 27);
                    e += c.Substring(0, 1);
                    f += d.Substring(1, 27);
                    f += d.Substring(0, 1);
                    outs = e + f;
                    outs = keyFinalPerm(outs);
                    arr[i] = outs;
                }
                //shifts twice
                else
                {
                    e += c.Substring(2, 26);
                    e += c.Substring(0, 2);
                    f += d.Substring(2, 26);
                    f += d.Substring(0, 2);
                    outs = e + f;
                    outs = keyFinalPerm(outs);
                    arr[i] = outs;
                }
                c = e;
                d = f;
                e = null;
                f = null;
                outs = null;
            }
            return arr;
        }
        private static string encrypt(string message, string[] k)
        {
            //returns message after initialPerm	
            message = initialPerm(message);
            //split of message to right and left
            string right = null;
            string left = null;
            string function = null;
           
            left += message.Substring(0, 32);
            right += message.Substring(32, 32);

            //16 rounds of key perm and DES
            for (int i = 0; i < 16; i++)
            {
                //sends right and key to desFunction
                function = desFunction(right, k[i]);
                //left becomes old right
                string temp = left;
                left = right;
                //right becomes left xor with mangler
                right = xorFunction(temp, function);
            }
            //clear message, append right then left
            message = null;
            message = right + left;
            message = finalPerm(message);
            return message;
        }

        private static string decrypt(string message, string[] k)
        {
            //returns message after initialPerm	
            message = initialPerm(message);
            //returns key after key perm
            //split of message to right and left
            //string right, left, function;
            string right = null;
            string left = null;
            string function = null;

            right += message.Substring(0, 32);
            left += message.Substring(32, 32);          

            //16 rounds
            for (int i = 0; i < 16; i++)
            {
                //sets temp key
                string tempKey = k[15 - i];
                //create tempRight 
                string tempRight = right;
                //right becomes left
                right = left;
                //function of right and key
                function = desFunction(right, tempKey);
                //left becomes xor or right
                left = xorFunction(function, tempRight);
            }
            //clear message, append right then left
            message = null;
            message = left + right;
            message = finalPerm(message);
            return message;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">string of chars</param>
        /// <param name="key1"><binary string /param>
        /// <param name="key2">binary string</param>
        /// <returns></returns>
        public static string tdesEncrypt(string strInput, string key1, string key2)
        {
            string message = "";
            foreach (char ch in strInput)
            {
                string charBitStr = Convert.ToString((int)ch, 2);

                //make sure that it is a byte that comes out
                while (charBitStr.Length < 8)
                {
                    charBitStr = '0' + charBitStr;
                }

                message += charBitStr;
            }

            //padding with spaces
            while (message.Length % 64 != 0)
            {
                message += "00100000";

            }
            //not sure how big to make this array, holds 64 bit
            string[] outputs = new string[10];
            //64 bits of message to processes
            string input = null;
            //out string to store in array
            string outs = null;
            //both arrays with keys generated in them
            string[] k = new string[16];
            string[] k2 = new string[16];
            k = keyRounds(key1, k);
            k2 = keyRounds(key2, k2);
            //i is used for outputs array
            int i = 0;
            //strings for encrypt, decrypt, & then encrypt again
            string e1 = null;
            string d1 = null;
            string e2 = null;
            
            //breaks up large message into 64bit chunks and then store them into outs string and
            //then puts into outputs array. Each elemment holds single string
            while (message.Length != 0)
            {
                
                //input is 64 bits of message
                input = message.Substring(0, 64);
                //first 64 bits removed from message
                message = message.Substring(64);
                //first encrypt with k 
                e1 = encrypt(input, k);
                //first decrypt with k2
                d1 = decrypt(e1, k2);
                //second encrypt with k
                e2 = encrypt(d1, k);
                //appends cipher to outs string
                outs += e2;
                ////LEAVE FOR LARGE STRINGS
                //if outs string is getting to large, adds to outputs array, increases index, and clear outs
                /*if(outs.Length > 1073741700)
                {
                    outputs[i] = outs;
                    i++;
                    outs = null;
                
                }*/
            }


            return outs;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strInput">string of chars</param>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <returns></returns>
        public static string tdesDecrypt(string message, string key1, string key2)
        {
            //not sure how big to make this array, holds 64 bit
            string[] outputs = new string[10];
            //64 bits of message to processes
            string input = null;
            //out string to store in array
            string outs = null;
            //both arrays with keys generated in them
            string[] k = new string[16];
            string[] k2 = new string[16];
            k = keyRounds(key1, k);
            k2 = keyRounds(key2, k2);
            //i is used for outputs array
            int i = 0;
            //strings for decrypt, encrypt,  & then decrypt again
            string d1 = null;
            string e1 = null;
            string d2 = null;

            //breaks up large message into 64bit chunks and then store them into outs string and
            //then puts into outputs array. Each elemment holds single string
            while (message.Length != 0)
            {                
                //input is 64 bits of message
                input = message.Substring(0, 64);
                //first 64 bits removed from message
                message = message.Substring(64);
                //first decrypt with k 
                d1 = decrypt(input, k);
                //first encrypt with k2
                e1 = encrypt(d1, k2);
                //second decrypt with k
                d2 = decrypt(e1, k);
                //appends plaintext to outs string
                outs += d2;
                /////LEAVE FOR LARGE STRINGS
                //if outs string is getting to large, adds to outputs array, increases index, and clear outs
                /*if(outs.Length > 1073741700)
                {
                    outputs[i] = outs;
                    i++;
                    outs = null;
                
                }*/
            }
            //converts outs to text

            List<Byte> byteList = new List<Byte>();

            for (int j = 0; j < outs.Length; j += 8)
            {
                byteList.Add(Convert.ToByte(outs.Substring(j, 8), 2));
            }

            return Encoding.Default.GetString(byteList.ToArray());

        }
    }
}
