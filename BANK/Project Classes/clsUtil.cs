using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Configuration;

namespace BANK
{
    public class clsUtil
    {
        static public string UpperTheFirtLetterFrom(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return string.Empty;


            Text = Text.ToLower();
            Text = char.ToUpper(Text[0])+ Text.Substring(1,Text.Length-1);
            return Text;
        }

        static public bool DeleteFile(string FilePath)
        {
            if (!File.Exists(FilePath))
                return true;

            try
            {
                File.Delete(FilePath);
                return true;
            }
            catch (IOException ioe)
            {
                return false;
            }
        }    

        static public string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }

        static public bool CreateTheDirectoryIfNotExist(string Diractory)
        {
            if (Directory.Exists(Diractory))
            {
                return true;
            }
            else//Is not Exist
            {
                try
                {
                    Directory.CreateDirectory(Diractory);
                    return true;
                }
                catch (IOException ioe)
                {
                    MessageBox.Show($"Error: {ioe.Message}.");
                    return false;
                }
            }      
        }

        static public bool CopieImageToImagesProjectFolder(ref string ImagePath)
        {
            if(string.IsNullOrEmpty(ImagePath)) 
                return false;

            string DestinationFolder = ConfigurationManager.AppSettings["People Images Direcotry"];

            if(!CreateTheDirectoryIfNotExist(DestinationFolder))
            {
                return false;
            }

            string Extension = Path.GetExtension(ImagePath);
            string NewImagePath = Path.Combine(DestinationFolder, GenerateGuid() + Extension);

            try
            {
                File.Copy(ImagePath, NewImagePath, true);
                ImagePath = NewImagePath;
                return true;
            }
            catch (IOException ioe)
            {
                MessageBox.Show($"Error: {ioe.Message}.");
                return false;
            }

        }

        static public string GenerateABankAccountPasswored(byte Length)
        {
            char[] Password = new char[Length];
            string P = string.Empty;
            Random rnd = new Random();

            for (int i= 0;i< Length;i++)
            {

                Password[i] = (char) rnd.Next(33, 122);
                
            }


            string PasswordGenerated = new string(Password);
            return PasswordGenerated;   
        }

        static public string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] HashByte = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(HashByte).Replace("-", "");
            }
        }
    }
}
