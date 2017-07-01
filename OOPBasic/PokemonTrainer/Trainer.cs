using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
   public class Trainer
   {
       private string name;
       private int badges;
       private List<Pokemon> playerPokemons;

        public Trainer(string name, List<Pokemon> playerPokemons)
        {
            this.Name = name;
            this.Badges = 0;
            this.PlayerPokemons = playerPokemons;
        }

        public string Name
       {
           get { return name; }
           set { name = value; }
       }

       public int Badges
       {
           get { return badges; }
           set { badges = value; }
       }

       public List<Pokemon> PlayerPokemons
       {
           get { return playerPokemons; }
           set { playerPokemons = value; }
       }
   }
}
