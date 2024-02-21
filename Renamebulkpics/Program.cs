using System;
using System.IO;
namespace BatchRenamePro
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specify the directory where your images are located
            string directoryPath = @"C:\Your\Directory\Path";

            // Specify the word to be replaced and its replacement
            string wordToReplace = "oldword";
            string replacementWord = "newword";


            // Specify the file extensions to search for
            string[] fileExtensions = { "*.jpg", "*.png", "*.gif" }; // Add or remove file extensions as needed

            try
            {
                foreach (string extension in fileExtensions)
                {
                    // Get all image files with the specified extension in the directory
                    string[] imageFiles = Directory.GetFiles(directoryPath, extension);

                    foreach (string imagePath in imageFiles)
                    {
                        // Get the file name without the extension
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imagePath);

                        // Replace the word in the file name
                        string newFileName = fileNameWithoutExtension.Replace(wordToReplace, replacementWord);

                        // Construct the new file path
                        string newFilePath = Path.Combine(Path.GetDirectoryName(imagePath), newFileName + Path.GetExtension(imagePath));

                        // Rename the file
                        File.Move(imagePath, newFilePath);

                        Console.WriteLine($"File renamed: {Path.GetFileName(imagePath)} => {Path.GetFileName(newFilePath)}");
                    }
                }

                Console.WriteLine("Bulk rename completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            // Prompt the user to press any key before exiting
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}
