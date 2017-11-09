namespace SystemSplit.Models.SoftwareTypes
{
    public class ExpressSoftware : Software
    {
        public ExpressSoftware(string name, int capacityConsumption, int memoryConsumption) : base(name, capacityConsumption, memoryConsumption)
        {
            this.ModifyStats();
            this.Type = "Express";
        }

        public override void ModifyStats()
        {
            this.MemoryConsumption = this.MemoryConsumption *
                                     Constants.EXPRESS_SOFTWARE_MEMORY_CONSUMPTION_PERCENTAGE_MODIFIER / 100;
        }
    }
}