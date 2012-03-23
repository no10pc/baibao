using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.IO.IsolatedStorage;

namespace baibao.Common
{
    public class IsolatedStorageManager
    {
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public bool CreateFolder(string folderName)
        {
            bool result = false;
            using (IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isoFile.DirectoryExists(folderName))
                {
                    result = false;
                }
                else
                {
                    isoFile.CreateDirectory(folderName);
                    result = true;
                }
            };
            return result;
        }
        /// <summary>
        /// 检测文件夹是否存在
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public bool ExistFolder(string folderName)
        {
            bool result = false;

            using (IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isoFile.DirectoryExists(folderName))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public bool DeleteFolder(string folderName)
        {
            bool result = true;
            using (IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication())
            {

                if (isoFile.DirectoryExists(folderName))
                {
                    isoFile.DeleteDirectory(folderName);
                    //MessageBox.Show(folderName + "已成功删除！");
                    result = true;
                }
                else
                {
                    //MessageBox.Show("不存在目录" + folderName);
                    result = false;
                }

            }
            return result;
        }
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool CreateFile(string fileName)
        {
            bool result = true;
            try
            {
                using (IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication())
                {

                    FileStream fileStream = isoFile.CreateFile(fileName);
                    fileStream.Close();
                }
            }
            catch
            {
                result = false;

            }
            return result;
        }

        public bool ExistFile(string fileName)
        {
            bool result = true;
            using (IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isoFile.FileExists(fileName))
                {
                    //MessageBox.Show("存在文件" + fileName);
                    result = true;
                }
                else
                {
                    //MessageBox.Show("不存在文件" + fileName);
                    result = false;
                }
            }


            return result;
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool DeleteFile(string fileName)
        {
            bool result = true;
            try
            {
                using (IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    isoFile.DeleteFile(fileName);
                    result = true;
                }
            }
            catch
            {
                result = false;
            }


            return result;
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool WriteFile(string fileName, string content)
        {
            bool result = true;

            try
            {
                using (IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream isoFileStream = isoFile.OpenFile(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        StreamWriter streamWriter = new StreamWriter(isoFileStream);
                        streamWriter.WriteLine(content);
                        streamWriter.Close();
                    }
                }
            }
            catch
            {
                result = false;
            }


            return result;
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ReadFile(string fileName)
        {
            string result = string.Empty;
            using (IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isoFileStream = isoFile.OpenFile(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    StreamReader streamReader = new StreamReader(isoFileStream);
                    result = streamReader.ReadToEnd().ToString();
                    streamReader.Close();
                }
            }
            return result;
        }
        /// <summary>
        /// 写入配置信息
        /// </summary>
        /// <param name="settingName"></param>
        /// <param name="settingValue"></param>
        /// <returns></returns>
        public bool WriteApplicationSettings(string settingName, string settingValue)
        {
            bool result = true;
            try
            {
                IsolatedStorageSettings.ApplicationSettings[settingName] = settingValue;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
            catch
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 读取配置信息
        /// </summary>
        /// <param name="settingName"></param>
        /// <returns></returns>
        public string ReadApplicationSettings(string settingName)
        {
            string result = string.Empty;
            try
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(settingName))
                {
                    result = IsolatedStorageSettings.ApplicationSettings[settingName] as string;
                }
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }


    }
}
