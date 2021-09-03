using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ООП_6
{
    [Serializable]
    class Person
    {
        private string name;
        private int age;
        private string adress;
        private string group;
        private Image photo;

        public Person(string name, int age, string adress, string group, Image photo)
        {
            this.name = name;
            this.age = age;
            this.adress = adress;
            this.group = group;
            this.photo = photo;
        }

        public string Name { get { return name; } }
        public int Age { get { return age; } }
        public string Adress { get { return adress; } }
        public string Group { get { return group; } }
        public Image Photo { get { return photo; } }


    }
}
