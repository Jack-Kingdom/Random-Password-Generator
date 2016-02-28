using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Random_password_generator
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		//type equal to 1 return random username, equal to 2 return random password
		public string random_generator(int type, int Length)
		{
			var R = new Random();
			string result = "";
			if (type == 1)
			{
				//Username string contains digit and alphabet:0~9 and A~z
				while (result.Length < Length)
				{
					int character = R.Next(48, 122);
					if ((character >= 58 && character < 65) || (character >= 91 && character < 97))
					{
						//fliter character not in set of digit and alphabet
						continue;
					}
					else
					{
						result += Convert.ToChar(character);
					}
				}
			}
			else if (type == 2)
			{
				//Password string contains all printable character
				while (result.Length < Length)
				{
					int character = R.Next(33, 127);
					result += Convert.ToChar(character);
				}
			}
			return result;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox2.Text = random_generator(1, Convert.ToInt32(numericUpDown1.Value));
			textBox3.Text = random_generator(2, Convert.ToInt32(numericUpDown2.Value));
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//save Username and password to a text file
			DialogResult dialogResult = MessageBox.Show("Are you sure?", "Make sure", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				StreamWriter sw = File.AppendText("RPG keys.txt");
				string line = "Symbol:" + textBox1.Text + "\t" + "Username:" + textBox2.Text + "\t" + "Password:" + textBox3.Text + "\n";
				sw.WriteLine(line);
				sw.Close();
			}
		}
	}
}
