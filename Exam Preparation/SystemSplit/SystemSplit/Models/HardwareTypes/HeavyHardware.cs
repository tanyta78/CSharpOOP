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
    }
}