using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SzyfrDeszyfr
{
    public class Cypher
    {
        public static string[,] sbox = {
            {"63", "7c", "77", "7b", "f2", "6b", "6f", "c5", "30", "01","67","2b","fe", "d7"  , "ab"  , "76"},
            {"ca", "82", "c9", "7d",  "fa",  "59",  "47",  "f0",  "ad",  "d4",  "a2",  "af",  "9c",  "a4",  "72",  "c0"},
            {"b7", "fd",  "93",  "26",  "36",  "3f",  "f7",  "cc",  "34",  "a5",  "e5",  "f1",  "71",  "d8",  "31",  "15" },
            {"04", "c7",  "23",  "c3",  "18",  "96",  "05",  "9a",  "07",  "12",  "80",  "e2",  "eb",  "27",  "b2",  "75"},
            {"09", "83",  "2c",  "1a",  "1b",  "6e",  "5a",  "a0",  "52",  "3b",  "d6",  "b3",  "29",  "e3",  "2f",  "84" },
            {"53", "d1",  "00",  "ed",  "20",  "fc",  "b1",  "5b",  "6a",  "cb",  "be",  "39",  "4a",  "4c",  "58",  "cf" },
            {"d0", "ef",  "aa",  "fb",  "43",  "4d",  "33",  "85",  "45",  "f9",  "02",  "7f",  "50",  "3c",  "9f",  "a8" },
            {"51",  "a3",  "40",  "8f",  "92",  "9d",  "38",  "f5",  "bc",  "b6",  "da",  "21",  "10",  "ff",  "f3",  "d2" },
            {"cd", "0c",  "13",  "ec",  "5f",  "97",  "44",  "17",  "c4",  "a7",  "7e",  "3d",  "64",  "5d",  "19", "73" },
            {"60", "81",  "4f",  "dc",  "22",  "2a",  "90",  "88",  "46",  "ee",  "b8",  "14",  "de",  "5e",  "0b",  "db" },
            {"e0", "32",  "3a",  "0a",  "49",  "06",  "24",  "5c",  "c2",  "d3",  "ac",  "62",  "91",  "95",  "e4",  "79" },
            {"e7", "c8",  "37",  "6d",  "8d",  "d5",  "4e",  "a9",  "6c",  "56",  "f4",  "ea",  "65",  "7a",  "ae",  "08" },
            {"ba", "78",  "25",  "2e",  "1c",  "a6",  "b4",  "c6",  "e8" , "dd" , "74" , "1f" , "4b" , "bd" , "8b",  "8a" },
            {"70", "3e",  "b5",  "66",  "48",  "03",  "f6",  "0e" , "61" , "35" , "57" , "b9" , "86" , "c1" , "1d" , "9e" },
            {"e1", "f8",  "98",  "11",  "69",  "d9",  "8e",  "94" , "9b" , "1e" , "87" , "e9" , "ce" , "55" , "28" , "df" },
            {"8c", "a1",  "89",  "0d" , "bf",  "e6",  "42" , "68"  ,"41" , "99"  ,"2d" , "0f" , "b0" , "54"  ,"bb" , "16" }
            };

        public static string[,] invSbox =
        {
            { "52" , "09" , "6a" , "d5" , "30" , "36" , "a5" , "38" , "bf" , "40" , "a3" , "9e" , "81" , "f3" , "d7" , "fb" },
  {"7c" , "e3" , "39" , "82" , "9b" , "2f" , "ff",  "87" , "34" , "8e" , "43" , "44" , "c4" , "de" , "e9" , "cb"},
  {"54" , "7b",  "94" , "32" , "a6" , "c2" , "23" , "3d" , "ee" , "4c"  ,"95" , "0b" , "42" , "fa" , "c3" , "4e"},
  {"08" , "2e" , "a1" , "66" , "28" , "d9" , "24",  "b2" , "76" , "5b" , "a2" , "49" , "6d" , "8b" , "d1" , "25"},
  {"72" , "f8" , "f6" , "64" , "86" , "68" , "98" , "16" , "d4" , "a4" , "5c" , "cc" , "5d" , "65" , "b6" , "92"},
  {"6c" , "70" , "48" , "50" , "fd" , "ed" , "b9" , "da" , "5e" , "15" , "46" , "57" , "a7" , "8d" , "9d" , "84"},
  {"90" , "d8" , "ab"  ,"00" , "8c" , "bc" , "d3" , "0a" , "f7" , "e4" , "58" , "05" , "b8" , "b3" , "45" , "06"},
  {"d0" , "2c" , "1e" , "8f" , "ca" , "3f" , "0f" , "02" , "c1" , "af" , "bd" , "03" , "01" , "13" , "8a" , "6b"},
  {"3a" , "91" , "11" , "41" , "4f" , "67" , "dc" , "ea" , "97" , "f2"  ,"cf"  ,"ce" , "f0" , "b4" , "e6" , "73"},
  {"96",  "ac" , "74" , "22" , "e7" , "ad"  ,"35",  "85" , "e2" , "f9" , "37" , "e8" , "1c" , "75" , "df" , "6e"},
  {"47" , "f1" , "1a" , "71" , "1d" , "29" , "c5",  "89"  ,"6f",  "b7"  ,"62",  "0e"  ,"aa",  "18"  ,"be",  "1b"},
  {"fc" , "56" , "3e" , "4b" , "c6",  "d2" , "79" , "20" , "9a" , "db" , "c0" , "fe" , "78" , "cd" , "5a" , "f4"},
  {"1f"  ,"dd" , "a8"  ,"33",  "88" , "07" , "c7"  ,"31",  "b1"  ,"12",  "10" , "59",  "27"  ,"80",  "ec"  ,"5f"},
  {"60"  ,"51"  ,"7f" , "a9",  "19"  ,"b5"  ,"4a",  "0d"  ,"2d",  "e5"  ,"7a" , "9f"  ,"93",  "c9"  ,"9c",  "ef"},
  {"a0" , "e0" , "3b" , "4d" , "ae" , "2a" , "f5" , "b0" , "c8" , "eb" , "bb",  "3c" , "83" , "53" , "99" ,"61"},
  {"17" , "2b",  "04" , "7e" , "ba" , "77",  "d6" , "26",  "e1"  ,"69",  "14" , "63",  "55"  ,"21",  "0c"  ,"7d"}
        };

        public static string[,] mul2;
        int[] preMul2 =
        {
            0x00,0x02,0x04,0x06,0x08,0x0a,0x0c,0x0e,0x10,0x12,0x14,0x16,0x18,0x1a,0x1c,0x1e ,
0x20,0x22,0x24,0x26,0x28,0x2a,0x2c,0x2e,0x30,0x32,0x34,0x36,0x38,0x3a,0x3c,0x3e,
0x40,0x42,0x44,0x46,0x48,0x4a,0x4c,0x4e,0x50,0x52,0x54,0x56,0x58,0x5a,0x5c,0x5e,
0x60,0x62,0x64,0x66,0x68,0x6a,0x6c,0x6e,0x70,0x72,0x74,0x76,0x78,0x7a,0x7c,0x7e,
0x80,0x82,0x84,0x86,0x88,0x8a,0x8c,0x8e,0x90,0x92,0x94,0x96,0x98,0x9a,0x9c,0x9e,
0xa0,0xa2,0xa4,0xa6,0xa8,0xaa,0xac,0xae,0xb0,0xb2,0xb4,0xb6,0xb8,0xba,0xbc,0xbe,
0xc0,0xc2,0xc4,0xc6,0xc8,0xca,0xcc,0xce,0xd0,0xd2,0xd4,0xd6,0xd8,0xda,0xdc,0xde,
0xe0,0xe2,0xe4,0xe6,0xe8,0xea,0xec,0xee,0xf0,0xf2,0xf4,0xf6,0xf8,0xfa,0xfc,0xfe,
0x1b,0x19,0x1f,0x1d,0x13,0x11,0x17,0x15,0x0b,0x09,0x0f,0x0d,0x03,0x01,0x07,0x05,
0x3b,0x39,0x3f,0x3d,0x33,0x31,0x37,0x35,0x2b,0x29,0x2f,0x2d,0x23,0x21,0x27,0x25,
0x5b,0x59,0x5f,0x5d,0x53,0x51,0x57,0x55,0x4b,0x49,0x4f,0x4d,0x43,0x41,0x47,0x45,
0x7b,0x79,0x7f,0x7d,0x73,0x71,0x77,0x75,0x6b,0x69,0x6f,0x6d,0x63,0x61,0x67,0x65,
0x9b,0x99,0x9f,0x9d,0x93,0x91,0x97,0x95,0x8b,0x89,0x8f,0x8d,0x83,0x81,0x87,0x85,
0xbb,0xb9,0xbf,0xbd,0xb3,0xb1,0xb7,0xb5,0xab,0xa9,0xaf,0xad,0xa3,0xa1,0xa7,0xa5,
0xdb,0xd9,0xdf,0xdd,0xd3,0xd1,0xd7,0xd5,0xcb,0xc9,0xcf,0xcd,0xc3,0xc1,0xc7,0xc5,
0xfb,0xf9,0xff,0xfd,0xf3,0xf1,0xf7,0xf5,0xeb,0xe9,0xef,0xed,0xe3,0xe1,0xe7,0xe5
        };

        public static string[,] mul3;
        int[] preMul3 =
        {
            0x00,0x03,0x06,0x05,0x0c,0x0f,0x0a,0x09,0x18,0x1b,0x1e,0x1d,0x14,0x17,0x12,0x11 ,
0x30,0x33,0x36,0x35,0x3c,0x3f,0x3a,0x39,0x28,0x2b,0x2e,0x2d,0x24,0x27,0x22,0x21,
0x60,0x63,0x66,0x65,0x6c,0x6f,0x6a,0x69,0x78,0x7b,0x7e,0x7d,0x74,0x77,0x72,0x71,
0x50,0x53,0x56,0x55,0x5c,0x5f,0x5a,0x59,0x48,0x4b,0x4e,0x4d,0x44,0x47,0x42,0x41,
0xc0,0xc3,0xc6,0xc5,0xcc,0xcf,0xca,0xc9,0xd8,0xdb,0xde,0xdd,0xd4,0xd7,0xd2,0xd1,
0xf0,0xf3,0xf6,0xf5,0xfc,0xff,0xfa,0xf9,0xe8,0xeb,0xee,0xed,0xe4,0xe7,0xe2,0xe1,
0xa0,0xa3,0xa6,0xa5,0xac,0xaf,0xaa,0xa9,0xb8,0xbb,0xbe,0xbd,0xb4,0xb7,0xb2,0xb1,
0x90,0x93,0x96,0x95,0x9c,0x9f,0x9a,0x99,0x88,0x8b,0x8e,0x8d,0x84,0x87,0x82,0x81,
0x9b,0x98,0x9d,0x9e,0x97,0x94,0x91,0x92,0x83,0x80,0x85,0x86,0x8f,0x8c,0x89,0x8a,
0xab,0xa8,0xad,0xae,0xa7,0xa4,0xa1,0xa2,0xb3,0xb0,0xb5,0xb6,0xbf,0xbc,0xb9,0xba,
0xfb,0xf8,0xfd,0xfe,0xf7,0xf4,0xf1,0xf2,0xe3,0xe0,0xe5,0xe6,0xef,0xec,0xe9,0xea,
0xcb,0xc8,0xcd,0xce,0xc7,0xc4,0xc1,0xc2,0xd3,0xd0,0xd5,0xd6,0xdf,0xdc,0xd9,0xda,
0x5b,0x58,0x5d,0x5e,0x57,0x54,0x51,0x52,0x43,0x40,0x45,0x46,0x4f,0x4c,0x49,0x4a,
0x6b,0x68,0x6d,0x6e,0x67,0x64,0x61,0x62,0x73,0x70,0x75,0x76,0x7f,0x7c,0x79,0x7a,
0x3b,0x38,0x3d,0x3e,0x37,0x34,0x31,0x32,0x23,0x20,0x25,0x26,0x2f,0x2c,0x29,0x2a,
0x0b,0x08,0x0d,0x0e,0x07,0x04,0x01,0x02,0x13,0x10,0x15,0x16,0x1f,0x1c,0x19,0x1a
        };

        public static string[,] mul9;
        int[] preMul9 = { 0x00,0x09,0x12,0x1b,0x24,0x2d,0x36,0x3f,0x48,0x41,0x5a,0x53,0x6c,0x65,0x7e,0x77,
0x90,0x99,0x82,0x8b,0xb4,0xbd,0xa6,0xaf,0xd8,0xd1,0xca,0xc3,0xfc,0xf5,0xee,0xe7,
0x3b,0x32,0x29,0x20,0x1f,0x16,0x0d,0x04,0x73,0x7a,0x61,0x68,0x57,0x5e,0x45,0x4c,
0xab,0xa2,0xb9,0xb0,0x8f,0x86,0x9d,0x94,0xe3,0xea,0xf1,0xf8,0xc7,0xce,0xd5,0xdc,
0x76,0x7f,0x64,0x6d,0x52,0x5b,0x40,0x49,0x3e,0x37,0x2c,0x25,0x1a,0x13,0x08,0x01,
0xe6,0xef,0xf4,0xfd,0xc2,0xcb,0xd0,0xd9,0xae,0xa7,0xbc,0xb5,0x8a,0x83,0x98,0x91,
0x4d,0x44,0x5f,0x56,0x69,0x60,0x7b,0x72,0x05,0x0c,0x17,0x1e,0x21,0x28,0x33,0x3a,
0xdd,0xd4,0xcf,0xc6,0xf9,0xf0,0xeb,0xe2,0x95,0x9c,0x87,0x8e,0xb1,0xb8,0xa3,0xaa,
0xec,0xe5,0xfe,0xf7,0xc8,0xc1,0xda,0xd3,0xa4,0xad,0xb6,0xbf,0x80,0x89,0x92,0x9b,
0x7c,0x75,0x6e,0x67,0x58,0x51,0x4a,0x43,0x34,0x3d,0x26,0x2f,0x10,0x19,0x02,0x0b,
0xd7,0xde,0xc5,0xcc,0xf3,0xfa,0xe1,0xe8,0x9f,0x96,0x8d,0x84,0xbb,0xb2,0xa9,0xa0,
0x47,0x4e,0x55,0x5c,0x63,0x6a,0x71,0x78,0x0f,0x06,0x1d,0x14,0x2b,0x22,0x39,0x30,
0x9a,0x93,0x88,0x81,0xbe,0xb7,0xac,0xa5,0xd2,0xdb,0xc0,0xc9,0xf6,0xff,0xe4,0xed,
0x0a,0x03,0x18,0x11,0x2e,0x27,0x3c,0x35,0x42,0x4b,0x50,0x59,0x66,0x6f,0x74,0x7d,
0xa1,0xa8,0xb3,0xba,0x85,0x8c,0x97,0x9e,0xe9,0xe0,0xfb,0xf2,0xcd,0xc4,0xdf,0xd6,
0x31,0x38,0x23,0x2a,0x15,0x1c,0x07,0x0e,0x79,0x70,0x6b,0x62,0x5d,0x54,0x4f,0x46 };

        public static string[,] mul11;
        int[] preMul11 = { 0x00,0x0b,0x16,0x1d,0x2c,0x27,0x3a,0x31,0x58,0x53,0x4e,0x45,0x74,0x7f,0x62,0x69,
0xb0,0xbb,0xa6,0xad,0x9c,0x97,0x8a,0x81,0xe8,0xe3,0xfe,0xf5,0xc4,0xcf,0xd2,0xd9,
0x7b,0x70,0x6d,0x66,0x57,0x5c,0x41,0x4a,0x23,0x28,0x35,0x3e,0x0f,0x04,0x19,0x12,
0xcb,0xc0,0xdd,0xd6,0xe7,0xec,0xf1,0xfa,0x93,0x98,0x85,0x8e,0xbf,0xb4,0xa9,0xa2,
0xf6,0xfd,0xe0,0xeb,0xda,0xd1,0xcc,0xc7,0xae,0xa5,0xb8,0xb3,0x82,0x89,0x94,0x9f,
0x46,0x4d,0x50,0x5b,0x6a,0x61,0x7c,0x77,0x1e,0x15,0x08,0x03,0x32,0x39,0x24,0x2f,
0x8d,0x86,0x9b,0x90,0xa1,0xaa,0xb7,0xbc,0xd5,0xde,0xc3,0xc8,0xf9,0xf2,0xef,0xe4,
0x3d,0x36,0x2b,0x20,0x11,0x1a,0x07,0x0c,0x65,0x6e,0x73,0x78,0x49,0x42,0x5f,0x54,
0xf7,0xfc,0xe1,0xea,0xdb,0xd0,0xcd,0xc6,0xaf,0xa4,0xb9,0xb2,0x83,0x88,0x95,0x9e,
0x47,0x4c,0x51,0x5a,0x6b,0x60,0x7d,0x76,0x1f,0x14,0x09,0x02,0x33,0x38,0x25,0x2e,
0x8c,0x87,0x9a,0x91,0xa0,0xab,0xb6,0xbd,0xd4,0xdf,0xc2,0xc9,0xf8,0xf3,0xee,0xe5,
0x3c,0x37,0x2a,0x21,0x10,0x1b,0x06,0x0d,0x64,0x6f,0x72,0x79,0x48,0x43,0x5e,0x55,
0x01,0x0a,0x17,0x1c,0x2d,0x26,0x3b,0x30,0x59,0x52,0x4f,0x44,0x75,0x7e,0x63,0x68,
0xb1,0xba,0xa7,0xac,0x9d,0x96,0x8b,0x80,0xe9,0xe2,0xff,0xf4,0xc5,0xce,0xd3,0xd8,
0x7a,0x71,0x6c,0x67,0x56,0x5d,0x40,0x4b,0x22,0x29,0x34,0x3f,0x0e,0x05,0x18,0x13,
0xca,0xc1,0xdc,0xd7,0xe6,0xed,0xf0,0xfb,0x92,0x99,0x84,0x8f,0xbe,0xb5,0xa8,0xa3 };

        public static string[,] mul13;
        int[] preMul13 = { 0x00,0x0d,0x1a,0x17,0x34,0x39,0x2e,0x23,0x68,0x65,0x72,0x7f,0x5c,0x51,0x46,0x4b,
0xd0,0xdd,0xca,0xc7,0xe4,0xe9,0xfe,0xf3,0xb8,0xb5,0xa2,0xaf,0x8c,0x81,0x96,0x9b,
0xbb,0xb6,0xa1,0xac,0x8f,0x82,0x95,0x98,0xd3,0xde,0xc9,0xc4,0xe7,0xea,0xfd,0xf0,
0x6b,0x66,0x71,0x7c,0x5f,0x52,0x45,0x48,0x03,0x0e,0x19,0x14,0x37,0x3a,0x2d,0x20,
0x6d,0x60,0x77,0x7a,0x59,0x54,0x43,0x4e,0x05,0x08,0x1f,0x12,0x31,0x3c,0x2b,0x26,
0xbd,0xb0,0xa7,0xaa,0x89,0x84,0x93,0x9e,0xd5,0xd8,0xcf,0xc2,0xe1,0xec,0xfb,0xf6,
0xd6,0xdb,0xcc,0xc1,0xe2,0xef,0xf8,0xf5,0xbe,0xb3,0xa4,0xa9,0x8a,0x87,0x90,0x9d,
0x06,0x0b,0x1c,0x11,0x32,0x3f,0x28,0x25,0x6e,0x63,0x74,0x79,0x5a,0x57,0x40,0x4d,
0xda,0xd7,0xc0,0xcd,0xee,0xe3,0xf4,0xf9,0xb2,0xbf,0xa8,0xa5,0x86,0x8b,0x9c,0x91,
0x0a,0x07,0x10,0x1d,0x3e,0x33,0x24,0x29,0x62,0x6f,0x78,0x75,0x56,0x5b,0x4c,0x41,
0x61,0x6c,0x7b,0x76,0x55,0x58,0x4f,0x42,0x09,0x04,0x13,0x1e,0x3d,0x30,0x27,0x2a,
0xb1,0xbc,0xab,0xa6,0x85,0x88,0x9f,0x92,0xd9,0xd4,0xc3,0xce,0xed,0xe0,0xf7,0xfa,
0xb7,0xba,0xad,0xa0,0x83,0x8e,0x99,0x94,0xdf,0xd2,0xc5,0xc8,0xeb,0xe6,0xf1,0xfc,
0x67,0x6a,0x7d,0x70,0x53,0x5e,0x49,0x44,0x0f,0x02,0x15,0x18,0x3b,0x36,0x21,0x2c,
0x0c,0x01,0x16,0x1b,0x38,0x35,0x22,0x2f,0x64,0x69,0x7e,0x73,0x50,0x5d,0x4a,0x47,
0xdc,0xd1,0xc6,0xcb,0xe8,0xe5,0xf2,0xff,0xb4,0xb9,0xae,0xa3,0x80,0x8d,0x9a,0x97 };

        public static string[,] mul14;
        int[] preMul14 = { 0x00,0x0e,0x1c,0x12,0x38,0x36,0x24,0x2a,0x70,0x7e,0x6c,0x62,0x48,0x46,0x54,0x5a,
0xe0,0xee,0xfc,0xf2,0xd8,0xd6,0xc4,0xca,0x90,0x9e,0x8c,0x82,0xa8,0xa6,0xb4,0xba,
0xdb,0xd5,0xc7,0xc9,0xe3,0xed,0xff,0xf1,0xab,0xa5,0xb7,0xb9,0x93,0x9d,0x8f,0x81,
0x3b,0x35,0x27,0x29,0x03,0x0d,0x1f,0x11,0x4b,0x45,0x57,0x59,0x73,0x7d,0x6f,0x61,
0xad,0xa3,0xb1,0xbf,0x95,0x9b,0x89,0x87,0xdd,0xd3,0xc1,0xcf,0xe5,0xeb,0xf9,0xf7,
0x4d,0x43,0x51,0x5f,0x75,0x7b,0x69,0x67,0x3d,0x33,0x21,0x2f,0x05,0x0b,0x19,0x17,
0x76,0x78,0x6a,0x64,0x4e,0x40,0x52,0x5c,0x06,0x08,0x1a,0x14,0x3e,0x30,0x22,0x2c,
0x96,0x98,0x8a,0x84,0xae,0xa0,0xb2,0xbc,0xe6,0xe8,0xfa,0xf4,0xde,0xd0,0xc2,0xcc,
0x41,0x4f,0x5d,0x53,0x79,0x77,0x65,0x6b,0x31,0x3f,0x2d,0x23,0x09,0x07,0x15,0x1b,
0xa1,0xaf,0xbd,0xb3,0x99,0x97,0x85,0x8b,0xd1,0xdf,0xcd,0xc3,0xe9,0xe7,0xf5,0xfb,
0x9a,0x94,0x86,0x88,0xa2,0xac,0xbe,0xb0,0xea,0xe4,0xf6,0xf8,0xd2,0xdc,0xce,0xc0,
0x7a,0x74,0x66,0x68,0x42,0x4c,0x5e,0x50,0x0a,0x04,0x16,0x18,0x32,0x3c,0x2e,0x20,
0xec,0xe2,0xf0,0xfe,0xd4,0xda,0xc8,0xc6,0x9c,0x92,0x80,0x8e,0xa4,0xaa,0xb8,0xb6,
0x0c,0x02,0x10,0x1e,0x34,0x3a,0x28,0x26,0x7c,0x72,0x60,0x6e,0x44,0x4a,0x58,0x56,
0x37,0x39,0x2b,0x25,0x0f,0x01,0x13,0x1d,0x47,0x49,0x5b,0x55,0x7f,0x71,0x63,0x6d,
0xd7,0xd9,0xcb,0xc5,0xef,0xe1,0xf3,0xfd,0xa7,0xa9,0xbb,0xb5,0x9f,0x91,0x83,0x8d };

        public static char[,] xor =
        {
   { '0',   '1',   '2',   '3',   '4',   '5',   '6',   '7',   '8',   '9',   'A',   'B',   'C',   'D',   'E',   'F' },
   { '1',  '0',   '3',   '2',   '5',   '4',   '7',   '6',   '9',   '8',   'B',   'A',   'D',  'C',   'F',   'E' },
   {'2',   '3',   '0',   '1',   '6',   '7',   '4',   '5',   'A',   'B',   '8',   '9',   'E',   'F',   'C',   'D'},
   {'3',   '2',   '1',   '0',   '7',   '6',   '5',   '4',  'B',   'A',   '9',   '8',   'F',   'E',   'D',   'C'},
   {'4',   '5',   '6',   '7',   '0',   '1',   '2',   '3',   'C',   'D' ,  'E' ,  'F' ,  '8' ,  '9' ,  'A' ,  'B'},
   {'5' ,  '4' ,  '7'  , '6' ,  '1' ,  '0' ,  '3' ,  '2' ,  'D' ,  'C' ,  'F' ,  'E' ,  '9' ,  '8' , 'B' ,  'A'},
   {'6' ,  '7' ,  '4' ,  '5' ,  '2' ,  '3' ,  '0' , '1' ,  'E' ,  'F' ,  'C' ,  'D' ,  'A' ,  'B' ,  '8' ,  '9'},
   {'7' ,  '6' ,  '5' , '4' ,  '3' ,  '2' ,  '1' ,  '0' ,  'F' ,  'E' ,  'D' ,  'C' ,  'B' ,  'A'  , '9' ,  '8'},
   {'8' ,  '9' ,  'A' ,  'B' ,  'C' , 'D' ,  'E' ,  'F' ,  '0' ,  '1' , '2' ,  '3' ,  '4' ,  '5' ,  '6' ,  '7'},
   {'9' ,  '8' ,  'B' ,  'A' ,  'D' ,  'C' ,  'F' ,  'E' ,  '1' ,  '0' ,  '3' ,  '2' ,  '5' ,  '4' ,  '7' ,  '6'},
   {'A' ,  'B' ,  '8' ,  '9' ,  'E' ,  'F' ,  'C' ,  'D' ,  '2' ,  '3' ,  '0' ,  '1' ,  '6' ,  '7' ,  '4' ,  '5'},
   {'B' ,  'A' ,  '9' ,  '8' ,  'F' ,  'E' ,  'D' ,  'C' ,  '3' ,  '2' , '1' , '0' ,  '7' ,  '6' ,  '5' ,  '4'},
   {'C' ,  'D' ,  'E' , 'F' ,  '8' ,  '9' ,  'A' ,  'B' ,  '4' ,  '5' ,  '6' ,  '7' ,  '0' ,  '1' ,  '2' ,  '3'},
   {'D' ,  'C' ,  'F' ,  'E' ,  '9' ,  '8' ,  'B' ,  'A' ,  '5' ,  '4' ,  '7' ,  '6' ,  '1' ,  '0' ,  '3' ,  '2'},
   {'E' ,  'F' ,  'C' ,  'D' ,  'A' ,  'B' ,  '8' ,  '9' ,  '6' ,  '7',   '4' ,  '5' ,  '2' ,  '3' ,  '0' ,  '1'},
   {'F' ,  'E' ,  'D',   'C' ,  'B',   'A' ,  '9' ,  '8' ,  '7' ,  '6' ,  '5' ,  '4' ,  '3' ,  '2' ,  '1',   '0'}
        };

        public static string[] rcon = { "01", "02", "04", "08", "10", "20", "40", "80", "1b", "36" };

        public static string[] minisbox = { "e", "3", "4", "8", "1", "c", "a", "f", "7", "d", "9", "6", "b", "2", "0", "5" };
        public static string[] invMinisbox = { "e", "4", "d", "1", "2", "f", "b", "8", "3", "a", "6", "c", "5", "9", "0", "7" };

        public static string[] miniMul3 = { "0", "3", "6", "9", "C", "F", "2", "5", "8", "B", "E", "1", "4", "7", "A", "D" };
        public static string[] miniMul2 = { "0", "2", "4", "6", "8", "A", "C", "E", "0", "2", "4", "6", "8", "A", "C", "E" };
        public static string[] miniMul7 = { "0", "7", "E", "5", "C", "3", "A", "1", "8", "F", "6", "D", "4", "B", "2", "9" };
        public static string[] miniMul6 = { "0", "6", "C", "2", "8", "E", "4", "A", "0", "6", "C", "2", "8", "E", "4", "A" };

        public static string[,] MULlookup =
        {
            { "0" ,  "0",   "0" ,  "0"   ,"0" ,  "0" ,  "0" ,  "0" ,  "0" ,  "0" ,  "0" ,  "0" ,  "0" ,  "0" ,  "0" ,  "0" },
            { "0" ,  "1" ,  "2" ,  "3" ,  "4",   "5" ,  "6" ,  "7" ,  "8" ,  "9" ,  "A"  , "B" ,  "C" ,  "D" ,  "E"  , "F" },
            { "0" ,  "2"  , "4" ,  "6"  , "8" ,  "A",   "C",   "E" ,  "9" ,  "B" ,  "D" ,  "F" ,  "1" ,  "3",   "5" ,  "7" },
            {"0"  , "3"  , "6"   ,"5"  , "C"  , "F" ,  "A" ,  "9" ,  "1"  , "2" ,  "7"  , "4"  , "D"  , "E" ,  "B"  , "8" },
            {"0"  , "4"  , "8"  , "C"  , "9"  , "D" ,  "1" ,  "5" ,  "B"  , "F" ,  "3"  , "7"  , "2"  , "6" ,  "A"  , "E"},
            {"0"  , "5"  , "A"  , "F"  , "D"  , "8" ,  "7" ,  "2" ,  "3"  , "6" ,  "9"  , "C"  , "E"  , "B" ,  "4"  , "1"},
            {"0"  , "6"  , "C"  , "A"  , "1"  , "7" ,  "D" ,  "B" ,  "2"  , "4" ,  "E"  , "8" ,  "3"  , "5" ,  "F"  , "9"},
            {"0"  , "7"  , "E"  , "9"  , "5"  , "2" ,  "B" ,  "C" ,  "A"  , "D" ,  "4"  , "3" ,  "F"  , "8" ,  "1"  , "6"},
            {"0"  , "8"  , "9"  , "1"  , "B"  , "3" ,  "2" ,  "A" ,  "F"  , "7" ,  "6"  , "E" ,  "4"  , "C" ,  "D"  , "5"},
            {"0"  , "9"  , "B"  , "2" ,  "F"  , "6" ,  "4" ,  "D" ,  "7"  , "E" ,  "C"  , "5" ,  "8"  , "1" ,  "3"  , "A"},
            {"0"  , "A"  , "D"  , "7"  , "3"  , "9" ,  "E" ,  "4" ,  "6"  , "C" ,  "B"  , "1" ,  "5"  , "F" ,  "8"  , "2"},
            {"0"  , "B"  , "F"  , "4" ,  "7"  , "C" ,  "8" ,  "3" ,  "E"  , "5" ,  "1"  , "A" ,  "9"  , "2" ,  "6"  , "D"},
            {"0"  , "C"  , "1"  , "D" ,  "2"  , "E" ,  "3" ,  "F" ,  "4"  , "8" ,  "5"  , "9" ,  "6"  , "A" ,  "7"  , "B"},
            {"0"  , "D"  , "3"  , "E" ,  "6"  , "B" ,  "5" ,  "8" ,  "C"  , "1" ,  "F"  , "2" ,  "A"  , "7" ,  "9"  , "4"},
            {"0"  , "E"  , "5"  , "B" ,  "A"  , "4" ,  "F" ,  "1" ,  "D"  , "3" ,  "8"  , "6" ,  "7"  , "9" ,  "2"  , "C"},
            {"0"  , "F" ,  "7"  , "8" ,  "E"  , "1" ,  "9" ,  "6" ,  "5"  , "A" ,  "2"  , "D" ,  "B"  , "4" ,  "C"  , "3"}
        };
        //z modulo zostaje druga wartość. Nie, jednak nei rozumiem jak to dziala

        public HexMat[] subKeys;
        public HexMat cypherKey;

        public HexMat[] hexText;

        public void MakeHexMatsTable(string text, int matSize, int tileSize)
        {
            int hexesSize = matSize * matSize * tileSize;
            int size = text.Length / hexesSize;
            if (text.Length % hexesSize != 0)
                size += 1;

            hexText = new HexMat[size];

            for (int i = 0; i < size; i++)
            {
                string hex = "";
                for (int s = i * hexesSize; s < (i + 1) * hexesSize; s++)
                {
                    if (s < text.Length)
                    {
                        hex += text[s];
                    }
                    else
                    {
                        hex += "0";
                    }
                }

                hexText[i] = new HexMat(hex, matSize, tileSize);
            }
        }

        public string GetText()
        {
            string text = "";
            foreach (HexMat mat in hexText)
            {
                for (int x = 0; x < mat.size; x++)
                    for (int y = 0; y < mat.size; y++)
                    {
                        text += mat.hexMat[x, y];
                    }
            }

            return text;
        }

        public static string MUL(string hex, string[,] lookUp)
        {
            int x = ToInt(hex[0]);
            int y = ToInt(hex[1]);

            return lookUp[x, y];
        }

        public static string MiniMUL(string hex, string[] lookUp)
        {
            int i = ToInt(hex);
            //Console.WriteLine(i + " - > " + lookUp[i]);

            return lookUp[i];
        }

        public static string MiniXOR(string hex1, string hex2)
        {
            int x = ToInt(hex1[0]);
            int y = ToInt(hex2[0]);

            string hex = xor[x, y] + "";

            //Console.WriteLine(x + " + " + y + " = " + hex);
            return hex;
        }

        public static string MiniXOR3(string hex1, string hex2, string hex3)
        {
            return MiniXOR(MiniXOR(hex1, hex2), hex3);
        }

        public static string MiniXOR4(string hex1, string hex2, string hex3, string hex4)
        {
            return MiniXOR(MiniXOR3(hex1, hex2, hex3), hex4);
        }

        public static string XOR(string hex1, string hex2)
        {
            //Console.WriteLine(hex1 +" XOR " + hex2);

            int id10 = ToInt(hex1[0] + "");
            int id11 = ToInt(hex1[1] + "");

            int id20 = ToInt(hex2[0] + "");
            int id21 = ToInt(hex2[1] + "");

            string hex = xor[id10, id20] + "" + xor[id11, id21] + "";

            //Console.WriteLine(hex);

            return hex;
        }

        public static string XOR3(string hex1, string hex2, string hex3)
        {
            return XOR(XOR(hex1, hex2), hex3);
        }

        public static string XOR4(string hex1, string hex2, string hex3, string hex4)
        {
            return XOR(XOR3(hex1, hex2, hex3), hex4);
        }

        public void MakeMulLookUpTable(string[,] mul, int[] preMul)
        {
            //mul = new string[16, 16];

            int iterator = 0;

            for (int x = 0; x < 16; x++)
                for (int y = 0; y < 16; y++)
                {
                    mul[x, y] = ToHex(preMul[iterator++], false);
                }
        }

        public void GenerateSubKeys()
        {
            subKeys[0] = MakeSubKey(cypherKey, rcon[0]);

            for (int i = 1; i < 10; i++)
            {
                subKeys[i] = MakeSubKey(subKeys[i - 1], rcon[i]);
                subKeys[i].DebugDraw();
            }
        }

        public void GenerateMiniSubKeys()
        {
            subKeys = new HexMat[3];

            subKeys[0] = cypherKey;
            subKeys[1] = MakeMiniSubKey(subKeys[0], "1");
            subKeys[1].DebugDraw();
            subKeys[2] = MakeMiniSubKey(subKeys[1], "3");
            subKeys[2].DebugDraw();
        }

        public HexMat MakeMiniSubKey(HexMat keyBase, string rcon)
        {
            HexMat newKey = new HexMat(keyBase.size);

            string hex = Cypher.MiniSubByte(keyBase.hexMat[1, 1]);
            hex = Cypher.MiniXOR(hex, keyBase.hexMat[0, 0]);
            hex = Cypher.MiniXOR(hex, rcon);

            newKey.hexMat[0, 0] = hex;
            newKey.hexMat[1, 0] = Cypher.MiniXOR(keyBase.hexMat[1, 0], hex);
            newKey.hexMat[0, 1] = Cypher.MiniXOR(keyBase.hexMat[0, 1], newKey.hexMat[1, 0]);
            newKey.hexMat[1, 1] = Cypher.MiniXOR(keyBase.hexMat[1, 1], newKey.hexMat[0, 1]);

            return newKey;
        }

        public HexMat MakeSubKey(HexMat keyBase, string rcon)
        {
            HexMat newKey = new HexMat(keyBase.size);

            for (int y = 0; y < keyBase.size; y++)
            {
                newKey.hexMat[0, y] = keyBase.hexMat[3, y];
            }

            newKey.RotateWordOver(0);
            newKey.SubWordBytes(0);

            newKey.XORWord(0, keyBase, 0);
            newKey.hexMat[0, 0] = XOR(newKey.hexMat[0, 0], rcon);

            for (int x = 1; x < keyBase.size; x++)
            {
                for (int y = 0; y < keyBase.size; y++)
                {
                    newKey.hexMat[x, y] = keyBase.hexMat[x, y];
                }

                newKey.XORWord(x, newKey, x - 1);
            }

            return newKey;
        }

        public void MiniAESsetup(string hexText, string cypherKey)
        {
            //mul2 = new string[16, 16];
            //MakeMulLookUpTable(mul2, preMul2);

            //mul3 = new string[16, 16];
            //MakeMulLookUpTable(mul3, preMul3);

            //mul9 = new string[16, 16];
            //MakeMulLookUpTable(mul9, preMul9);

            //mul11 = new string[16, 16];
            //MakeMulLookUpTable(mul11, preMul11);

            //mul13 = new string[16, 16];
            //MakeMulLookUpTable(mul13, preMul13);

            //mul14 = new string[16, 16];
            //MakeMulLookUpTable(mul14, preMul14);

            this.cypherKey = new HexMat(cypherKey, 2, 1);

            GenerateMiniSubKeys();

            MakeHexMatsTable(hexText, 2, 1);
        }

        public void AESsetup(string hexText, string cypherKey)
        {
            mul2 = new string[16, 16];
            MakeMulLookUpTable(mul2, preMul2);

            mul3 = new string[16, 16];
            MakeMulLookUpTable(mul3, preMul3);

            mul9 = new string[16, 16];
            MakeMulLookUpTable(mul9, preMul9);

            mul11 = new string[16, 16];
            MakeMulLookUpTable(mul11, preMul11);

            mul13 = new string[16, 16];
            MakeMulLookUpTable(mul13, preMul13);

            mul14 = new string[16, 16];
            MakeMulLookUpTable(mul14, preMul14);

            this.cypherKey = new HexMat(cypherKey, 4, 2);
            subKeys = new HexMat[10];

            GenerateSubKeys();

            MakeHexMatsTable(hexText, 4, 2);
        }

        public string MiniAESEncryption(string hexText, string cypherKey)
        {
            MiniAESsetup(hexText, cypherKey);
            return MiniAESEncryption();
        }

        public string MiniAESEncryption()
        {
            for (int i = 0; i < hexText.Length; i++)
                MiniAESEncryption(hexText[i]);

            return GetText();
        }

        public void MiniAESEncryption(HexMat hexMat)
        {
            //Console.WriteLine("ENCRYPTION");
            //Console.WriteLine();
            //hexMat.DebugDraw();
            //Console.WriteLine();

            hexMat.AddMiniRoundKey(subKeys[0].hexMat);
            //hexMat.DebugDraw();
            //Console.WriteLine();

            for (int i = 1; i < 3; i++)
            {
                //Console.WriteLine("ROUND " + (i + 1));
                //Console.WriteLine();

                hexMat.MiniSubBytes();
                //hexMat.DebugDraw();
                //Console.WriteLine();

                hexMat.ShiftRows();
                // hexMat.DebugDraw();
                //Console.WriteLine();

                hexMat.MiniMixColumns();
                //hexMat.DebugDraw();
                //Console.WriteLine();

                hexMat.AddMiniRoundKey(subKeys[i].hexMat);
                //hexMat.DebugDraw();
                //Console.WriteLine();
            }
        }

        public string MiniAESDecryption(string hexText, string cypherKey)
        {
            MiniAESsetup(hexText, cypherKey);
            return MiniAESDecryption();
        }

        public string MiniAESDecryption()
        {
            for (int i = 0; i < hexText.Length; i++)
                MiniAESDecryption(hexText[i]);

            return GetText();
        }

        public void MiniAESDecryption(HexMat hexMat)
        {
            //Console.WriteLine("DECRYPTION");
            //Console.WriteLine();

            //hexMat.DebugDraw();
            //Console.WriteLine();

            for (int i = 2; i > 0; i--)
            {
                //Console.WriteLine("ROUND " + (i + 1));
                //Console.WriteLine();

                hexMat.AddMiniRoundKey(subKeys[i].hexMat);
                //hexMat.DebugDraw();
                //Console.WriteLine();

                hexMat.MiniMixColumns();
                //hexMat.DebugDraw();
                //Console.WriteLine();

                hexMat.InvShiftRows();
                //hexMat.DebugDraw();
                //Console.WriteLine();

                hexMat.InvMiniSubBytes();
                //hexMat.DebugDraw();
                //Console.WriteLine();
            }

            hexMat.AddMiniRoundKey(subKeys[0].hexMat);
            //hexMat.DebugDraw();
            //Console.WriteLine();
        }

        public string AESEncryption(string hexText, string cypherKey)
        {
            AESsetup(hexText, cypherKey);
            return AESEncryption();
        }

        public string AESEncryption()
        {
            for (int i = 0; i < hexText.Length; i++)
                AESEncryption(hexText[i]);

            return GetText();
        }

        public void AESEncryption(HexMat hexMat)
        {
            //Console.WriteLine("ENCRYPTION");
            //Console.WriteLine();

            for (int i = 0; i < 9; i++)
            {
                //Console.WriteLine("ROUND " + (i + 1));
                //Console.WriteLine();

                hexMat.SubBytes();
                //hexMat.DebugDraw();
                //Console.WriteLine();

                hexMat.ShiftRows();
                //hexMat.DebugDraw();
                //Console.WriteLine();

                hexMat.MixColumns();
                //hexMat.DebugDraw();
                //Console.WriteLine();

                hexMat.AddRoundKey(subKeys[i].hexMat);
                //hexMat.DebugDraw();
                //Console.WriteLine();
            }

            //Console.WriteLine("FINAL ROUND");
            //Console.WriteLine();

            hexMat.SubBytes();
            //hexMat.DebugDraw();
            //Console.WriteLine();

            hexMat.ShiftRows();
            //hexMat.DebugDraw();
            //Console.WriteLine();

            hexMat.AddRoundKey(subKeys[9].hexMat);
            //hexMat.DebugDraw();
            //Console.WriteLine();
        }

        public string AESDecryption(string hexText, string cypherKey)
        {
            AESsetup(hexText, cypherKey);
            return AESDecryption();
        }

        public string AESDecryption()
        {
            for (int i = 0; i < hexText.Length; i++)
                AESDecryption(hexText[i]);

            return GetText();
        }

        public void AESDecryption(HexMat hexMat)
        {
            //Console.WriteLine("DECRYPTION");
            //Console.WriteLine();

            //Console.WriteLine("FIRST ROUND");
            //Console.WriteLine();

            hexMat.AddRoundKey(subKeys[9].hexMat);
            //hexMat.DebugDraw();
            //Console.WriteLine();

            hexMat.InvShiftRows();
            //hexMat.DebugDraw();
            //Console.WriteLine();

            hexMat.InvSubBytes();
            //hexMat.DebugDraw();
            //Console.WriteLine();

            for (int i = 8; i >= 0; i--)
            {
                //Console.WriteLine("ROUND " + (10 - i));
                //Console.WriteLine();

                hexMat.AddRoundKey(subKeys[i].hexMat);
                //hexMat.DebugDraw();
                //Console.WriteLine();

                hexMat.InvMixColumns();
                //hexMat.DebugDraw();
                //Console.WriteLine();

                hexMat.InvShiftRows();
                //hexMat.DebugDraw();
                //Console.WriteLine();

                hexMat.InvSubBytes();
                // hexMat.DebugDraw();
                //Console.WriteLine();
            }
        }

        public static string MiniSubByte(string hex)
        {
            int i = ToInt(hex[0]);

            return minisbox[i];
        }

        public static string SubByte(string hex)
        {
            int x = ToInt(hex[0]);
            int y = ToInt(hex[1]);

            return sbox[x, y];
        }

        public static string InvMiniSubByte(string hex)
        {
            int i = ToInt(hex[0]);

            return invMinisbox[i];
        }

        public static string InvSubByte(string hex)
        {
            int x = ToInt(hex[0]);
            int y = ToInt(hex[1]);

            return invSbox[x, y];
        }

        public static int ToInt(char hex)
        {
            return ToInt(hex + "");
        }

        public static int ToInt(string hex)
        {
            Console.WriteLine("Hex is: " + hex);

            return Convert.ToInt32(hex, 16);
        }

        public static string ToHex(int number, bool singleChar)
        {
            string hex = number.ToString("X");
            if (!singleChar && hex.Length == 1)
                hex = "0" + hex;
            return hex;
        }
    }

    public class HexMat
    {
        public int size;
        public string[,] hexMat;

        public HexMat(HexMat hexMatBase)
        {
            size = hexMatBase.size;
            hexMat = new string[size, size];

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    hexMat[x, y] = hexMatBase.hexMat[x, y];
                }
        }

        public HexMat(string hex, int size, int tileLengh)
        {
            this.size = size;
            hexMat = new string[size, size];

            int iterator = 0;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    for (int i = 0; i < tileLengh; i++)
                    {
                        hexMat[x, y] += hex[iterator] + "";
                        iterator++;
                    }
                }
        }

        public HexMat(int size)
        {
            this.size = size;
            hexMat = new string[size, size];
        }

        public void MiniSubBytes()
        {
            //Console.WriteLine("MiniSubBytes");

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    hexMat[x, y] = Cypher.MiniSubByte(hexMat[x, y]);
                }
        }

        public void SubBytes()
        {
            //Console.WriteLine("SubBytes");

            for (int x = 0; x < size; x++)
            {
                SubWordBytes(x);
            }
        }

        public void SubWordBytes(int x)
        {
            for (int y = 0; y < size; y++)
            {
                hexMat[x, y] = Cypher.SubByte(hexMat[x, y]);
            }
        }

        public void InvMiniSubBytes()
        {
            //Console.WriteLine("MiniSubBytes");

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    hexMat[x, y] = Cypher.InvMiniSubByte(hexMat[x, y]);
                }
        }

        public void InvSubBytes()
        {
            // Console.WriteLine("InvSubBytes");

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    hexMat[x, y] = Cypher.InvSubByte(hexMat[x, y]);
                }
        }

        public void RotateByteOver(int y)
        {
            string holder = hexMat[0, y];
            for (int x = 0; x < size - 1; x++)
            {
                hexMat[x, y] = hexMat[x + 1, y];
            }

            hexMat[size - 1, y] = holder;
        }

        public void InvRotateByteOver(int y)
        {
            string holder = hexMat[size - 1, y];
            for (int x = size - 1; x > 0; x--)
            {
                hexMat[x, y] = hexMat[x - 1, y];
            }

            hexMat[0, y] = holder;
        }

        public void RotateWordOver(int x)
        {
            string holder = hexMat[x, 0];
            for (int y = 0; y < size - 1; y++)
            {
                hexMat[x, y] = hexMat[x, y + 1];
            }

            hexMat[x, size - 1] = holder;
        }

        public void ShiftRows()
        {
            //Console.WriteLine("ShiftRows");

            for (int y = 1; y < size; y++)
                for (int i = 0; i < y; i++)
                    RotateByteOver(y);
        }

        public void InvShiftRows()
        {
            //Console.WriteLine("InvShiftRows");

            for (int y = size - 1; y >= 0; y--)
                for (int i = 0; i < y; i++)
                    InvRotateByteOver(y);
        }

        public void XORWord(int x, HexMat toAdd, int toAddx)
        {
            for (int y = 0; y < size; y++)
            {
                hexMat[x, y] = Cypher.XOR(hexMat[x, y], toAdd.hexMat[toAddx, y]);
            }
        }

        public void DebugDraw()
        {
            string xLine = "";
            for (int y = 0; y < size; y++)
            {
                xLine = "";
                for (int x = 0; x < size; x++)
                {
                    xLine += " " + hexMat[x, y];
                }
                //Console.WriteLine(xLine);
            }

            //Console.WriteLine();
        }

        public int[,] ToInt()
        {
            int[,] intMat = new int[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    intMat[x, y] = Cypher.ToInt(hexMat[x, y]);
                    //Console.WriteLine(intMat[x, y]);
                }
            }

            return intMat;
        }

        public string[,] ToHex(int[,] intMat, bool singleChar)
        {
            string[,] hexMat = new string[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    hexMat[x, y] = Cypher.ToHex(intMat[x, y], singleChar);
                }
            }

            return hexMat;
        }

        public void MiniMixColumns()
        {
            // Console.WriteLine("MiniMixColumns");

            for (int x = 0; x < size; x++)
            {
                string[] tmp = new string[size];

                tmp[0] = Cypher.MiniXOR(
                    Cypher.MULlookup[Cypher.ToInt(hexMat[x, 0]), 3],
                    Cypher.MULlookup[Cypher.ToInt(hexMat[x, 1]), 2]
                    );

                tmp[1] = Cypher.MiniXOR(
                    Cypher.MULlookup[Cypher.ToInt(hexMat[x, 0]), 2],
                    Cypher.MULlookup[Cypher.ToInt(hexMat[x, 1]), 3]
                    );

                for (int y = 0; y < size; y++)
                {
                    hexMat[x, y] = tmp[y];
                }
            }
        }

        public void InvMiniMixColumns()
        {
            //Console.WriteLine("InvMiniMixColumns");

            for (int x = 0; x < size; x++)
            {
                string[] tmp = new string[size];

                tmp[0] = Cypher.MiniXOR(
                    Cypher.MiniMUL(hexMat[x, 0], Cypher.miniMul7),
                    Cypher.MiniMUL(hexMat[x, 1], Cypher.miniMul6)
                    );

                tmp[1] = Cypher.MiniXOR(
                    Cypher.MiniMUL(hexMat[x, 0], Cypher.miniMul6),
                    Cypher.MiniMUL(hexMat[x, 1], Cypher.miniMul7)
                    );

                for (int y = 0; y < size; y++)
                {
                    hexMat[x, y] = tmp[y];
                }
            }
        }

        public void MixColumns()
        {
            //int[,] intMat = ToInt();
            //Console.WriteLine("MixColumns");

            for (int x = 0; x < size; x++)
            {
                string[] tmp = new string[size];

                tmp[0] = Cypher.XOR4(
                    Cypher.MUL(hexMat[x, 0], Cypher.mul2),
                    Cypher.MUL(hexMat[x, 1], Cypher.mul3),
                    hexMat[x, 2],
                    hexMat[x, 3]);

                tmp[1] = Cypher.XOR4(
                    hexMat[x, 0],
                    Cypher.MUL(hexMat[x, 1], Cypher.mul2),
                    Cypher.MUL(hexMat[x, 2], Cypher.mul3),
                    hexMat[x, 3]);

                tmp[2] = Cypher.XOR4(
                    hexMat[x, 0],
                    hexMat[x, 1],
                    Cypher.MUL(hexMat[x, 2], Cypher.mul2),
                    Cypher.MUL(hexMat[x, 3], Cypher.mul3));

                tmp[3] = Cypher.XOR4(
                    Cypher.MUL(hexMat[x, 0], Cypher.mul3),
                    hexMat[x, 1],
                    hexMat[x, 2],
                    Cypher.MUL(hexMat[x, 3], Cypher.mul2));

                for (int y = 0; y < size; y++)
                {
                    hexMat[x, y] = tmp[y];
                }
            }

            //hexMat = ToHex(intMat);
        }

        public void InvMixColumns()
        {
            //int[,] intMat = ToInt();
            //Console.WriteLine("InvMixColumns");

            for (int x = 0; x < size; x++)
            {
                string[] tmp = new string[size];

                tmp[0] = Cypher.XOR4(
                    Cypher.MUL(hexMat[x, 0], Cypher.mul14),
                    Cypher.MUL(hexMat[x, 1], Cypher.mul11),
                    Cypher.MUL(hexMat[x, 2], Cypher.mul13),
                    Cypher.MUL(hexMat[x, 3], Cypher.mul9));

                tmp[1] = Cypher.XOR4(
                    Cypher.MUL(hexMat[x, 0], Cypher.mul9),
                    Cypher.MUL(hexMat[x, 1], Cypher.mul14),
                    Cypher.MUL(hexMat[x, 2], Cypher.mul11),
                    Cypher.MUL(hexMat[x, 3], Cypher.mul13));

                tmp[2] = Cypher.XOR4(
                    Cypher.MUL(hexMat[x, 0], Cypher.mul13),
                    Cypher.MUL(hexMat[x, 1], Cypher.mul9),
                    Cypher.MUL(hexMat[x, 2], Cypher.mul14),
                    Cypher.MUL(hexMat[x, 3], Cypher.mul11));

                tmp[3] = Cypher.XOR4(
                    Cypher.MUL(hexMat[x, 0], Cypher.mul11),
                    Cypher.MUL(hexMat[x, 1], Cypher.mul13),
                    Cypher.MUL(hexMat[x, 2], Cypher.mul9),
                    Cypher.MUL(hexMat[x, 3], Cypher.mul14));

                for (int y = 0; y < size; y++)
                {
                    hexMat[x, y] = tmp[y];
                }
            }

            //hexMat = ToHex(intMat);
        }

        public void AddRoundKey(string[,] key)
        {
            //Console.WriteLine("AddRoundKey");

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    hexMat[x, y] = Cypher.XOR(hexMat[x, y], key[x, y]);
                }
            }
        }

        public void AddMiniRoundKey(string[,] key)
        {
            //Console.WriteLine("AddRoundKey");

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    hexMat[x, y] = Cypher.MiniXOR(hexMat[x, y], key[x, y]);
                }
            }
        }


    }
}
