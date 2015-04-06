using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Question2ChangeDirectory
{
    #region Question 2

    public class Path
    {
        public string CurrentPath { get; private set; }

        public Path(string path)
        {
            this.CurrentPath = path;
        }

        public Path Cd(string newPath)
        {
            String[] oldPathArray = CurrentPath.Split('/');

            if (!newPath.Equals("/"))
            {
                String[] newPathArray = newPath.Split(new String[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String p in newPathArray)
                {
                    if ("..".Equals(p))
                    {
                        int index = CurrentPath.LastIndexOf('/');
                        if (index != 0)
                            CurrentPath = CurrentPath.Remove(index, CurrentPath.Length - index);
                        else if ( CurrentPath.Length != 1 )
                            CurrentPath = CurrentPath.Remove(index + 1, CurrentPath.Length -1);
                    }
                    else if (CurrentPath != "/")
                        CurrentPath += "/" + p;
                    else
                        CurrentPath += p;
                }
            }
            else
                CurrentPath = "/";

            return this;
        }

        private static bool checkInput(String newPath)
        {
            bool isValid = false;
            
            if ( !String.IsNullOrEmpty(newPath) && newPath.IndexOf("//") == -1)
            {
                if (newPath.IndexOf(".") > -1)
                    if (newPath != "..")
                        newPath = newPath.Replace("/..", "").Replace("../", "").Replace("/../", "");
                    else
                        newPath = newPath.Replace("..", "");

                newPath = newPath.Replace("/", "");
                if ( String.IsNullOrEmpty(newPath) || Regex.IsMatch(newPath, @"^[A-Za-z]+$"))
                    isValid = true;
            }
            
            return isValid;
        }

        public static void Main(string[] args)
        {
            Path path = new Path("/a/b/c/d");
            while (true)
            {
                Console.WriteLine("Current Path : " + path.CurrentPath);
                Console.Write("Enter the new Path : ");
                String newPath = Console.ReadLine().Trim();

                if( checkInput(newPath) )
                    Console.WriteLine("New Path : " + path.Cd(newPath).CurrentPath + "\n\n");
                else
                    Console.WriteLine("\n\tError : Enter a valid path\n\n");
            }
        }
    }
    #endregion
}
