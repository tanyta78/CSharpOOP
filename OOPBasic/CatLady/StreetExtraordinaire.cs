namespace CatLady
{
    public class StreetExtraordinaire : Cat
    {
        private int decibelsOfMeows;

        public int DecibelsOfMeows
        {
            get { return decibelsOfMeows; }
            set { decibelsOfMeows = value; }
        }

        public override string ToString()
        {
            return $"{this.Breed} {this.Name} {this.DecibelsOfMeows}";
        }
    }
}