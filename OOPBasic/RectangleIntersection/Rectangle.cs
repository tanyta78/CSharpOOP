
   using System;

public class Rectangle
   {

       private string id;
       private double width;
       private double height;
       private double topLeftX;
       private double topLeftY;

    public Rectangle(string id, double width, double height, double topLeftX, double topLeftY)
    {
        this.ID = id;
        this.Width = width;
        this.Height = height;
        this.TopLeftX = topLeftX;
        this.TopLeftY = topLeftY;
    }

    public string ID
       {
           get { return id; }
           set { id = value; }
       }

       public double Width
       {
           get { return width; }
           set { width = value; }
       }

       public double Height
       {
           get { return height; }
           set { height = value; }
       }

       public double TopLeftX
       {
           get { return topLeftX; }
           set { topLeftX = value; }
       }

       public double TopLeftY
       {
           get { return topLeftY; }
           set { topLeftY = value; }
       }

     public bool IsIntersect(Rectangle secondRect)
       {
           if (Math.Abs(this.TopLeftX) < Math.Abs(secondRect.TopLeftX + secondRect.Width)
               && Math.Abs(this.TopLeftX + this.Width) >= Math.Abs(secondRect.TopLeftX)
               && Math.Abs( this.TopLeftY) < Math.Abs(secondRect.TopLeftY + secondRect.Height)
               && Math.Abs( this.TopLeftY + this.Height) >= Math.Abs(secondRect.TopLeftY))
           {
               return true;
           }
           else
           {
               return false;
           }
           
       }
   }

