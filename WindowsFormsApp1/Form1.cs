using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    /*
    Created 02/15/2018
    Created by Sean Davitt, Tyler Technologies NWPS Mobile Implimentation Specialist
    Designed for 64bit and 32bit windows

        WIP
            Faster execution without sacrificing accuracy
            Message boxes that display text
                1. When no operation is selected
                2. When common errors occur
                3. Others I'm sure
            Speed testing between the two copy methods

        WORK FLOW FOR PROGRAM:
            Location you want to copy from (user defined) => compression to a backup folder(user defined)

            => zip folder is copied to the location you want to copy to(user defined)

            => Decompressed in the location you want to copy files to BUT in now in the "Extracted files" folder
    */

    public partial class Form1 : Form
    {
        private XmlDocument StartupSettings = new XmlDocument();
        private string SourcePath = @"";
        private string TargetPath = @"";
        private string BackUpPath = @"";
        private string CompressionFileLable = "";
        public string ClientPath1 { get => TargetPath; set => TargetPath = value; }
        public string SourcePath1 { get => SourcePath; set => SourcePath = value; }

        //What the form does with it initializes every time
        private void Form1_Load(object sender, EventArgs e)
        {
            InitialLoadofXML();

            TSL.Text = "Ready to Copy files";
        }

        public Form1()
        {
            InitializeComponent();

            bg = new BackgroundWorker();
            bg.DoWork += Bg_DoWork;
            //bg.ProgressChanged += Bg_ProgressChanged;
            bg.RunWorkerCompleted += Bg_RunWorkerCompleted;
            bg.WorkerReportsProgress = true;
        }

        //Copy button
        private void Copy_Button_Click(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }

        //Copies all directories and subfolders
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        //Copies all files from one location to another asynchronously
        //The added "speed" might result in data corruption
        //"speed" - less waiting on I/O so the OS will move whatever information it has at all times
        //so that it is a genuine constant stream of data
        public async Task AsyncCopy()
        {
            string StartDir = Location_ZipFIle_To.Text;
            string EndDir = Location_Copy_To.Text;

            TSL.Text = "Copying from Compression Location to Save location.";

            try
            {
                foreach (string dirPath in Directory.GetDirectories(StartDir, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(StartDir, EndDir));
                    foreach (string filename in Directory.EnumerateFiles(dirPath))
                    {
                        using (FileStream SourceStream = File.Open(filename, FileMode.Open))
                        {
                            using (FileStream DestinationStream = File.Create(filename.Replace(StartDir, EndDir)))
                            {
                                await SourceStream.CopyToAsync(DestinationStream);
                            }
                        }
                    }
                }

                foreach (string filename in Directory.EnumerateFiles(StartDir))
                {
                    using (FileStream SourceStream = File.Open(filename, FileMode.Open))
                    {
                        using (FileStream DestinationStream = File.Create(EndDir + filename.Substring(filename.LastIndexOf('\\'))))
                        {
                            await SourceStream.CopyToAsync(DestinationStream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }

        //Compresses all files/folders from a user defined location to a "back up" folder
        //The end folder for compression CAN NOT be the same location the files are coming from.
        private void Compress()
        {
            TSL.Text = "Compressing Folder";
            string StartPath = Location_Copy_From.Text;
            string ZipPath = Location_ZipFIle_To.Text;
            System.IO.Compression.ZipFile.CreateFromDirectory(StartPath, ZipPath + @"\" + CompressedFileName.Text + ".zip");
        }

        //XML related information. Broken up between loading prior XML or creating a new XML with places holder information
        private void InitialLoadofXML()
        {
            //Checking if the CopyFiles.xml exists, and loading the data if it does.
            if (File.Exists("CopyFiles.xml"))
            {
                StartupSettings.Load("CopyFiles.xml");

                Location_Copy_From.Text = StartupSettings.GetElementsByTagName("SourcePath")[0].InnerText;
                Location_Copy_To.Text = StartupSettings.GetElementsByTagName("TargetPath")[0].InnerText;
                Location_ZipFIle_To.Text = StartupSettings.GetElementsByTagName("BackUpPath")[0].InnerText;
                CompressedFileName.Text = StartupSettings.GetElementsByTagName("CompressionFileLable")[0].InnerText;
            }

            //Creation of a new CopyFiles.xml if one does not already exist.
            else
            {
                SourcePath = Location_Copy_From.Text;
                TargetPath = Location_Copy_To.Text;
                BackUpPath = Location_ZipFIle_To.Text;
                CompressionFileLable = CompressedFileName.Text;

                //root of the XML
                XmlNode root = StartupSettings.CreateElement("root");
                StartupSettings.AppendChild(root);

                //COPY FROM PATH
                XmlNode Location_Copy_FromPathNode = StartupSettings.CreateElement("SourcePath");
                Location_Copy_FromPathNode.InnerText = @"Copy from location";
                root.AppendChild(Location_Copy_FromPathNode);

                //COPY TO PATH
                XmlNode Location_Copy_ToPathNode = StartupSettings.CreateElement("TargetPath");
                Location_Copy_ToPathNode.InnerText = @"Copy to location";
                root.AppendChild(Location_Copy_ToPathNode);

                ///COPY TO PATH
                XmlNode Location_ZipFile_ToPathNode = StartupSettings.CreateElement("BackUpPath");
                Location_ZipFile_ToPathNode.InnerText = @"C:\Temp";
                root.AppendChild(Location_ZipFile_ToPathNode);

                XmlNode CompressionPathNode = StartupSettings.CreateElement("CompressionFileLable");
                CompressionPathNode.InnerText = "Back Up";
                root.AppendChild(CompressionPathNode);

                //Save the start up settings
                StartupSettings.Save("CopyFiles.xml");
            }
        }

        //WIP so that when the placeholder text is modified the XML maintains the modification for the subsiquint uses.
        private void SaveStartupSettings()
        {
            StartupSettings.GetElementsByTagName("SourcePath")[0].InnerText = Location_Copy_From.Text;
            StartupSettings.GetElementsByTagName("TargetPath")[0].InnerText = Location_Copy_To.Text;
            StartupSettings.Save("CopyFiles.xml");
        }

        //This will create the back up location
        //WIP - will delete BackUp.zip if it is already present
        private void Temp()
        {
            Directory.CreateDirectory(Location_ZipFIle_To.Text);
        }

        //Will display a message when the Compression-Copy-Decompression is finished
        //WIP clean download and decompression
        //WIP give option to rerun the program for other files
        private void MessageCopy()
        {
            MessageBox.Show("Copy is complete");
            TSL.Text = "Copy is Complete. Close Program or Copy a new folder.";
        }

        //This will clean up all files that are not wanted on the new local system.
        //Contant WIP as I get new information to delete
        private void CleanUp()
        {
            TSL.Text = "Deleting Back Up";

            //This will delete the zipped folder on the new machine
            string[] directoryFiles = Directory.GetFiles(Location_ZipFIle_To.Text, "*.zip");

            foreach (string directoryFile in directoryFiles)
            {
                File.Delete(directoryFile);
            }
        }

        //Help Button
        private void Help_Button_Click(object sender, EventArgs e)
        {
            var Message = " Help Button .\n\n";
            Message += "1. Async Copy \n\n";
            Message += "    1a. Will copy files in a continuous stream of information (there is very little I/O downtime as each file is accessed at one time.) \n\n";
            Message += "2. Normal Copy Copy \n\n";
            Message += "    2a. Will copy files one at a time (there is a little bit of I/O lead time as it accesses each file at a time.) \n\n";
            Message += "3. Location you are copying from \n\n";
            Message += "    3a. Location you are copying all files from. \n\n";
            Message += "4. Location you are copying to. \n\n";
            Message += "    4a. Location you want all files you are copying to end up. \n\n";
            Message += "5. Back up Location \n\n";
            Message += "    5a. Local location you want the ZIP file to be. \n\n";
            Message += "6. If you have any issues or questions please call Sean Davitt. \n\n";
            Message += "    6a. Please call me at 609 709 5449. \n\n";
            Message += "    6a. Please email me at sean.davitt@tylertech.com. \n\n";

            MessageBox.Show(Message);
        }

        private BackgroundWorker bg;

        private void Bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Task completed");
        }

        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Async_File_Copy.Checked == true)
            {
                SaveStartupSettings();

                //See Temp Below
                Temp();
                //See compress below
                Compress();

                //Runs the AsyncCopy function as a task to ensure it completes
                //and does not allow decompress(); to access a file that needs to be copied
                var t = Task.Run(() => AsyncCopy());
                t.Wait();

                //See CleanUp below
                CleanUp();

                //Displays a message and closes the application
                MessageCopy();
            }

            //Code to execute if someone wants to copy files synchronously(Normally)
            if (Normal_File_Copy.Checked == true)
            {
                //See Temp Below
                Temp();

                //''
                Compress();

                //Copies all directories and files from one location to another
                //this specifically means one zip folder from one location to another and will over-right a file if need be.
                DirectoryCopy(Location_ZipFIle_To.Text, Location_Copy_To.Text, true);

                //''
                CleanUp();

                //''
                MessageCopy();
            }
        }
    }
}