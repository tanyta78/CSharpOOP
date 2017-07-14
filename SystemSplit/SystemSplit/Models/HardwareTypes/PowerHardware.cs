using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSplit.Models.HardwareTypes
{
    public class PowerHardware : Hardware
    {
        public PowerHardware(string name, int capacity, int memory) : base(name, capacity, memory)
        {
            this.ModifyStats();
            this.Type = "Power";
        }

        public override void ModifyStats()
        {
            this.Capacity = this.Capacity - (this.Capacity * Constants.POWER_HARDWARE_CAPACITY_PERCENTAGE_MODIFIER) /
                            100;
            this.Memory = this.Memory + (this.Memory * Constants.POWER_HARDWARE_MEMORY_PERCENTAGE_MODIFIER) / 100;
        }
    }
}