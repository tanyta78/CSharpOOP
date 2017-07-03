﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
   public class Topping
   {

       private string type;
       private double weight;

       private const int MinWeight = 1;
       private const int MaxWeight = 50;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
       {
           get { return this.type; }
            set
            {
                if (value.ToLower()!="meat" && value.ToLower() != "veggies"&& value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }


                this.type = value;
            }
       }

       public double Weight
       {
           get { return this.weight; }
           set
           {
               if (value<MinWeight || value>MaxWeight)
               {
                   throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
               }

                this.weight = value;
           }
       }

       private double GetTypeMod()
       {
           if (this.Type.ToLower()=="meat")
           {
               return 1.2;
           }
          else if (this.Type.ToLower() == "veggies")
           {
               return 0.8;
           }
           else if (this.Type.ToLower() == "cheese")
           {
               return 1.1;
           }
           
               return 0.9;
           
        }

       public double GetCalories()
       {
           return 2 * Weight * this.GetTypeMod();
       }
   }
}
