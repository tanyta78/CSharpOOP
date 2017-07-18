namespace CatLady
{
    public class Siamese : Cat
    {
        private int earSize;

        public int EarSize
        {
            get { return earSize; }
            set { earSize = value; }
        }

        public override string ToString()
        {
            return $"{this.Breed} {this.Name} {this.EarSize}";
        }
    }
}