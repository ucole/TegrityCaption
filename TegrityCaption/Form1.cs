using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace TegrityCaption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();//show dialog box
            if (result == DialogResult.OK)
            {
                
                StreamWriter filename = new StreamWriter("New_Caption.txt");   
                foreach (String line in File.ReadAllLines(openFileDialog1.FileName))
                {
                    if (line.Length > 0)
                    {
                        String trimFile = line.Trim();//WORKS!
                        //split file
                        String time = "["+ trimFile.Substring(0, 8) + ".000]";
                        trimFile = trimFile.Remove(0,8);
                        //Replace ampersan with "and"
                        trimFile = trimFile.Replace("&", "and");//Works!
                        //trim end of file
                        trimFile = trimFile.TrimEnd();
                        //take care of non-ASCII characters 
                        //foreach (char c in trimFile)
                        //{
                        //    int ascii = Convert.ToInt32(trimFile);
                        //    if (ascii > 127)
                        //    {
                        //        trimFile.Replace(c.ToString(), "");
                        //    }
                        //}
                        filename.WriteLine(time + trimFile);
                    }
                }
                filename.Close();
            }
        }
    }//end of Form1
}
