using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp2
{
    public class Form2 : Form
    {/* when creating apps
        do the following:
        control name = new <control>;
        do size
        do location
        do text
        do tag
        do event handler
        this.Controls.Add(control name)
        */
        public string input = "";
        public List<int> storagecontainer = new List<int>();
        public Button clearButton;
        public Button plusButton;
        public Button minusButton;
        public Button multiButton;
        public Button divButton;
        public Button equalButton;
        public TextBox input1;//always add new objects before constructor
        public Button newButton;
        public List<string> operatorlst = new List<string>();
        public Form2() //is constructer, not a method - below is the things that are used for construction
        {
            
            List<object> ListForButtons = new List<object>();
            input1 = new TextBox();
            input1.Size = new Size(120, 40);
            input1.Location = new Point(40, 0);//always declare new
            
            plusButton = new Button();
            plusButton.Size = new Size(40, 40);
            plusButton.Text = "+";
            plusButton.Location = new Point(160, 40);
            plusButton.Click += new EventHandler(plusClick);

            minusButton = new Button();
            minusButton.Size = new Size(40, 40);
            minusButton.Text = "-";
            minusButton.Location = new Point(160, 80);
            minusButton.Click += new EventHandler(minusClick);

            multiButton = new Button();
            multiButton.Size = new Size(40, 40);
            multiButton.Text = "*";
            multiButton.Location = new Point(160, 120);
            multiButton.Click += new EventHandler(multiClick);

            divButton = new Button();
            divButton.Size = new Size(40, 40);
            divButton.Text = "/";
            divButton.Location = new Point(160, 160);
            divButton.Click += new EventHandler(divClick);

            equalButton = new Button();
            equalButton.Size = new Size(40, 40);
            equalButton.Text = "=";
            equalButton.Location = new Point(200, 200);
            equalButton.Click += new EventHandler(button2_Click);

            clearButton = new Button();
            clearButton.Size = new Size(40, 40);
            clearButton.Text = "C";
            clearButton.Location = new Point(160, 220);
            clearButton.Click += new EventHandler(clear_Click);

            int y = 0; //counter varialbes
            int b = 0;
            int n = 0;
            for (int i = 1; i < 10; i++)
            {
                newButton = new Button();
                newButton.Size = new Size(40, 40);
                if (i < 4)
                {
                    y++;
                    newButton.Location = new Point(40 * y, 40); //x axis needs to be reset every 3 numbers put down
                    newButton.Text = i.ToString(); //hence by using counter, we can do this
                    newButton.Tag = i;
                    newButton.Click += new EventHandler(button_Click);              
                    ListForButtons.Add(newButton.Tag); //to keep track of objects


                }
                else if (i > 3 && i < 7)
                {
                    b++;
                    newButton.Location = new Point(40 * b, 80);
                    newButton.Text = i.ToString();
                    newButton.Tag = i;
                    newButton.Click += new EventHandler(button_Click);              
                    ListForButtons.Add(newButton.Tag);



                }
                else if (i > 6 && i < 10)
                {
                    n++;
                    newButton.Location = new Point(40 * n, 120);
                    newButton.Text = i.ToString();
                    newButton.Tag = i;
                    newButton.Click += new EventHandler(button_Click);              //gives single event handler to buttons, use this method
                    ListForButtons.Add(newButton.Tag);

                }


                
                this.Controls.Add(newButton); //to add everything to the calc
                this.Controls.Add(input1);
                this.Controls.Add(plusButton);
                this.Controls.Add(minusButton);
                this.Controls.Add(multiButton);
                this.Controls.Add(divButton);
                this.Controls.Add(equalButton);
                this.Controls.Add(clearButton);
                Console.WriteLine(ListForButtons);


            }
        }



        public void button_Click(object sender, EventArgs e)
        {
        
            Button btn = sender as Button;
            input1.Text += btn.Text;
            input += btn.Text;









        }

        public void clear_Click(object sender, EventArgs e)
        {
            storagecontainer.Clear();
            operatorlst.Clear();
            input1.Text = "";


        }
        public void button2_Click(object sender, EventArgs e)
        
        {
            input1.Text = input1.Text.Substring(1);
            int input = Convert.ToInt32(input1.Text);
            storagecontainer.Add(input); 
            int op1 = storagecontainer[0];
            int op2 = storagecontainer[1];
                if (operatorlst[0] == "+") //the way that it takes the input, is through using an array, with split strings rather like expression parsers for strings
                {
                    input1.Text = (op1 + op2).ToString();
                }

                if (operatorlst[0] == "-")
                {
                    input1.Text = (op1 - op2).ToString();
                }
                if (operatorlst[0] == "*")
                {
                    input1.Text = (op1 * op2).ToString();
                }
                if (operatorlst[0] == "/")
                {
                    input1.Text = (op1 / op2).ToString();
                }



            
            
            




            }

        public void plusClick(object sender, EventArgs e) //below are all the bits for when you click on an opeartional button
        {
            int input = Convert.ToInt32(input1.Text);
            storagecontainer.Add(input); //storage container is used for adding input to parse
            Button btn = sender as Button;
            input1.Text = "";
            input1.Text += btn.Text;
            operatorlst.Add(btn.Text);




        }

        public void minusClick(object sender, EventArgs e)
        {
            int input = Convert.ToInt32(input1.Text);
            storagecontainer.Add(input); 
            Button btn = sender as Button;
            input1.Text = "";
            input1.Text += btn.Text;
            operatorlst.Add(btn.Text);
            




        }

        public void multiClick(object sender, EventArgs e)
        {
            int input = Convert.ToInt32(input1.Text);
            storagecontainer.Add(input); //btn text was the true savior
            Button btn = sender as Button;
            input1.Text = "";
            input1.Text += btn.Text;
            operatorlst.Add(btn.Text);




        }

        public void divClick(object sender, EventArgs e)
        {
            int input = Convert.ToInt32(input1.Text);
            storagecontainer.Add(input); //btn text was the true savior
            Button btn = sender as Button;
            input1.Text = "";
            input1.Text += btn.Text;
            operatorlst.Add(btn.Text);




        }





























        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}
