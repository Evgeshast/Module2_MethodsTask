using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2
{
    public class FileIterator : IEnumerable<string>
    {
        private IEnumerable<string> _files;
       
        public FileIterator(IEnumerable<string> files)
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
