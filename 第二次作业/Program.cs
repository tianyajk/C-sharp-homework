using System;
using System.Collections.Generic;

// 抽象形状类，定义公共接口
public abstract class Shape
{
    // 抽象方法：计算面积
    public abstract double GetArea();
    // 抽象方法：判断形状是否合法
    public abstract bool IsValid();
}

// 长方形类
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double GetArea()
    {
        return Width * Height;
    }

    public override bool IsValid()
    {
        return Width > 0 && Height > 0;
    }
}

// 正方形类（继承自长方形）
public class Square : Rectangle
{
    public double Side { get; set; }

    public Square(double side) : base(side, side)
    {
        Side = side;
    }

    public override bool IsValid()
    {
        return Side > 0;
    }
}

// 圆形类
public class Circle : Shape
{
    public double Radius { get; set; }
    private const double Pi = Math.PI;

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Pi * Radius * Radius;
    }

    public override bool IsValid()
    {
        return Radius > 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        List<Shape> shapes = new List<Shape>();
        double totalArea = 0;

        // 随机创建10个形状
        for (int i = 0; i < 10; i++)
        {
            int shapeType = random.Next(0, 3); // 0:长方形, 1:正方形, 2:圆形
            Shape shape;

            switch (shapeType)
            {
                case 0:
                    double width = random.NextDouble() * 10 + 1; // 1~11之间的随机数
                    double height = random.NextDouble() * 10 + 1;
                    shape = new Rectangle(width, height);
                    break;
                case 1:
                    double side = random.NextDouble() * 10 + 1;
                    shape = new Square(side);
                    break;
                case 2:
                    double radius = random.NextDouble() * 10 + 1;
                    shape = new Circle(radius);
                    break;
                default:
                    shape = null;
                    break;
            }

            if (shape != null && shape.IsValid())
            {
                shapes.Add(shape);
                totalArea += shape.GetArea();
                Console.WriteLine($"{shape.GetType().Name} 面积: {shape.GetArea():F2}");
            }
            else
            {
                Console.WriteLine("创建了无效形状，已跳过");
                i--; // 重新生成一个有效形状
            }
        }

        Console.WriteLine($"\n10个有效形状的总面积: {totalArea:F2}");
    }
}