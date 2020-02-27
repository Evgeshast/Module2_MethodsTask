using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task2
{
    public class FileIterator : IEnumerable<string>
    {
        private List<string> _files;
       
        public FileIterator(List<string> files)
        {
            _files = files;
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (var item in _files)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
