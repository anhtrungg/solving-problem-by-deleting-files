using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static void DeleteAllSubFolderAndFile(string folderDirectory)
        {
            string[] subFileEntries = Directory.GetFiles(folderDirectory);

            for (int k = 0; k < subFileEntries.Length; k++)
            {
                Console.WriteLine(subFileEntries[k]);
                File.Delete(subFileEntries[k]);
            }

            string[] subDirectoryEntries = Directory.GetDirectories(folderDirectory);

            for (int i = 0; i < subDirectoryEntries.Length; i++)
            {

                Console.WriteLine(subDirectoryEntries[i]);
                string[] subSubdirectoryEntries = Directory.GetDirectories(subDirectoryEntries[i]);

                string[] subSubFileEntries = Directory.GetFiles(subDirectoryEntries[i]);

                for (int j = 0; j < subSubdirectoryEntries.Length; j++)
                {
                    Console.WriteLine(subSubdirectoryEntries[j]);

                    DeleteAllSubFolderAndFile(subSubdirectoryEntries[j]);
                }

                for (int k = 0; k < subSubFileEntries.Length; k++)
                {
                    Console.WriteLine(subSubFileEntries[k]);
                    File.Delete(subSubFileEntries[k]);
                }

                System.IO.Directory.Delete(subDirectoryEntries[i], true);
            }

            System.IO.Directory.Delete(folderDirectory, true);
        }
        static void Main(string[] args)
        {

            string root = @"C:\Users\anhnt\OneDrive\Desktop\FootballManagement\mffms-update\node_modules";

            // Get all subdirectories

            string[] subdirectoryEntries = Directory.GetDirectories(root);

            // Loop through them to see if they have any other subdirectories

            for(int i = 0; i < subdirectoryEntries.Length; i++)
            {

                Console.WriteLine(subdirectoryEntries[i]);
                string[] subSubdirectoryEntries = Directory.GetDirectories(subdirectoryEntries[i]);
                
                string[] subSubFileEntries = Directory.GetFiles(subdirectoryEntries[i]);
                
                for (int j = 0; j < subSubdirectoryEntries.Length; j++)
                {
                    Console.WriteLine(subSubdirectoryEntries[j]);

                    DeleteAllSubFolderAndFile(subSubdirectoryEntries[j]);
                }

                for (int k = 0; k < subSubFileEntries.Length; k++)
                {
                    Console.WriteLine(subSubFileEntries[k]);
                    File.Delete(subSubFileEntries[k]);
                }

                System.IO.Directory.Delete(subdirectoryEntries[i], true);
            }

            Console.WriteLine("Finish remove all sub-directory");

        }
    }
}