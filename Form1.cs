
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        // This button browses for the file, and writes the file's path in the File Directory textbox.
        private void browse_Click(object sender, System.EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                fileDir_textBox.Text = filePath;

            }
        }

        // This button checks for the textboxes to be filled out. In case they're not, would prompt the user for an input.
        // Else, would save the textbox values in the params.txt file in MyDocuments folder and closes the window.
        private void ok_button_Click(object sender, EventArgs e)
        {
            if (practiceID_textBox.Text != "")
            {
                if (fileDir_textBox.Text != "")
                {

                    // Set a variable to the My Documents path.
                    string mydocpath =
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    // Write the params to a new file named "params.txt".
                    using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\param.txt"))
                    {
                            outputFile.WriteLine(practiceID_textBox.Text);
                            outputFile.WriteLine(fileDir_textBox.Text);

                            MessageBox.Show("A text file with the parameters has been created in MyDocuments folder.");
                            this.Close();
                    }


                }
                else {
                    MessageBox.Show ("Please enter the File Directory.");
                    return;
                }
            }
            else {
                MessageBox.Show("Please enter the Practice ID.");
                return;
            }
        }

        // This button closes the window
        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
