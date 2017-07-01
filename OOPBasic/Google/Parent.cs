﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google
{
   public class Parent
   {
       private string name;
       private string birthday;

        public Parent(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name
       {
           get { return name; }
           set { name = value; }
       }

       public string Birthday
       {
           get { return birthday; }
           set { birthday = value; }
       }
   }
}
