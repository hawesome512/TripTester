using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Table2Excel
{
    /// <summary>
    /// 不通过OLE生成excel文件的方法
    /// </summary>
    public class ExcelWriter
    {
        System.IO.FileStream writer;

        public ExcelWriter(string strPath)
        {
            writer = new System.IO.FileStream(strPath, System.IO.FileMode.OpenOrCreate);
        }

        /// <summary>
        /// 写入short数组
        /// </summary>
        /// <param name="values"></param>
        private void writeFile(short[] values)
        {
            foreach (short v in values)
            {
                byte[] b = System.BitConverter.GetBytes(v);
                writer.Write(b, 0, b.Length);
            }
        }

        /// <summary>
        /// 写文件头
        /// </summary>
        public void BeginWrite()
        {
            writeFile(new short[] { 0x809, 8, 0, 0x10, 0, 0 });
        }
        /// <summary>
        /// 写文件尾
        /// </summary>
        public void EndWrite()
        {
            writeFile(new short[] { 0xa, 0 });
            writer.Close();
        }

        /// <summary>
        /// 写一个数字到单元格x,y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="value"></param>
        public void WriteNumber(short x, short y, double value)
        {
            writeFile(new short[] { 0x203, 14, x, y, 0 });
            byte[] b = System.BitConverter.GetBytes(value);
            writer.Write(b, 0, b.Length);
        }

        /// <summary>
        /// 写一个字符到单元格x,y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="value"></param>
        public void WriteString(short x, short y, string value)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(value);
            writeFile(new short[] { 0x204, (short)(b.Length + 8), x, y, 0, (short)b.Length });
            writer.Write(b, 0, b.Length);
        }
    }
}
