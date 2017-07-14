using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSplit.Models.HardwareTypes
{
    public class HeavyHardware : Hardware
    {
        public HeavyHardware(string name, int capacity, int memory) : base(name, capacity, memory)
        {
            this.ModifyStats();
            this.Type = "Heavy";
        }

        public override void ModifyStats()
        {
            this.Capacity = (this.Capacity * Constants.HEAVY_HARDWARE_CAPACITY_PERCENTAGE_MODIFIER) /
                            100;
            this.Memory = this.Memory - (this.Memory * Constants.HEAVY_HARDWARE_MEMORY_PERCENTAGE_MODIFIER) / 100;
        }

        public override string ToString()
        {
            /*Hardware Component – {componentName}
  Express Software Components: {countOfExpressSoftwareComponents}
  Light Software Components: {countOfLightSoftwareComponents}
  Memory Usage: {memoryUsed} / {maximumMemory}
  Capacity Usage: {capacityUsed} / {maximumCapacity}
  Type: {Power/Heavy}
  Software Components: {softwareComponent1, softwareComponent2…}”

            */
            var sb = new StringBuilder();

            sb.AppendLine($"Hardware Component -  {this.Type}");
            sb.AppendLine($"Software Components: { softwareComponents.Count}");

            var maximumMemory = hardwareComponents.Select(h => h.Memory).Sum();
            var maximumCapacity = hardwareComponents.Select(h => h.Capacity).Sum();
            var totalOperationalMemoryInUse = softwareComponents.Select(s => s.MemoryConsumption).Sum();
            var totalCapacityTaken = softwareComponents.Select(s => s.CapacityConsumption).Sum();

            sb.AppendLine($"Total Operational Memory: {totalOperationalMemoryInUse} / {maximumMemory}");
            sb.AppendLine($"Total Capacity Taken: {totalCapacityTaken} / {maximumCapacity}");
            return base.ToString();
        }
    }
}