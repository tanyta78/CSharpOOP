using System.Collections.Generic;

namespace Google
{
    internal class Person
    {
        private string name;
        private Company company;
        private Car car;
        private List<Parent> parents;
        private List<Child> children;
        private List<Pokemon> pokemons;

        public Person(string name, Company company, Car car, List<Parent> parents, List<Child> children, List<Pokemon> pokemons)
        {
            this.Name = name;
            this.CompanyOwned = company;
            this.CarOwned = car;
            this.Parents = parents;
            this.Children = children;
            this.Pokemons = pokemons;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Company CompanyOwned
        {
            get { return company; }
            set { company = value; }
        }

        public Car CarOwned
        {
            get { return car; }
            set { car = value; }
        }

        public List<Parent> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

        public List<Child> Children
        {
            get { return children; }
            set { children = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public Person(string name)
        {
            this.Name = name;
            this.Parents=new List<Parent>();
            this.Children=new List<Child>();
            this.Pokemons = new List<Pokemon>();
        }

        public override string ToString()
        {
            return $"{this.Name}\nCompany:\n{this.CompanyOwned.ToString()}\nCar:\n{this.CarOwned.ToString()}\nPokemon:\n{this.Pokemons.ToString()}\nParents:\n{ this.Parents.ToString()}\nChildren:\n{this.Children.ToString()}";
        }
    }
}