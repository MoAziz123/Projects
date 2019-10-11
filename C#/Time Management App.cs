
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;
using System.Media;
using System.IO;

namespace TimeManagementApp
{//app building in c# - declare constructor, then do whatever you want
    public class Form3 : Form
    {
        string fullpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public DateTime now;
        public List<string> boxlist;
        public Button currentbutton;
        public ListBox listboxfortime;
        public DateTimePicker datey;
        public System.Timers.Timer timer101;
        public DateTime current;
        public Button writebut;
        public TextBox message;
        public ListBox lstboxmsgdate;
        public Label openin2;
        public TextBox message2;
        public Label label2;
        public StreamWriter sw;
        public List<string> boxlist2;
        public Button readbut;
        public Form3()
        { //constructor method - same name as class
          // this is where the list of alarms will be...
          /*datetimeholder = new TextBox();
          datetimeholder.Size = new Size(200, 200);
          datetimeholder.Location = new Point(40, 40);
          DateTime now = new DateTime();
          now = DateTime.Now;
          datetimeholder.Text = now.ToString();
          */

            //the date time picker for alarm
            datey = new DateTimePicker();
            datey.Format = DateTimePickerFormat.Time;
            datey.Location = new Point(20, 40);
            datey.Size = new Size(48, 100);
            //the label for the alarm
            openin2 = new Label();
            openin2.Text = "Alarm System";
            openin2.Location = new Point(120, 20);



            //the button to save time
            Button currentbutton = new Button();
            currentbutton.Location = new Point(20, 60);
            currentbutton.Size = new Size(40, 40);
            currentbutton.Text = "Set Alarm";
            currentbutton.Click += new EventHandler(button_Click);
            //.Click for assigning an event handler to click

            boxlist = new List<string>();
            boxlist2 = new List<string>();
            //the listbox to store time
            listboxfortime = new ListBox();
            listboxfortime.Location = new Point(70, 80);
            listboxfortime.Size = new Size(60, 80);
            listboxfortime.DoubleClick += new EventHandler(doublist);
            //the textbox to allow you to enter a message
            message = new TextBox();
            message.Location = new Point(80, 40);
            message.Size = new Size(100, 100);
            message.Text = "Enter Text For Alarm here!";
            message.DoubleClick += new EventHandler(message_click);


            this.Controls.Add(listboxfortime);
            this.Controls.Add(currentbutton);
            this.Controls.Add(datey);
            this.Controls.Add(message);
            this.Controls.Add(openin2);


            timer101 = new System.Timers.Timer();
            timer101.Elapsed += OnTimedEvent; //from program intialisation, till it hits time interval
            timer101.Interval = 10000; //only execute once
            timer101.AutoReset = true;
            
            lstboxmsgdate = new ListBox();
            lstboxmsgdate.Location = new Point(130, 80);
            lstboxmsgdate.Size = new Size(150, 80);
            this.Controls.Add(lstboxmsgdate);

            message2 = new TextBox();
            message2.Location = new Point(25, 200);
            message2.Size = new Size(48, 40);
            message2.Text = datey.Value.ToShortTimeString();
            this.Controls.Add(message2);

            label2 = new Label();
            label2.Location = new Point(20, 180);
            label2.Size = new Size(90, 40);
            label2.Text = "Current Alarm";
            this.Controls.Add(label2);
            //button to read into the listbox
            readbut = new Button();
            readbut.Location = new Point(20, 100);
            readbut.Size = new Size(40, 40);
            readbut.Click += new EventHandler(readmethod);
            readbut.Text = "Load";
            this.Controls.Add(readbut);
            //button to write into the listbox
            writebut = new Button();
            writebut.Location = new Point(20, 140); //refers to location
            writebut.Size = new Size(40, 40);
            writebut.Click += new EventHandler(writemethod);
            writebut.Text = "Save";
            this.Controls.Add(writebut);











        }
        public void button_Click(object sender, EventArgs e)
        {//on button click, add the time to the listbox and to a list 
            timer101.Enabled = true;
            listboxfortime.Items.Add(datey.Value.ToShortTimeString());
            boxlist.Add(datey.Value.ToShortTimeString());
            lstboxmsgdate.Items.Add(datey.Value.ToShortDateString() + " - " + message.Text);
            boxlist2.Add(datey.Value.ToShortDateString() + " - " + message.Text);



        }
        public void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            now = new DateTime(); //new parameter allows for matching - when creating new instance, gets time
            now = DateTime.Now;
            now = now.AddSeconds(-now.Second); //to zero the second
            datey.Value = datey.Value.AddSeconds(-datey.Value.Second);



            if (now >= datey.Value)
            { //since it's always going to be either greater or equal, this will execute


                MessageBox.Show("Alarm! " + datey.Value.ToShortTimeString() + " - " + message.Text);




            }


        }

        public void doublist(object sender, EventArgs e)
        {
            datey.Value = Convert.ToDateTime(listboxfortime.SelectedItem);

            if (listboxfortime.SelectedIndex >= 0)
            {
                MessageBox.Show("Alarm " + listboxfortime.SelectedIndex.ToString() + " - " + listboxfortime.GetItemText(listboxfortime.SelectedItem) + "set");

            }

        }

        public void message_click(object sender, EventArgs e)
        {

            message.Text = "";

        }

        public void writemethod(object sender, EventArgs e)
        {

            //to writefile
            
            //if file exists, then create it at the path, and write everything in current listbox in there
            if (File.Exists(fullpath + @"\TimeManageFile1.txt") == false && File.Exists(fullpath + @"\TimeManageFile2.txt") == false)
            {
                System.IO.File.Create(fullpath + @"\TimeManageFile1.txt");
                System.IO.File.Create(fullpath + @"\TimeManageFile2.txt");

                System.IO.File.WriteAllLines(fullpath + @"\TimeManageFile1.txt", boxlist);
                System.IO.File.WriteAllLines(@fullpath + @"\TimeManageFile2.txt", boxlist2);
            }
            else{
                System.IO.File.WriteAllLines(fullpath + @"\TimeManageFile1.txt", boxlist);
                System.IO.File.WriteAllLines(fullpath + @"\TimeManageFile2.txt", boxlist2);
            }






        }


        public void readmethod(object sender, EventArgs e)
        {
            //to readfile
            using (StreamReader sr = new StreamReader(fullpath + @"\TimeManageFile1.txt"))
            {//read lines into the listbox
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listboxfortime.Items.Add(line);

                }


            }

            using (StreamReader sr = new StreamReader(fullpath + @"\TimeManageFile2.txt"))
            {
                string line2;
                while ((line2 = sr.ReadLine()) != null)
                {
                    lstboxmsgdate.Items.Add(line2);

                }


            }


        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());

        }
    }
}
