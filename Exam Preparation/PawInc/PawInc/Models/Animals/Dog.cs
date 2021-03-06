﻿using PawInc.Models.Centers;

namespace PawInc.Models.Animals
{
    public class Dog : Animal
    {
        private int amountOfCommands;

        public Dog(string name, int age, AdoptionCenter center, int amountOfCommands) : base(name, age, center)
        {
            this.AmountOfCommands = amountOfCommands;
        }

        public int AmountOfCommands
        {
            get { return amountOfCommands; }
            set { amountOfCommands = value; }
        }
    }
}