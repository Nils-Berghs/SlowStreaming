using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlowStreaming
{
    internal class SlowStream : Stream
    {
        private FileStream FileStream { get; }

        public override bool CanRead => FileStream.CanRead;

        public override bool CanSeek => FileStream.CanSeek;

        public override bool CanWrite => FileStream.CanWrite;

        public override long Length => FileStream.Length;

        public override long Position 
        { 
            get => FileStream.Position; 
            set => FileStream.Position = value; 
        }

        public SlowStream(string fileName)
        {
            FileStream = new FileStream(fileName, FileMode.Open);
        }

        public override void Flush()
        {
            FileStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            Console.WriteLine($"reading {count} bytes at offset {offset}, position = {Position}, length = {Length}");
            Thread.Sleep(100);
            return FileStream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return FileStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            FileStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            FileStream.Write(buffer, offset, count);
        }
    }
}
