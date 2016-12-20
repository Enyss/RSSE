using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RSSE
{
    class OGLMdlReader
    {
        public List<float[]> floatArray;
        public List<float[,]> floatArray2D;
        public List<byte[,]> byteArray2D;
        public List<ushort[]> ushortArray;
        public List<Tuple<string, string>> pairOfString;


        public OGLMdlReader()
        {
            floatArray = new List<float[]>();
            floatArray2D = new List<float[,]>();
            ushortArray = new List<ushort[]>();
            byteArray2D = new List<byte[,]>();
            pairOfString = new List<Tuple<string, string>>();
        }

        public void Read(string filename)
        {
            BinaryReader b = new BinaryReader(File.Open(filename, FileMode.Open));

            // Header
            b.ReadBytes(16);

            bool stop = false;
            while (!stop && b.BaseStream.Position != b.BaseStream.Length)
            {

                int type = b.ReadInt32();
                int type2 = b.ReadInt32();
                int sectionSize = b.ReadInt32();
                int size1;
                int size2;
                switch (type)
                {
                    // An array
                    case 3:
                        floatArray.Add(ReadFloatArray(b, sectionSize / sizeof(float)));
                        break;
                    // A 2-dimensional array
                    case 5:
                        size1 = b.ReadInt32();
                        int subtype = b.ReadInt32();
                        int typesize = b.ReadInt32();
                        size2 = b.ReadInt32();
                        if (typesize == 8)
                        {
                            floatArray2D.Add(ReadFloatArray2D(b, size1, size2));
                        }
                        else if (typesize == 2)
                        {
                            byteArray2D.Add(ReadByteArray2D(b, size1, size2));
                        }
                        break;
                    case 6:
                        size1 = b.ReadInt32();
                        b.ReadInt32();
                        b.ReadInt32();
                        ushortArray.Add(ReadUInt16Array(b, size1));
                        stop = true;
                        break;
                    // A pair of string
                    case 7:
                        pairOfString.Add(ReadPairOfString(b));
                        break;
                }
            }

            b.Dispose();

        }


        #region Reading dataType 
        private ushort[] ReadUInt16Array(BinaryReader b, int size)
        {
            ushort[] array = new ushort[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = b.ReadUInt16();
            }
            return array;
        }

        private float[] ReadFloatArray(BinaryReader b, int size)
        {
            float[] array = new float[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = b.ReadSingle();
            }
            return array;
        }

        private float[,] ReadFloatArray2D(BinaryReader b, int size1, int size2)
        {
            float[,] array = new float[size1, size2];
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    array[i, j] = b.ReadSingle();
                }
            }
            return array;
        }

        private byte[,] ReadByteArray2D(BinaryReader b, int size1, int size2)
        {
            byte[,] array = new byte[size1, size2];
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    array[i, j] = b.ReadByte();
                }
            }
            return array;
        }

        private Tuple<string, string> ReadPairOfString(BinaryReader b)
        {
            b.ReadInt32();
            string prop = ReadString(b);
            string value = ReadString(b);
            return new Tuple<string, string>(prop, value);
        }

        private string ReadString(BinaryReader b)
        {
            string s = "";
            char c;
            do
            {
                c = b.ReadChar();
                s += c;
            }
            while (c != '\0');
            return s;
        }
        #endregion
    }
}
