using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSplit.Models.SoftwareTypes
{
    public class ExpressSoftware : Software
    {
        public ExpressSoftware(string name, int capacityConsumption, int memoryConsumption) : base(name, capacityConsumption, memoryConsumption)
        {
            this.ModifyStats();
        }

        public override void ModifyStats()
        {
            this.MemoryConsumption = this.MemoryConsumption *
                                     Constants.EXPRESS_SOFTWARE_MEMORY_CONSUMPTION_PERCENTAGE_MODIFIER / 100;
        }
    }
}