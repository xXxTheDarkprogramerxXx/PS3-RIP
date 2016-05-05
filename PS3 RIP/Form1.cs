using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace PS3_RIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //String Patterns used for the patterns from the settings menu
        string Patterns = string.Empty;

        //Check if the copy thread has started
        bool CopyBusy = false;

        //Estemated size for the copy progress bar
        long EstematedSize;


        #region <<  Methods >>

        /// <summary>
        /// The Directory to save the RIPPED Game
        /// </summary>
        /// <returns></returns>
        private string RIPDIR()
        {
            string MainDir = Application.StartupPath + @"\RIPPED";
            if (!Directory.Exists(MainDir))
            {
                Directory.CreateDirectory(MainDir);
            }
            return MainDir;
        }

        /// <summary>
        /// Log everything inside the ListBox and auto scroll down
        /// </summary>
        /// <param name="item">the string to be added</param>
        public void log(string item)
        {
            //Create For Log Window
            listBox1.Invoke(new Action(() => listBox1.Items.Add(item)));
            //AutoScroll Mode
            if (listBox1.SelectionMode != SelectionMode.None)
            {
                listBox1.Invoke(new Action(() => listBox1.SelectedIndex = listBox1.Items.Count - 1));
                listBox1.Invoke(new Action(() => listBox1.SelectedIndex = -1));
            }
            //Do Events
            Application.DoEvents();
        }

        private List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string d in Directory.GetDirectories(sDir, "*", SearchOption.AllDirectories))
                {
                    files.Add(d);
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }


        private List<String> DirSearchFileCount(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string d in Directory.GetFiles(sDir, "*.*", SearchOption.AllDirectories))
                {
                    files.Add(d);
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }

        /// <summary>
        /// Directory Search Using Patterns
        /// </summary>
        /// <param name="sDir">the Source Directory</param>
        /// <returns>A List of file contained within the search pattern</returns>
        private List<String> DirSearch_Patterns(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                //Replacing the Patterns which we assgined at the begining with | to seperate later
                Patterns = Patterns.Replace("\r\n", " | ");
                Patterns = Patterns.Replace("\\", " ");
                Patterns = Patterns.Replace(" ", "");
                DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(sDir);
                string[] filesInDir = getFilesOrDirectories(sDir, Patterns, SearchOption.AllDirectories);

                foreach (string foundFile in filesInDir)
                {
                    if (!files.Contains(foundFile))
                    {
                        string fullName = foundFile;
                        files.Add(fullName);
                    }
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }


        /// <summary>
        /// Returns file names from given folder that comply to given filters
        /// </summary>
        /// <param name="SourceFolder">Folder with files to retrieve</param>
        /// <param name="Filter">Multiple file filters separated by | character</param>
        /// <param name="searchOption">File.IO.SearchOption, 
        /// could be AllDirectories or TopDirectoryOnly</param>
        /// <returns>Array of FileInfo objects that presents collection of file names that 
        /// meet given filter</returns>
        public string[] getFilesOrDirectories(string SourceFolder, string Filter, System.IO.SearchOption searchOption)
        {
            // ArrayList will hold all file names
            ArrayList alFiles = new ArrayList();

            // Create an array of filter string
            string[] MultipleFilters = Filter.Split('|');

            // for each filter find mathing file names
            foreach (string FileFilter in MultipleFilters)
            {
                if (FileFilter.Contains("\\"))
                {
                    alFiles.AddRange(Directory.GetDirectories(SourceFolder, FileFilter, searchOption));
                }
                else
                {
                    // add found file names to array list
                    alFiles.AddRange(Directory.GetFiles(SourceFolder, FileFilter, searchOption));
                }
            }

            // returns string array of relevant file names
            return (string[])alFiles.ToArray(typeof(string));
        }

        /// <summary>
        /// Get Directory sizes in B KB MB GB TB ZB
        /// </summary>
        /// <param name="folderPath">the location of the directory</param>
        /// <returns>SIZE IN B,KB,MB,GB,TB,ZB</returns>
        private string GetDirectorySize(string folderPath)
        {
            //Get the directory info
            DirectoryInfo di = new DirectoryInfo(folderPath);
            //assign size of the directory in bytes
            double len = di.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(fi => fi.Length);
            //assignt an Array of sizes
            string[] sizes = { "B", "KB", "MB", "GB","TB","ZB" };
            //Used to determine the order for the sizes
            int order = 0;
            //now run a while till we have something belowe 1024
            while (len >= 1024 && order + 1 < sizes.Length)
            {
                //inc order
                order++;
                //devide again to get a lower value
                len = len / 1024;
            }
            //Format the result string to get something like 1MB
            string result = String.Format("{0:0.##} {1}", len, sizes[order]);
            //Return the result
            return result;
        }


        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, List<string> ExcludeList)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

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
                if (!ExcludeList.Contains(file.FullName))
                {
                    file.CopyTo(temppath, true);
                    if (bgGetSize.IsBusy == false)
                    {
                        bgGetSize.RunWorkerAsync();
                    }
                }
                else
                {
                    //Create the dummy file
                    if (!temppath.Contains("PS3UPDAT.PUP"))
                    {
                        File.Create(temppath);
                    }
                }
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs, ExcludeList);
                }
            }
        }

        private string GetSize(string filename)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = new FileInfo(filename).Length;
            int order = 0;
            while (len >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                len = len / 1024;
            }
            string result = String.Format("{0:0.##} {1}", len, sizes[order]);

            return result;
        }

        private void RIP()
        {
            // Read directory

            log("------ READING FOLDERS --------");

            int Counter = 0;

            List<string> Directories = DirSearchFileCount(textBox1.Text);

            foreach (var item in DirSearch(textBox1.Text))
            {
                Counter++;
                this.Invoke(new Action(() => progressBar1.Value = (Counter * 100) / DirSearch(textBox1.Text).Count));
                this.Invoke(new Action(() => lblPercent.Text = progressBar1.Value.ToString() + "%"));
                lblRIP.Invoke(new Action(() => lblRIP.Text = "Checking: " + Counter.ToString() + "/" + DirSearch(textBox1.Text).Count.ToString()));
                Application.DoEvents();
                log("Reading: " + item + "-->" + GetDirectorySize(item));
            }

            // Rip files from Patterns 

            log("------ RIPPING FILES ----------");

            List<string> DirRip = DirSearch_Patterns(textBox1.Text);

            Counter = 0;
            long rippedsize = 0;
            foreach (var item in DirRip)
            {
                Counter++;
                this.Invoke(new Action(() => progressBar1.Value = (Counter * 100) / DirRip.Count));
                this.Invoke(new Action(() => lblPercent.Text = progressBar1.Value.ToString() + "%"));
                lblRIP.Invoke(new Action(() => lblRIP.Text = "Ripping: " + Counter.ToString() + "/" + DirRip.Count.ToString()));

                //Calculate the new size

                long len = new FileInfo(item).Length;
                rippedsize += len;

                log(item + "-->" + GetSize(item));
            }

            DirectoryInfo di = new DirectoryInfo(textBox1.Text);
            long Size = di.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(fi => fi.Length);

            EstematedSize = Size - rippedsize;


            // Copy the new directory minus all the ripped files 
            CopyBusy = true;

            this.Invoke(new Action(() => progressBar1.Value = 0));

            if (Directory.Exists(RIPDIR() + @"\" + new DirectoryInfo(textBox1.Text).Name))
            {
                log("------ Clearing old folder ---------- ");

                System.IO.DirectoryInfo deletedir = new DirectoryInfo(RIPDIR() + @"\" + new DirectoryInfo(textBox1.Text).Name);

                foreach (FileInfo file in deletedir.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in deletedir.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            log("------ COPYING ---------- ");

            log(new DirectoryInfo(textBox1.Text).FullName + "-->" + GetDirectorySize(textBox1.Text));

            DirectoryCopy(textBox1.Text, RIPDIR() + @"\" + new DirectoryInfo(textBox1.Text).Name, true, DirRip);

            CopyBusy = false;

            //Done Open New Directory 

            log("------ DONE ---------- ");

            log(RIPDIR() + @"\" + new DirectoryInfo(textBox1.Text).Name + "-->" + GetDirectorySize(RIPDIR() + @"\" + new DirectoryInfo(textBox1.Text).Name));

            System.Diagnostics.Process.Start(RIPDIR() + @"\" + new DirectoryInfo(textBox1.Text).Name);

            if (MessageBox.Show("Would you like to delete the old directory ?", "Done..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }

        }


        #endregion << Methods >>

        #region << Events >>

        /// <summary>
        /// Open the settings for patterns 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            settings set = new settings();
            set.ShowDialog();

            Patterns = set.fulllist + "\r\n *.PUP";

        }



        #endregion << Events >>

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = @"C:\Users\3deEchelon\Desktop\PS3 Games\Sniper Elite III PS3-DUPLEX\BLES01981-[Sniper Elite 3]";
            //get lits of patterns 
            settings set = new settings();

            Patterns = set.fulllist + "\r\n *.PUP";

            lblGitHub.Text = DateTime.Now.Year.ToString() + " The Darkprogramer";
        }

        private void lblGitHub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xXxTheDarkprogramerxXx/PS3-RIP");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            progressBar1.Value = 0;
            if (bgWorker.IsBusy == false)
            {
                bgWorker.RunWorkerAsync();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog thedialog = new FolderBrowserDialog();
            thedialog.Description = "Select your PS3 Game Directory";
            thedialog.RootFolder = Environment.SpecialFolder.MyComputer;
            if (thedialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = thedialog.SelectedPath;
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                RIP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bgGetSize_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DirectoryInfo newdi = new DirectoryInfo((RIPDIR() + @"\" + new DirectoryInfo(textBox1.Text).Name));

                while (CopyBusy == true)
                {
                    long newSize = newdi.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(fi => fi.Length);

                    int PBValue = (int)((newSize * 100 ) / EstematedSize);
                   
                    this.Invoke(new Action(() => progressBar1.Value = (int)(PBValue)));
                    this.Invoke(new Action(() => lblPercent.Text = progressBar1.Value.ToString() + "%"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
