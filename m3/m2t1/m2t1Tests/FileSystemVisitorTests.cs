using Microsoft.VisualStudio.TestTools.UnitTesting;
using m2t1;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace m2t1.Tests
{
    [TestClass()]
    public class FileSystemVisitorTests
    {
        string testPath = ".\\test";
        [TestMethod()]
        public void LoadList_AllItems_8returned()
        {
            List<Item> items = new List<Item>();
            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor();
            items = fileSystemVisitor.LoadList(testPath);
            Assert.AreEqual(8, items.Count, $"Number of returned items in {testPath} is not equal to expected");
        }

        [TestMethod()]
        public void LoadList_OnlyDirs_2Returned()
        {
            List<Item> items = new List<Item>();
            SearchParams searchParams = new SearchParams() {path = testPath, bSort = true, itype = "Directory", length = 0, name = ""};
            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor();
            items = fileSystemVisitor.LoadList(searchParams, searchParams.path);
            Assert.AreEqual(2, items.Count, $"Number of returned items in {testPath} is not equal to expected");
        }

        [TestMethod()]
        public void LoadList_OnlyFilesLengthLess290000_2Returned()
        {
            List<Item> items = new List<Item>();
            SearchParams searchParams = new SearchParams() { path = testPath, bSort = true, itype = "File", length = 290000, name = "" };
            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor();
            items = fileSystemVisitor.LoadList(searchParams, searchParams.path);
            Assert.AreEqual(3, items.Count, $"Number of returned items in {testPath} is not equal to expected");
        }

        [TestMethod()]
        public void LoadList_AllItemsNameContainsPDF_2Returned()
        {
            List<Item> items = new List<Item>();
            SearchParams searchParams = new SearchParams() { path = testPath, bSort = true, itype = "0", length = 0, name = "pdf" };
            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor();
            items = fileSystemVisitor.LoadList(searchParams, searchParams.path);
            Assert.AreEqual(3, items.Count, $"Number of returned items in {testPath} is not equal to expected");
        }
    }
}