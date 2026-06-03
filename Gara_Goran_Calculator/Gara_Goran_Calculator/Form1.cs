using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gara_Goran_Calculator
{
    public partial class Calculator : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            resultValue = 0;
            operationPerformed = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            resultValue = 0;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);

            if (textBox1.Text == "")
                textBox1.Text = "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            double val = Double.Parse(textBox1.Text);
            textBox1.Text = (val * -1).ToString();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    textBox1.Text = (resultValue + double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (resultValue - double.Parse(textBox1.Text)).ToString();
                    break;
                case "*":
                    textBox1.Text = (resultValue * double.Parse(textBox1.Text)).ToString();
                    break;
                case "/":
                    textBox1.Text = (resultValue / double.Parse(textBox1.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = double.Parse(textBox1.Text);
            operationPerformed = "";
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0") ||
                     (isOperationPerformed))
                textBox1.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;

            if(button.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                 textBox1.Text = textBox1.Text + button.Text;    
            }
            else
            {
                textBox1.Text = textBox1.Text + button.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                button19.PerformClick(); 
                operationPerformed = button.Text;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = double.Parse(textBox1.Text);
                isOperationPerformed = true;
            }
        }
    }
}
