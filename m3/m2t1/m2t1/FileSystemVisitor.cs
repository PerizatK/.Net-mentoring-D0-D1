using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;


namespace m2t1
{
    public class FileSystemVisitor
    {
        public List<Item> listItem;

        public delegate void FinderStateHandler(string message);
        public event FinderStateHandler OnEvent;

        public FileSystemVisitor(SearchParams searchParams) : this()
        {
            if (searchParams.bSort)
            {
                OnEvent?.Invoke("Filtered Search Started");
                listItem = LoadList(searchParams, searchParams.path);
                OnEvent?.Invoke("Filtered Search Finished");
            }
            else
            {
                OnEvent?.Invoke("Start");
                listItem = LoadList(searchParams.path);
                OnEvent?.Invoke("Finish");
            }
            ShowListItem();
        }
                
        public FileSystemVisitor()
        {
            OnEvent += ShowMessage;
        }
        public List<Item> LoadList(string path)
        {
            List<Item> tempListItem = new List<Item>();
            try
            {
                string[] sDirPathList = Directory.GetDirectories(path);

                foreach (string tempPath in sDirPathList)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(tempPath);
                    OnEvent?.Invoke($"DirectoryFinded: {directoryInfo.FullName}");
                    tempListItem.Add(new Item() { itype = "Directory", fullName = directoryInfo.FullName, name = directoryInfo.Name, length = 0, creationDateTime = directoryInfo.CreationTime });
                    tempListItem.AddRange(LoadList(tempPath));
                }

                string[] sFilePathList = Directory.GetFiles(path);

                foreach (string tempPath in sFilePathList)
                {
                    FileInfo fileInfo = new FileInfo(tempPath);
                    OnEvent?.Invoke($"FileFinded: {fileInfo.FullName}");
                    tempListItem.Add(new Item { itype = "File", fullName = fileInfo.FullName, name = fileInfo.Name, length = fileInfo.Length, creationDateTime = fileInfo.CreationTime });
                }

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tempListItem;
        }

        public List<Item> LoadList(SearchParams searchParams, string path = "")
        {
            List<Item> tempListItem = new List<Item>();
            try
            {
                string[] sDirPathList = Directory.GetDirectories(path);

                foreach (string tempPath in sDirPathList)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(tempPath);
                    if 
                      (
                        (searchParams.itype =="Directory" || searchParams.itype == "0") &&
                        (directoryInfo.Name.Contains(searchParams.name) || searchParams.name == "")
                      )
                    {
                        OnEvent?.Invoke($"FilteredDirectoryFinded: {directoryInfo.FullName}");
                        tempListItem.Add(new Item() { itype = "Directory", fullName = directoryInfo.FullName, name = directoryInfo.Name, length = 0, creationDateTime = directoryInfo.CreationTime });
                    }
                    tempListItem.AddRange(LoadList(searchParams, tempPath));
                }

                string[] sFilePathList = Directory.GetFiles(path);

                foreach (string tempPath in sFilePathList)
                {
                    FileInfo fileInfo = new FileInfo(tempPath);
                    if
                      (
                        (searchParams.itype == "File" || searchParams.itype == "0") &&
                        (fileInfo.Name.Contains(searchParams.name) || searchParams.name == "") &&
                        (fileInfo.Length <= searchParams.length || searchParams.length == 0)
                       )
                    {
                        OnEvent?.Invoke($"FilteredFileFinded: {fileInfo.FullName}");
                        tempListItem.Add(new Item { itype = "File", fullName = fileInfo.FullName, name = fileInfo.Name,length = fileInfo.Length, creationDateTime = fileInfo.CreationTime });
                    }
                }

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tempListItem;
        }

        public IEnumerable<Item> GetList()
        {
            for (int i = 0; i < listItem.Count; i++)
            {
                yield return listItem[i];
            }
        }

        public void ShowListItem()
        {
            foreach (Item item in GetList())
            {
                Console.WriteLine($"\n{item.itype}: \nFull name {item.fullName}\n Name {item.name}\nLength {Convert.ToString(item.length)}kb\nCreated {item.creationDateTime}\n ");
            }
        }

        public static void ShowMessage(string message)
        {
            //Console.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void ShowMessage(string message, Boolean bEventType)
        {
            Console.WriteLine(message);
        }
    }
}

