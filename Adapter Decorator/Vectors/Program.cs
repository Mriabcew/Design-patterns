using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors.Vector2D_Model;
using Vectors.Vector3D_Model;

namespace Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IVector v1 = new _2DPolarInheritance(1, 2);
            IVector v2 = new _2DPolarInheritance(3, 4);
            IVector v3 = new _2DPolarInheritance(5, 6);


           Console.WriteLine("v1 Cartesian x= " + v1.getComponents()[0] + " y= " + v1.getComponents()[1] + "\n");
            Console.WriteLine("v1 Polar rho = " + v1.abs() + " fi= " + ((_2DPolarInheritance)v1).getAngle() + "\n");
            Console.WriteLine("v2 Cartesian x= " + v2.getComponents()[0] + " y= " + v2.getComponents()[1] + "\n");
            Console.WriteLine("v2 Polar rho = " + v2.abs() + " fi= " + ((_2DPolarInheritance)v2).getAngle() + "\n");
            Console.WriteLine("v3 Cartesian x= " + v3.getComponents()[0] + " y= " + v3.getComponents()[1] + "\n");
            Console.WriteLine("v3 Polar rho = " + v3.abs() + " fi= " + ((_2DPolarInheritance)v3).getAngle() + "\n\n");

            Console.WriteLine("v1 o v2 = " + v1.cdot(v2) + "\n");
            Console.WriteLine("v1 o v3 = " + v1.cdot(v3) + "\n");
            Console.WriteLine("v2 o v3 = " + v2.cdot(v3) + "\n\n");

            IVector v4 = new Vector3DDecorator(v1, 3);
            IVector v5 = new Vector3DDecorator(v2, 5);
            IVector v6 = new Vector3DDecorator(v3, 7);

            Console.WriteLine("v4 Cartesian x= " + v4.getComponents()[0] + " y= " + v4.getComponents()[1] + " z= " + v4.getComponents()[2] + "\n");
            Console.WriteLine("v5 Cartesian x= " + v5.getComponents()[0] + " y= " + v5.getComponents()[1] + " z= " + v5.getComponents()[2] + "\n");
            Console.WriteLine("v6 Cartesian x= " + v6.getComponents()[0] + " y= " + v6.getComponents()[1] + " z= " + v6.getComponents()[2] + "\n\n");

            Console.WriteLine("v4 o v5 = " + v4.cdot(v5) + "\n");
            Console.WriteLine("v4 o v6 = " + v4.cdot(v6) + "\n");
            Console.WriteLine("v5 o v6 = " + v5.cdot(v6) + "\n\n");

            IVector v7 = ((Vector3DDecorator)v4).cross(v5);
            IVector v8 = ((Vector3DDecorator)v5).cross(v4);
            IVector v9 = ((Vector3DDecorator)v4).cross(v6);
            IVector v10 = ((Vector3DDecorator)v6).cross(v4);
            IVector v11 = ((Vector3DDecorator)v5).cross(v6);
            IVector v12 = ((Vector3DDecorator)v6).cross(v5);

            Console.WriteLine("v4 x v5  x= " + v7.getComponents()[0] + " y= " + v7.getComponents()[1] + " z= " + v7.getComponents()[2] + "\n");
            Console.WriteLine("v5 x v4  x= " + v8.getComponents()[0] + " y= " + v8.getComponents()[1] + " z= " + v8.getComponents()[2] + "\n");
            Console.WriteLine("v4 x v6  x= " + v9.getComponents()[0] + " y= " + v9.getComponents()[1] + " z= " + v9.getComponents()[2] + "\n");
            Console.WriteLine("v6 x v4  x= " + v10.getComponents()[0] + " y= " + v10.getComponents()[1] + " z= " + v10.getComponents()[2] + "\n");
            Console.WriteLine("v5 x v6  x= " + v11.getComponents()[0] + " y= " + v11.getComponents()[1] + " z= " + v11.getComponents()[2] + "\n");
            Console.WriteLine("v6 x v5  x= " + v12.getComponents()[0] + " y= " + v12.getComponents()[1] + " z= " + v12.getComponents()[2] + "\n\n");



            Console.ReadLine();
        }
    }
}
