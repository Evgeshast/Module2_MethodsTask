using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace FileVisitorTests
{
    [TestClass]
    public class FileSystemVisitorTests
    {
        [TestMethod]
        public void JPGFileExtension()
        {
            string filter = ".jpg";
            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(x => x.EndsWith(filter));
            IEnumerable<string> files = fileSystemVisitor.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            Assert.AreNotEqual(files.ToList().Count, 0);
        }
        
        [TestMethod]
        public void WrongFileExtension()
        {
            string filter = ".123";
            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(x => x.EndsWith(filter));
            IEnumerable<string> files = fileSystemVisitor.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            Assert.AreEqual(files.ToList().Count, 0);
        }
    }
}
