using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CommonTools
{
    public class FileOperations
    {
        public static bool Read(string path, out string content)
        {
            content = string.Empty;
            if (File.Exists(path))
            {
                //content = File.ReadAllText(path);
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                        content += reader.ReadLine();
                    reader.Close();
                }

                return true;
            }
            else
            {
                MessageBox.Show("File not Found");
                return false;
            }
        }

        public static bool Write(string path, string content, bool overWrite = false)
        {
            string errmsg = string.Empty;
            if (path.IsNotNullorEmpty())
            {
                FileInfo finfo = new FileInfo(path);
                if (Directory.Exists(finfo.DirectoryName))
                {
                    if (!File.Exists(path) || overWrite)
                    {
                        using (StreamWriter writer = new StreamWriter(path))
                        {
                            writer.Write(content);
                            writer.Flush();
                            writer.Close();
                        }
                        Application.DoEvents();
                        return true;
                    }
                    else
                    {
                        errmsg = "File already exist";
                    }
                }
                else
                {
                    errmsg = "Path not found";
                }
            }
            else
            {
                errmsg = "Path not empty";
            }

            MessageBox.Show(errmsg);
            return false;
        }

        public static bool GetOpenFilePath(out string path, string extType = ".MyExt", string extName = "MyExtension")
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            OpenDlg.Filter = extName + " (*" + extType + ")|*" + extType;
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                path = OpenDlg.FileName;
                return true;
            }
            else
            {
                path = string.Empty;
                return false;
            }
        }

        public static bool GetSavePath(out string path, string extType = ".MyExt", string extName = "MyExtension")
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            SaveDlg.Filter = extName + " (*" + extType + ")|*" + extType;
            if (SaveDlg.ShowDialog() == DialogResult.OK)
            {
                path = SaveDlg.FileName;
                return true;
            }
            else
            {
                path = string.Empty;
                return false;
            }
        }
    }
}
