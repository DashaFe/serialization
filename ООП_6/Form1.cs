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
using System.Runtime.Serialization.Formatters.Binary;

namespace ООП_6
{

    public partial class Form1 : Form
    {

        List<Person> people = new List<Person>();
        BinaryFormatter format = new BinaryFormatter();

        public Form1()
        {
            InitializeComponent();
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                    people = (List<Person>)format.Deserialize(fs);
            }
            for (int i = 0; i < people.Count; i++)
            {
                listBox1.Items.Add(people[i].Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                pictureBox1.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        public void Cl()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            pictureBox1.BackgroundImage = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Invalid format for entering the field: Name");
                return;
            }
            if (textBox2.TextLength == 0)
            {
                MessageBox.Show("Invalid format for entering the field: Age");
                return;
            }
            if (textBox3.TextLength == 0)
            {
                MessageBox.Show("Invalid format for entering the field: Adress");
                return;
            }
            if (textBox4.TextLength == 0)
            {
                MessageBox.Show("Invalid format for entering the field: Groupe");
                return;
            }
            people.Add(new Person(textBox1.Text, int.Parse(textBox2.Text), textBox3.Text, textBox4.Text, pictureBox1.BackgroundImage));
            listBox1.Items.Add(people[people.Count - 1].Name);
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                format.Serialize(fs, people);
            }
            Cl();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(people[listBox1.SelectedIndex].Name, people[listBox1.SelectedIndex].Age, people[listBox1.SelectedIndex].Adress, people[listBox1.SelectedIndex].Group, people[listBox1.SelectedIndex].Photo);
            form2.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            people.Remove(people[listBox1.SelectedIndex]);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                format.Serialize(fs, people);

            }
        }
    }
}
