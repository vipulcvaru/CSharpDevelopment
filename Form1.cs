using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace CustomCalcii
{
    public partial class Form1 : Form
    {
        //Fields
        Double result = 0;
        string operation = string.Empty;
        string fstNum, secNum;
        bool enterValue = false;
        private double memoryValue = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void BtnMathOperationCick(object sender, EventArgs e)
        {
            if (result != 0) btnequals.PerformClick();
            else result = Double.Parse(txtDisplay1.Text);

            Button button = (Button)sender;
            operation = button.Text;
            enterValue = true;
            if(txtDisplay1.Text != "0")
            {
                txtDisplay2.Text = fstNum = $"{result}{operation}";
                txtDisplay1.Text = string.Empty;
            }

        }

        private void BtnEquals_Click(object sender, EventArgs e)
        {
            secNum = txtDisplay1.Text;
            txtDisplay2.Text = $"{txtDisplay2.Text} {txtDisplay1.Text} = ";
            if(txtDisplay1.Text != string.Empty)
            {
                if(txtDisplay1.Text == "0")txtDisplay2.Text = string.Empty;
                switch(operation)
                {
                    case "+":
                        txtDisplay1.Text = (result + Double.Parse(txtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum} = {txtDisplay1.Text}\n");
                        break;
                    case "__":
                        txtDisplay1.Text = (result - Double.Parse(txtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum} = {txtDisplay1.Text}\n");
                        break;
                    case "X":
                        txtDisplay1.Text = (result * Double.Parse(txtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum} = {txtDisplay1.Text}\n");
                        break;
                    case "÷":
                        txtDisplay1.Text = (result / Double.Parse(txtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum} = {txtDisplay1.Text}\n");
                        break;
                    
                    default:
                        {
                            txtDisplay2.Text = $"{txtDisplay1.Text} = ";

                            break;
                        }
                }

             result = Double.Parse(txtDisplay1.Text);
             operation = string.Empty;
            }

        }


        private void BtnClearHistory_Click(object sender, EventArgs e)
        {
            RtBoxDisplayHistory.Clear();
            if(RtBoxDisplayHistory.Text == string.Empty)
            {
                RtBoxDisplayHistory.Clear();
                if (RtBoxDisplayHistory.Text == string.Empty)
                    RtBoxDisplayHistory.Text = "There is no history !!!";
            }

        }

        private void btnHistory_Click_1(object sender, EventArgs e)
        {
            if (panelHistory.Height == 5)
            {
                panelHistory.Height = 345;
            }
            else
            {
                panelHistory.Height = 5;
            }

        }

        private void BtnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay1.Text.Length > 0)
                txtDisplay1.Text = txtDisplay1.Text.Remove(txtDisplay1.Text.Length - 1, 1);
            if (txtDisplay1.Text == string.Empty)
                txtDisplay1.Text = "0";

        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            txtDisplay1.Text = "0";
            txtDisplay2.Text = string.Empty;
            result = 0;
        }

        private void BtnCE_Click(object sender, EventArgs e)
        {
            txtDisplay1.Text = "0";
        }

        private void BtnOperations_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            switch(operation)
            {
                case "√X":
                    txtDisplay2.Text = $"√({txtDisplay1.Text})";
                    txtDisplay2.Text = Convert.ToString(Math.Sqrt(Double.Parse(txtDisplay1.Text)));

                    break;
                case "^2":
                    txtDisplay2.Text = $"({txtDisplay1.Text})^2 ";
                    txtDisplay2.Text = Convert.ToString(Convert.ToDouble(txtDisplay1.Text) * Convert.ToDouble(txtDisplay1.Text));

                    break;

                case "⅟x":
                    txtDisplay2.Text = $"(⅟{txtDisplay1.Text})";
                    txtDisplay2.Text = Convert.ToString(1.0 / Convert.ToDouble(txtDisplay1.Text));

                    break;
                case "%":
                    txtDisplay2.Text = $"%({txtDisplay1.Text})";
                    txtDisplay2.Text = Convert.ToString(Convert.ToDouble(txtDisplay1.Text) / Convert.ToDouble(100));

                    break;
                case "±":
                    txtDisplay2.Text = $"({txtDisplay1.Text})±";
                    txtDisplay2.Text = Convert.ToString(-1 * Convert.ToDouble(txtDisplay1.Text));

                    break;

            }
            RtBoxDisplayHistory.AppendText($"{txtDisplay2.Text}{txtDisplay1.Text}\n");
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void Click_Event(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Text)
            {
                case "MC":
                    // Memory Clear (MC) clears the memory value
                    memoryValue = 0;
                    break;
                case "MR":
                    // Memory Recall (MR) retrieves the stored memory value
                    txtDisplay1.Text = memoryValue.ToString();
                    break;
                case "M+":
                    // Memory Add (M+) adds the current display value to memory
                    memoryValue += double.Parse(txtDisplay1.Text);
                    break;
                case "M-":
                    // Memory Subtract (M-) subtracts the current display value from memory
                    memoryValue -= double.Parse(txtDisplay1.Text);
                    break;
                case "MS":
                    // Memory Store (MS) stores the current display value to memory
                    memoryValue = double.Parse(txtDisplay1.Text);
                    break;
                case "M~":
                    // Memory Invert (M~) inverts the sign of the memory value
                    memoryValue = -memoryValue;
                    break;
                default:
                    // Handle other buttons or provide a default case if needed
                    break;
            }
        }

    

        private void BtnNum_Click(object sender, EventArgs e)
        {
            if (txtDisplay1.Text == "0" || enterValue)
            {
                txtDisplay1.Text = string.Empty;
                enterValue = false;
            }
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!txtDisplay1.Text.Contains("."))
                    txtDisplay1.Text = txtDisplay1.Text + button.Text;
                    
            }
            else
            {
                txtDisplay1.Text = txtDisplay1.Text + button.Text;
            }


        }
    }
}
