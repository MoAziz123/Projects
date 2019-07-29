using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Drawing;
using System.Data.SqlClient;
using System.Runtime;
using System.Windows.Forms.VisualStyles;
using System.Drawing.Text;
using System.Security.Cryptography;

namespace WindowsFormsApp4
{


    public class Register : Form
    {
        public TextBox logon;
        public TextBox pass;
        public Label loginlab;
        public Label loginpass;
        public Label register;
        public Button registerbut;

        public Register()
        {


            Label register = new Label();
            register.Text = "Enter details below to register.";
            register.Location = new Point(100, 20);
            this.Controls.Add(register);

            Button registerbut = new Button();
            registerbut.Text = "Register";
            registerbut.Location = new Point(120, 150);
            registerbut.Size = new Size(80, 40);
            registerbut.Click += new EventHandler(registering);
            this.Controls.Add(registerbut);

            
            pass = new TextBox();
            pass.Size = new Size(100, 40);
            pass.Location = new Point(110, 100);
            this.Controls.Add(pass);
            //when using values to compare, remove the TextBox and stuff - already intialized in public

            logon = new TextBox();
            logon.Size = new Size(100, 40);
            logon.Location = new Point(110, 50);
            this.Controls.Add(logon);

            Label loginlab = new Label();
            loginlab.Text = "New Username: ";
            loginlab.Location = new Point(25, 50);
            this.Controls.Add(loginlab);

            Label loginpass = new Label();
            loginpass.Text = "New Password: ";
            loginpass.Location = new Point(25, 100);
            this.Controls.Add(loginpass);


            


        }

        public void registering(object sender, EventArgs e)
        {
            

            string register1user = logon.Text;
            string register1pass = pass.Text;
            byte[] register1user1= Encoding.ASCII.GetBytes(register1user); //temporary encryption
            byte[] register1pass1 = Encoding.ASCII.GetBytes(register1pass);
            


            SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;");
            conn.Open();
            SqlCommand command = new SqlCommand("INSERT INTO userpass VALUES('" + register1user1 + "','" + register1pass1 + "');", conn);
            command.ExecuteNonQuery();
        }


    }
    public class LogIn : Form
    {

        public string username;
        public bool switcher = true;
        public Form Program;
        public Button login;
        public TextBox logon;
        public TextBox pass;
        public Panel pan;
        public Label loginlab;
        public Button maximise;
        public Button close;
        public Button minimize;
        public Label loginpass;
        public LogIn()
        {
            this.Size = new Size(300,300);
            this.BackColor = Color.FromArgb(51, 55, 51);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Font = new Font("Calibri",8, FontStyle.Regular); //sets font
            


            this.IsMdiContainer = false; //this will create a form within the form
            Button login = new Button();
            login.Text = "Log In";
            login.Location = new Point(120, 150);//to fix object reference error, remove the TextBox when intialized, and make it public on top of the constructor
            login.Click += new EventHandler(logged);
            login.FlatStyle = FlatStyle.Flat;
            


            pan = new Panel();
            Label panlabel = new Label();
            panlabel.Text = "Chatroom LogIn";
            panlabel.Location = new Point(18, 10);
            panlabel.Font = new Font("Segoe UI", 8, FontStyle.Bold);


            this.Controls.Add(panlabel);
            pan.Location = new Point(0, 0);
            pan.Size = new Size(this.Width, this.Height / 9);
            pan.BackColor = this.BackColor ;
            
            pan.MouseMove += new MouseEventHandler(onmousemove); //allows to drag window

            minimize = new Button();
            minimize.Location = new Point(this.Width - 120, 0);
            minimize.Size = new Size(30, 30);
            minimize.Text = "_";
            this.Controls.Add(minimize);
            minimize.FlatStyle = FlatStyle.Flat;
            minimize.FlatAppearance.BorderSize = 0;
            minimize.Click += new EventHandler(minimizebox);
            

            maximise = new Button();
            maximise.Location = new Point(this.Width - 80, 0);
            maximise.Size = new Size(30, 30);
            maximise.Text = "\u25A1"; //unicode characters
            maximise.FlatStyle = FlatStyle.Flat; //changes border style
            maximise.FlatAppearance.BorderSize = 0; //flatappearance allows changes to the border color and size

            this.Controls.Add(maximise);
            maximise.Click += new EventHandler(maximisebox);
            

            close = new Button();
            close.Size = new Size(30, 30);
            close.Text = "\u2715";
            close.FlatStyle = FlatStyle.Flat;
            close.FlatAppearance.BorderSize = 0; //removes border
            close.Location = new Point(this.Width - 40, 0);
            this.Controls.Add(close);
            close.Click += new EventHandler(closebox);
            

            minimize.MouseEnter += new EventHandler(OnHover);
            maximise.MouseEnter += new EventHandler(OnHover);
            close.MouseEnter += new EventHandler(OnHover);

            minimize.MouseLeave += new EventHandler(OnHover);
            maximise.MouseLeave += new EventHandler(OnHover);
            close.MouseLeave += new EventHandler(OnHover);
            this.Controls.Add(pan); //empty space to use

            this.Controls.Add(login);

            logon = new TextBox();
            logon.Size = new Size(100, 40);
            logon.Location = new Point(110, 50);
            logon.BackColor = Color.FromArgb(43, 43, 43);
            logon.BorderStyle = BorderStyle.FixedSingle;
            logon.ForeColor = Color.White;
            this.Controls.Add(logon);
            
            

            pass = new TextBox();
            pass.PasswordChar = '*';
            pass.Size = new Size(100, 40);
            pass.Location = new Point(110, 100);
            pass.BackColor = logon.BackColor;
            pass.ForeColor = Color.White;
            pass.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(pass);
            //when using values to compare, remove the TextBox and stuff - already intialized in public

            Label loginlab = new Label();
            loginlab.Text = "Username: ";
            loginlab.Location = new Point(50, 50);
            this.Controls.Add(loginlab);

            Label loginpass = new Label();
            loginpass.Text = "Password: ";
            loginpass.Location = new Point(50, 100);
            this.Controls.Add(loginpass);
            



        }
        public void OnHover(object sender, EventArgs e)
        {

            var send = sender as Button; //using sender as type will change the type, so that you can access the type of the sender
            if(switcher == true)
            {
                

                send.ForeColor = Color.Black;
                send.BackColor = Color.White;
                switcher = false;
            }
            else
            {
                send.ForeColor = this.ForeColor;
                send.BackColor = this.BackColor;
                switcher = true;


            }


            



        }
        public void onmousemove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Location = new Point(Cursor.Position.X, Cursor.Position.Y); //every time you move mouse, whilst you hold down left click, it will move it according to cursor position



            }



        }
        public void closebox(object sender, EventArgs e)
        {
            this.Close();



        }

        public void maximisebox(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                pan.Width = 1600;
                this.WindowState = FormWindowState.Maximized;
                close.Location = new Point(close.Location.X + pan.Width, close.Location.Y);
                minimize.Location = new Point(minimize.Location.X +pan.Width, minimize.Location.Y);
                maximise.Location = new Point(maximise.Location.X +pan.Width, maximise.Location.Y);
                

            }
            else
            {
                pan.Width = this.Width;
                this.WindowState = FormWindowState.Normal;
                close.Location = close.Location;
                minimize.Location = minimize.Location;
                maximise.Location = maximise.Location;

            }


        }

        public void minimizebox(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;


        }
        public void logged(object sender, EventArgs e)
        {


                username = logon.Text;
                
                //to add each new password to the DB
                SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;");
                conn.Open();
            /*SqlCommand command = new SqlCommand("INSERT INTO userpass VALUES('" + username + "','" + pass.Text + "');", conn);
            command.ExecuteNonQuery();*/
            SqlCommand reading = new SqlCommand("SELECT * from userpass;", conn);
            SqlDataReader reader = reading.ExecuteReader();
            while (reader.Read()) //could use for loop to iterate through, with manual advancement of records
            {
                int clmn1cnt = 0;
                int clmn2cnt = 1;
                if (username.ToString() == (string)reader[clmn1cnt] && pass.Text.ToString() == (string)reader[clmn2cnt])
                {
                    this.Hide(); //hiding first will ensure that you run new program, and hides the log in
                    Form Program = new Program(username);
                    Program.ShowDialog(); //this will create the form outside the form, can't use app run because creates second message loop
                    break;


                }


                break;



            }

            Form Register = new Register();
            Register.ShowDialog();



        }

       

    }
    public class Program:Form1
    {
        public byte[] recvbuffer;
        
        public Socket socket;
        public Button sendbut;
        public Label entrymessage;
        public Label entrymessageport;
        public TextBox entryforport;
        public TextBox entryforhost;
        public TextBox message;
        public string host;
        public int port;
        public ListBox boxformessage;
        public string username;
        
        public Button connectionbut;
        public Program(string username) //pass by reference - means that it will pass to the program
        {
            
            
            this.Size = new System.Drawing.Size(400, 500); //when doing this - allows you to change master
            
            boxformessage = new ListBox(); //changing master, because it will make UI more clean
            boxformessage.Size = new System.Drawing.Size(300, 300); //listbox here is used to store message, using because it's easier to bind to data source
            boxformessage.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(boxformessage);

            connectionbut = new Button();
            connectionbut.Size = new System.Drawing.Size(80, 30);
            connectionbut.Text = "Connect";
            connectionbut.Location = new System.Drawing.Point(20, 320);
            connectionbut.Click += new EventHandler(connect);
            this.Controls.Add(connectionbut);

            entryforhost = new TextBox();
            entryforhost.Size = new System.Drawing.Size(50, 80);
            entryforhost.Location = new System.Drawing.Point(150, 320);
            this.Controls.Add(entryforhost);

            entrymessage = new Label();
            entrymessage.Text = "Host:";
            entrymessage.Location = new System.Drawing.Point(120, 320);
            this.Controls.Add(entrymessage);

            entryforport = new TextBox();
            entryforport.Size = new System.Drawing.Size(50, 80);
            entryforport.Location = new System.Drawing.Point(250, 320);
            this.Controls.Add(entryforport);

            entrymessageport = new Label();
            entrymessageport.Text = "Port:";
            entrymessageport.Location = new System.Drawing.Point(220, 320);
            this.Controls.Add(entrymessageport);

            sendbut = new Button();
            sendbut.Size = new System.Drawing.Size(80, 30);
            sendbut.Text = "Send";
            sendbut.Location = new System.Drawing.Point(300, 420);
            sendbut.Click += new EventHandler(send);
            this.Controls.Add(sendbut);


            message = new TextBox();
            message.Size = new System.Drawing.Size(300, 50);
            message.Location = new System.Drawing.Point(20, 400);
            message.Text = "Enter message to send here!";
            this.Controls.Add(message);
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
 
            













        }

        public void connect(object sender, EventArgs e)
        {
            if (host == "")
            {
                host = Dns.GetHostName();
            }
            else
            {
                host = entryforhost.Text;
            }

            //gets local host
            
            if (port.ToString() == "")
            {
                port = 2440;

            }
            else
            {

                port = Convert.ToInt32(entryforport.Text);
            }
            socket.Connect(host, port);
            if (socket.Connected)
            {

                boxformessage.Items.Add("Connection accepted!");//connects to host and port

            }




        }

        public void send(object sender, EventArgs e)
        {
            LogIn loggo = new LogIn();
            
            //allows you to get variables from other classes - remmeber than a new class instance is like a type - need to declare
            //with static var, it shares the same thing throughout new instances
            //won't be same with DB, because DB will use connections and stuff, that all classes can connect to
            
            byte[] messagetransfer = Encoding.ASCII.GetBytes(username + ": "+ message.Text);
            byte[] recvbuffer = new byte[2048];
            socket.Send(messagetransfer);
            socket.Receive(recvbuffer);
             //assign new string to variable
            string answer = new string(Encoding.ASCII.GetChars(recvbuffer)); //since it's character array, listbox will interpret as that
            boxformessage.Items.Add(answer);    

            



        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
        
        }
    }
}
