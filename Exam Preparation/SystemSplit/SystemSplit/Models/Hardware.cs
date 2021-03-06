﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public virtual int Capacity
        {
            get { return capacity; }
            protected set { capacity = value; }
        }

        public virtual int Memory
        {
            get { return memory; }
            protected set { memory = value; }
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

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Hardware Component - {this.Name}");

            var expressSoftwareComponents = this.InstaledSoftwares.Where(c => c.Type == "Express").ToList();
            var lightSoftwareComponents = this.InstaledSoftwares.Where(c => c.Type == "Light").ToList();

            sb.AppendLine($"Express Software Components - {expressSoftwareComponents.Count}");
            sb.AppendLine($"Light Software Components - {lightSoftwareComponents.Count}");

            var maximumMemory = this.Memory;
            var maximumCapacity = this.Capacity;
            var memoryUsed = this.InstaledSoftwares.Select(s => s.MemoryConsumption).Sum();
            var capacityUsed = this.InstaledSoftwares.Select(s => s.CapacityConsumption).Sum();
            sb.AppendLine($"Memory Usage: {memoryUsed} / {maximumMemory + memoryUsed}");
            sb.AppendLine($"Capacity Usage: {capacityUsed} / {maximumCapacity + capacityUsed}");

            sb.AppendLine($"Type: {this.Type}");
            sb.AppendLine($"Software Components: {string.Join(", ", InstaledSoftwares.Select(s => s.Name))}");

            return sb.ToString().Trim();
        }
    }
}