namespace SystemSplit.Models.SoftwareTypes
{
    public class LightSoftware : Software
    {
        public LightSoftware(string name, int capacityConsumption, int memoryConsumption) : base(name, capacityConsumption, memoryConsumption)
        {
            this.ModifyStats();
            this.Type = "Light";
        }

        public override void ModifyStats()
        {
            this.CapacityConsumption = this.CapacityConsumption +
                                       this.CapacityConsumption *
                                       Constants.LIGTH_SOFTWARE_CAPACITY_CONSUMPTION_PERCENTAGE_MODIFIER / 100;
            this.MemoryConsumption = this.MemoryConsumption -
                                     this.MemoryConsumption *
                                     Constants.LIGTH_SOFTWARE_MEMORY_CONSUMPTION_PERCENTAGE_MODIFIER / 100;
        }
    }
}