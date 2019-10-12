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
using DebugLog;
namespace DebugClient
{
    public partial class Form1 : Form
    {
        public List<string> list = new List<string>();
        public Debug bug = new Debug();
        public Form1()
        {
            InitializeComponent();

        }




        public void textBox1_TextChanged(object sender, EventArgs e) //used for search
        {

            string text = textBox1.Text;
            string path = string.Format("debug.txt");
            listBox1.Items.Clear(); //clearing listbox means that it will only give matching queries
                                    //because without clearing it will keep adding
                                    
            foreach (string i in list) //it then only adds matching queries
            {

                if (i.Contains(text))
                {
                    listBox1.Items.Add(i);
                }
                
            }
            
        }




    

        public void listBox1_Click(object sender, EventArgs e) //on click i want a bigger update of everything
        {
            string text2 = (string)listBox1.SelectedItem;
            var exception = text2.Substring(0, text2.IndexOf(":"));
            var description = text2.Substring(text2.IndexOf(":") +1, text2.Length - exception.Length -1);
            //requires -exception.Length because it alters the original string
            //also because it's a length parameter, rather than a second index parameter
            //because of that, - len(exception) - makes it so that the length of the substring matches the end of the string
            


            MessageBox.Show(string.Format("Exception: {0}\n\n Description: {1}", exception, description));
        }

        public void Form1_Load(object sender, EventArgs e) //on load, give me all the bugs that i've encountered thus far
        {
            using (StreamReader r = new StreamReader("debug.txt"))
            {
                while (r.Peek() >= 0) //another way to get all lines from  a file, other than != null
                    //use (line = reader.ReadLine()) != null - to get best results, because it won't repeat its call later on (thus skipping lines)
                {
                    list.Add(r.ReadLine());
                }
                
                

            }
            foreach(string i in list) //so i can access it again for search queries
            {
                listBox1.Items.Add(i); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using(StreamWriter r = new StreamWriter("debug.txt"))
            {
                r.Write(""); //clears document
            }
        }
    }
}