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


namespace StatusFileFormatter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String dir = textBox1.Text;

            FormatFile(dir + "\\SGNH.txt", dir + "\\SGNH_OUT.txt", 306, false);
            FormatFile(dir + "\\SGNN.txt", dir + "\\SGNN_OUT.txt", 176, false);
            FormatFile(dir + "\\SGNS.txt", dir + "\\SGNS_OUT.txt", 129, true);
            FormatFile(dir + "\\SIGNS.txt", dir + "\\SIGNS_OUT.txt", 239, false);

            MessageBox.Show("DONE!");
        }

        private void FormatFile(string filenameIn, string filenameOut, int linewidth, bool replaceASCII)
        {

            try
            {

                StreamWriter sw = new StreamWriter(filenameOut);
                using (StreamReader sr = new StreamReader(filenameIn))
                {

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {


                        if (replaceASCII)
                        {
                            line = ASCIIReplace(line);
                        }

                        if (line != "")
                        {
                            string lineFormatted = line.PadRight(linewidth, ' ');
                            sw.WriteLine(lineFormatted);
                        }

                    }



                    sr.Close();
                }
                sw.Close();

            }
            catch (Exception ex)
            {
                string s = ex.Message; 
            }


        }
        private string ASCIIReplace(String s)
        {
            if (s.Length > 29)
            {


                string position27to29 = s.Substring(27, 3);
                double Num;
                bool isNum = double.TryParse(position27to29, out Num);

                if (isNum)
                {
                    string position30 = s.Substring(30, 1);
                    string updatedposition30=null;

                    if (!double.TryParse(position30, out Num))
                    {
                        switch (position30)
                        {
                            case "{":
                                updatedposition30 = "0";
                                break;
                            case "}":
                                updatedposition30 = "0";
                                break;
                            case "A":
                                updatedposition30 = "1";
                                break;
                            case "B":
                                updatedposition30 = "2";
                                break;
                            case "C":
                                updatedposition30 = "3";
                                break;
                            case "D":
                                updatedposition30 = "4";
                                break;
                            case "E":
                                updatedposition30 = "5";
                                break;
                            case "F":
                                updatedposition30 = "6";
                                break;
                            case "G":
                                updatedposition30 = "7";
                                break;
                            case "H":
                                updatedposition30 = "8";
                                break;
                            case "I":
                                updatedposition30 = "9";
                                break;
                            case "J":
                                updatedposition30 = "1";
                                break;
                            case "K":
                                updatedposition30 = "2";
                                break;
                            case "L":
                                updatedposition30 = "3";
                                break;
                            case "M":
                                updatedposition30 = "4";
                                break;
                            case "N":
                                updatedposition30 = "5";
                                break;
                            case "O":
                                updatedposition30 = "6";
                                break;
                            case "P":
                                updatedposition30 = "7";
                                break;
                            case "Q":
                                updatedposition30 = "8";
                                break;
                            case "R":
                                updatedposition30 = "9";
                                break;
                            case "S":
                                updatedposition30 = "2";
                                break;
                            case "T":
                                updatedposition30 = "3";
                                break;
                            case "U":
                                updatedposition30 = "4";
                                break;
                            case "V":
                                updatedposition30 = "5";
                                break;
                            case "W":
                                updatedposition30 = "6";
                                break;
                            case "X":
                                updatedposition30 = "7";
                                break;
                            case "Y":
                                updatedposition30 = "8";
                                break;
                            case "Z":
                                updatedposition30 = "9";
                                break;


                            default:
                                textBox2.Text = textBox2.Text +  "\r\n" + s;
                                break;
                        }
                    }


                    

                    if (updatedposition30!=null)
                    {
                        
                        string head = s.Substring(0, 30);
                        string tail = s.Substring(31);
                        return head + updatedposition30 + tail;
                    }


                }


            }
            return s;

        }
    }


}
