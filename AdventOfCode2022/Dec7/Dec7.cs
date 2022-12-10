using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

public static class Dec7
{
    public static string A()
    {
        var input = File.ReadAllLines(@"D:\Git\AdventOfCode2022\AdventOfCode2022\Dec7\Input7.txt").ToList();
        //var inputString = input.First();

        LocalSystem localSystem = new LocalSystem();
        Folder rootFolder = new Folder("root");
        localSystem.Add(rootFolder);

        //skapa alla folders
        foreach (var d in input.Where(x => x.Contains("dir")))
        {
            string name = d.Remove(0,4);
            var parentFolder = GetParentFolder(input, input.IndexOf(d), localSystem);
            
            localSystem.AddChild(parentFolder,new Folder(name));
        }
        //skapar och lägger till alla filer i rätt folder
        foreach(var f in input.Where(x => x.Any(char.IsDigit)))
        {
           // Console.WriteLine(f);
            var splitString = f.Split(new[] { " " }, StringSplitOptions.None);
            var parentFolder = GetParentFolder(input, input.IndexOf(f), localSystem);
            parentFolder.Files.Add(new SystemFile(splitString[1], int.Parse(splitString[0])));
            //rootFolder.Files.Add(new SystemFile(splitString[1], int.Parse(splitString[0]))); //byt

        }

        //var currentFolder = "root";
        localSystem.Print();
        Console.WriteLine("-.-.-.-.-.-.");
        //Console.WriteLine(localSystem.GetFolderByName("d").FolderSize);
        return "Summan av mappar med värden under 100 000: " + localSystem.GetSizeOver100000;
    }

    public static Folder GetParentFolder(List<string> input,int folderIndex, LocalSystem localSystem)
    {
        var folderName = "";
        for(int i = folderIndex; i >= 0; i--) 
        {
            if (input[i].Contains("cd"))
            {
                folderName = input[i].Remove(0, 5);
                break;
            }
        }

        return localSystem.GetFolderByName(folderName);
    }

}
//det som skall in i rootFolder är allt mellan första ls och andra cd


public class SystemFile
{
    public string Name { get; set; }
    public int Size { get; set; }

    public SystemFile(string name, int size)
    {
        Name = name;
        Size = size;
    }
}

public class Folder
{
    public string Name { get; set; }
    public List<SystemFile> Files = new List<SystemFile>();
    public List<Folder> ChildFolders= new List<Folder>();
    //public bool RootFolder { get; set; }
    public int FolderSize { get {return Files.Sum(x => x.Size) ; }}

    public Folder(string name)
    {
        Name = name;

    }
    public void AddFolder(Folder childFolder) 
    {
        ChildFolders.Add(childFolder); 
    }
    public void AddFiles(SystemFile childFile)
    {
        Files.Add(childFile);
    }
    public Folder GetFolderByName(string folderName)
    {
        foreach(var c in ChildFolders)
        {
            if (c.Name == folderName)
            {
                return c;
                
            }
        }
        foreach (var c in ChildFolders)
        {
            var x = c.GetFolderByName(folderName);
            return x;
        }
            return null;
    }
    public int GetFolderSize()
    {
        var size = 0;
        size += Files.Sum(x => x.Size);
        foreach(var c in ChildFolders)
            size += c.GetFolderSize();
        return size;
    }
    public void Print()
    {
        Console.WriteLine(Name + " (" + GetFolderSize() + ")");
        foreach(var c in Files)
        {
            Console.WriteLine(c.Name + " " + c.Size);
        }
        foreach (var x in ChildFolders)
        {
            x.Print();
        }
    }
}

public class LocalSystem
{
    public List<Folder> rootSystem = new List<Folder>();
    public int GetSizeOver100000 
    { 
        get {
            var totalSizeForAllFoldersOverX = 0;
            //foreach()

            return rootSystem.Where(x => x.FolderSize <= 100000).Sum(x => x.FolderSize);
            } 
    }

    public void Add(Folder folder)
    {
        rootSystem.Add(folder);
    }
    public void AddChild(Folder parentFolder,Folder folder)
    {
        GetFolderByName(parentFolder.Name).AddFolder(folder);
       // parentFolder.AddFolder(folder);
    }
    public void Add(string folderName)
    {
        Folder tempFolder = new Folder(folderName);
        rootSystem.Add(tempFolder);
    }
    public void Print()
    {
        foreach (var folder in rootSystem)
        {
            folder.Print();
            //Console.WriteLine(folder.Name + " " + folder.FolderSize);
        }
    }
    public Folder GetFolderByName(string folderName)
    {
        if(rootSystem.Find(x => x.Name == folderName) != null) //
        {
            return rootSystem.Find(x => x.Name == folderName);
        }
        foreach(var f in rootSystem)
        {
            if(f.GetFolderByName(folderName) != null)
            {
                var x = f.GetFolderByName(folderName);
                return x;
                
            }
        }
        return rootSystem.First(x => x.Name == "root");
    }

}


