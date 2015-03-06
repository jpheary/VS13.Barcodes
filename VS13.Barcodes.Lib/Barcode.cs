using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS13 {
    //
    public enum Barcode128 { A = 103, B = 104, C = 105 }

    public class Barcode {
        //Members

        //Rivers Edge barcode fonts
        private const char RE_START128_A = (char)8225;		//135 8225;
        private const char RE_START128_B = (char)8226;      //136 
        private const char RE_START128_C = (char)8240;      //137 
        private const char RE_STOP128 = (char)352;			//138 352;

        //Interface
        public Barcode() { }
        public string Encode128AB(string BarCodeData, string BarCodeName, Barcode128 Subset) {
            //Encode BarCodeData for 128 barcode printing
            string sBarCode = "", sBarCodeEncoded = "";

            //Build ouput string; trailing space is for Windows rasterization bug
            BarCodeData = BarCodeData.Trim();
            sBarCodeEncoded = encode(BarCodeData, BarCodeName, Subset);
            switch (BarCodeName) {
                case "Code128A":
                    switch (Subset) {
                        case Barcode128.A: sBarCode = Char.ToString(RE_START128_A) + sBarCodeEncoded + calcChecksum(BarCodeData, Subset, 103) + Char.ToString(RE_STOP128); break;
                        case Barcode128.B: sBarCode = Char.ToString(RE_START128_B) + sBarCodeEncoded + calcChecksum(BarCodeData, Subset, 104) + Char.ToString(RE_STOP128); break;
                        case Barcode128.C: sBarCode = Char.ToString(RE_START128_C) + sBarCodeEncoded + calcChecksum(BarCodeData, Subset, 105) + Char.ToString(RE_STOP128); break;
                    }
                    break;
            }
            return sBarCode;
        }

        private string encode(string BarCodeData, string BarCodeName, Barcode128 Subset) {
            //Map ascii values to barcode ascii values
            string sBarCodeEncoded = "";

            //Output string - map the ascii set to barcode128 ascii set
            //- no spaces in TrueType fonts; quotes replaced for Word mailmerge bug
            switch (BarCodeName) {
                case "Code128A":
                    if (Subset == Barcode128.C) {
                        if (BarCodeData.Length % 2 != 0) BarCodeData = "0" + BarCodeData;
                        for (int i = 0; i < BarCodeData.Length; i += 2) {
                            int iVal = Convert.ToInt32(BarCodeData.Substring(i, 2));
                            if (iVal == 0)
                                sBarCodeEncoded += Char.ToString((char)192);
                            else if (iVal == 7)
                                sBarCodeEncoded += Char.ToString((char)193);
                            else if (iVal == 64)
                                sBarCodeEncoded += Char.ToString((char)194);
                            else if (iVal >= 95 && iVal <= 101)
                                sBarCodeEncoded += Char.ToString((char)(iVal + 100));
                            else if (iVal == 102)
                                sBarCodeEncoded += Char.ToString((char)134);
                            else
                                sBarCodeEncoded += Char.ToString((char)(iVal + 32));
                        }
                    }
                    else {
                        for (int i = 0; i < BarCodeData.Length; i++) {
                            char cChar = Convert.ToChar(BarCodeData.Substring(i, 1));
                            if (cChar == 32)						//space
                                sBarCodeEncoded += Char.ToString((char)192);
                            else if (cChar == 39)				//'
                                sBarCodeEncoded += Char.ToString((char)193);
                            else if (cChar == 96)				//`
                                sBarCodeEncoded += Char.ToString((char)194);
                            else if (cChar == 127)				//`
                                sBarCodeEncoded += Char.ToString((char)195);
                            else //if(cChar >= 33 && cChar <= 95)	//numbers, capital letters, punctuation- map direct
                                sBarCodeEncoded += Char.ToString(cChar);
                        }
                    }
                    break;
            }
            return sBarCodeEncoded;
        }
        private string calcChecksum(string BarCodeData, Barcode128 Subset, int StartValue) {
            //Calculate a checksum for BarCodeData (mod 103)
            int iValue = 0, iWeightedValue = 0, iCheckSumValue = 0;
            string sCheckSum = "";

            //Initialize weighted value with startcode value
            iWeightedValue = StartValue;
            if (Subset == Barcode128.C) {
                if (BarCodeData.Length % 2 != 0) BarCodeData = "0" + BarCodeData;
                for (int i = 0; i < BarCodeData.Length; i += 2) {
                    //Find the ASCII value of the each character; determine barcode 128 value
                    iValue = Convert.ToInt32(BarCodeData.Substring(i, 2));

                    //Sum 'weighted' values for checksum calculation
                    iWeightedValue += (((i / 2) + 1) * iValue);
                }
            }
            else {
                for (int i = 0; i < BarCodeData.Length; i++) {
                    //Find the ASCII value of the each character; determine barcode 128 value
                    char cChar = Convert.ToChar(BarCodeData.Substring(i, 1));
                    //if(cChar >= 32 && cChar <= 126)
                    iValue = cChar - 32;
                    //else
                    //    iValue = cChar - 103;

                    //Sum 'weighted' values for checksum calculation
                    iWeightedValue += ((i + 1) * iValue);
                }
            }

            //Find the remainder when sum is divided by 103
            iCheckSumValue = iWeightedValue % 103;

            //Translate checksum value to an ASCII character (since checksum is remainder
            //of division by 103, checksum value is in range 0 - 102)
            switch (iCheckSumValue) {
                case 0: sCheckSum = Char.ToString((char)192); break;
                case 7: sCheckSum = Char.ToString((char)193); break;
                case 64: sCheckSum = Char.ToString((char)194); break;
                case 95: sCheckSum = Char.ToString((char)195); break;
                case 96: sCheckSum = Char.ToString((char)196); break;
                case 97: sCheckSum = Char.ToString((char)197); break;
                case 98: sCheckSum = Char.ToString((char)198); break;
                case 99: sCheckSum = Char.ToString((char)199); break;
                case 100: sCheckSum = Char.ToString((char)200); break;
                case 101: sCheckSum = Char.ToString((char)201); break;
                default: sCheckSum = Char.ToString((char)(iCheckSumValue + 32)); break;
            }
            return sCheckSum;
        }
    }
}
