using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemSplit.Models;
using SystemSplit.Models.HardwareTypes;
using SystemSplit.Models.SoftwareTypes;

namespace SystemSplit.Controllers
{
    public class SystemBuilder
    {
        private List<Software> softwareComponents;
        private List<Hardware> hardwareComponents;

        public SystemBuilder()
        {
            this.hardwareComponents = new List<Hardware>();
            this.softwareComponents = new List<Software>();
        }

        public void RegisterPowerHardware(string name, int capacity, int memory)
        {
            PowerHardware powerHardware = new PowerHardware(name, capacity, memory);
            hardwareComponents.Add(powerHardware);
        }

        public void RegisterHeavyHardware(string name, int capacity, int memory)
        {
            HeavyHardware heavyHardware = new HeavyHardware(name, capacity, memory);
            hardwareComponents.Add(heavyHardware);
        }

        public void RegisterExpressSoftware(string hardwareComponentName, string name, int capacity, int memory)
        {
            ExpressSoftware expressSoftware = new ExpressSoftware(name, capacity, memory);
            var hardware = hardwareComponents.FirstOrDefault(h => h.Name == hardwareComponentName);
            if (hardware != null)
            {
                if (hardware.CanInstallSoftware(expressSoftware))
                {
                    hardware.InstallSoftware(expressSoftware);
                    softwareComponents.Add(expressSoftware);
                }
            }
        }

        public void RegisterLigthSoftware(string hardwareComponentName, string name, int capacity, int memory)
        {
            LightSoftware lightSoftware = new LightSoftware(name, capacity, memory);
            var hardware = hardwareComponents.FirstOrDefault(h => h.Name == hardwareComponentName);
            if (hardware != null)
            {
                if (hardware.CanInstallSoftware(lightSoftware))
                {
                    hardware.InstallSoftware(lightSoftware);
                    softwareComponents.Add(lightSoftware);
                }
            }
        }

        public void ReleaseSoftwareComponent(string hardwareComponentName, string softwareComponentName)
        {
            var hardware = hardwareComponents.FirstOrDefault(h => h.Name == hardwareComponentName);
            if (hardware != null)
            {
                var software = hardware.InstaledSoftwares.FirstOrDefault(s => s.Name == softwareComponentName);
                if (software != null)
                {
                    hardware.ReleaseSoftware(software);
                    softwareComponents.Remove(software);
                }
            }
        }

        public string Analyze()
        {
            var sb = new StringBuilder();
            sb.AppendLine("System Analysis");
            sb.AppendLine($"Hardware Components: {hardwareComponents.Count}");
            sb.AppendLine($"Software Components: { softwareComponents.Count}");

            var maximumMemory = hardwareComponents.Select(h => h.Memory).Sum();
            var maximumCapacity = hardwareComponents.Select(h => h.Capacity).Sum();
            var totalOperationalMemoryInUse = softwareComponents.Select(s => s.MemoryConsumption).Sum();
            var totalCapacityTaken = softwareComponents.Select(s => s.CapacityConsumption).Sum();

            sb.AppendLine($"Total Operational Memory: {totalOperationalMemoryInUse} / {maximumMemory}");
            sb.AppendLine($"Total Capacity Taken: {totalCapacityTaken} / {maximumCapacity}");

            return sb.ToString().Trim();
        }

        public string SystemInfo()
        {
            var sb = new StringBuilder();
            foreach (var hardwareComponent in hardwareComponents.OrderByDescending(c => c.Type))
            {
            }
            return sb.ToString().Trim();
        }
    }
}