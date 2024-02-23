using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipBoardApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Copy Button
            string t1 = textBox1.Text;
            
            if(!string.IsNullOrEmpty(t1))
            {
                try
                {
                    Clipboard.SetText(t1);

                    ToolTip ct = new ToolTip();
                    ct.ToolTipTitle = "Text Copied !!";
                    ct.UseFading = true;
                    ct.UseAnimation = true;
                    ct.IsBalloon = true;
                    ct.ShowAlways = true;

                    ct.AutoPopDelay = 5000;
                    ct.InitialDelay = 1000;
                    ct.ReshowDelay = 500;

                    ct.SetToolTip(button1, ct.ToolTipTitle);

                    MessageBox.Show("Text Copied To ClipBoard", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("An Error Occured While Copying Text To Clipboard" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Enter The Text in The textBox !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Paste Button
            if(Clipboard.ContainsText())
            {
                string cliptext = Clipboard.GetText();
                textBox2.Text = cliptext;

                ToolTip pt = new ToolTip();
                pt.ToolTipTitle = "Text Pasted !!";
                pt.UseFading = true;
                pt.UseAnimation = true;
                pt.IsBalloon = true;
                pt.ShowAlways = true;

                pt.AutoPopDelay = 5000;
                pt.InitialDelay = 1000;
                pt.ReshowDelay = 500;

                pt.SetToolTip(button2, pt.ToolTipTitle);

                MessageBox.Show("Sucessfully Pasted The Copied Text", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Oops!! You Did't Copied Any Text", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool close = true;
        private void button3_Click(object sender, EventArgs e)
        {
            // Exit Button
            if (close)
            {
                DialogResult result = MessageBox.Show(" Are You Sure Want To Exit ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    close = false;
                    Application.Exit();
                }
                else
                {
                    close = true;
                }
            }
        }
    }
}
