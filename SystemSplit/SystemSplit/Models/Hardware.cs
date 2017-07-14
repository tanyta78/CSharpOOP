using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSplit.Models
{
    public abstract class Hardware
    {
        private string name;
        private int capacity;
        private int memory;
        private string type;
        private List<Software> instaledSoftwares;

        public Hardware(string name, int capacity, int memory)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Memory = memory;
            this.InstaledSoftwares = new List<Software>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Memory
        {
            get { return memory; }
            set { memory = value; }
        }

        public List<Software> InstaledSoftwares
        {
            get { return instaledSoftwares; }
            set { instaledSoftwares = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public abstract void ModifyStats();

        public virtual bool CanInstallSoftware(Software software)
        {
            if (this.Capacity >= software.CapacityConsumption && this.Memory >= software.MemoryConsumption)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void InstallSoftware(Software software)
        {
            this.InstaledSoftwares.Add(software);
            this.Capacity -= software.CapacityConsumption;
            this.Memory -= software.MemoryConsumption;
        }

        public virtual void ReleaseSoftware(Software software)
        {
            this.InstaledSoftwares.Remove(software);
            this.Capacity += software.CapacityConsumption;
            this.Memory += software.MemoryConsumption;
        }
    }
}