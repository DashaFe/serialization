using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООП_6
{
    public partial class Form2 : Form
    {
        public Form2(string name, int age, string adress, string group, Image img)
        {
            InitializeComponent();
            textBox1.Text = name;
            textBox2.Text = age.ToString();
            textBox3.Text = adress;
            textBox4.Text = group;
            pictureBox1.BackgroundImage = img;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
