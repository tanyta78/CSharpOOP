using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawInc.Models.Centers;

namespace PawInc.Models
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private bool cleansingStatus;
        private AdoptionCenter center;
        private bool isAdopted;
        private bool isCastrated;

        public Animal(string name, int age, AdoptionCenter center)
        {
            this.Name = name;
            this.Age = age;
            this.Center = center;
            this.IsCastrated = false;
            this.IsAdopted = false;
            this.CleansingStatus = false;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public bool CleansingStatus
        {
            get { return cleansingStatus; }
            set { cleansingStatus = value; }
        }

        public AdoptionCenter Center
        {
            get { return center; }
            set { center = value; }
        }

        public bool IsAdopted
        {
            get { return isAdopted; }
            set { isAdopted = value; }
        }

        public bool IsCastrated
        {
            get { return isCastrated; }
            set { isCastrated = value; }
        }
    }
}