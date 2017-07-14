using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSplit.Models
{
    public abstract class Software
    {
        private string name;
        private int capacityConsumption;
        private int memoryConsumption;

        public Software(string name, int capacityConsumption, int memoryConsumption)
        {
            this.Name = name;
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int CapacityConsumption
        {
            get { return capacityConsumption; }
            set { capacityConsumption = value; }
        }

        public int MemoryConsumption
        {
            get { return memoryConsumption; }
            set { memoryConsumption = value; }
        }

        public abstract void ModifyStats();
    }
}