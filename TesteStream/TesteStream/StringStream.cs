using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteStream
{
    public class StringStream : IStream
    {
        private string stream;

        private int indexOf;

        public StringStream(string stream)
        {
            this.stream = stream;
        }

        public char getNext()
        {
            return stream[indexOf++];
        }

        public bool hasNext()
        {
            return (stream.Length > indexOf);
        }
    }
}