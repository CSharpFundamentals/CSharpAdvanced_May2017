using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NatureProphet
{
    public static void Main(string[] args)
    {
        var dimensions = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        var garden = new int[dimensions[0], dimensions[1]];
        
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "Bloom Bloom Plow")
        {
            var pointsCoord = inputLine.Split(' ').Select(int.Parse).ToArray();
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                garden[row, pointsCoord[1]]++;
            }

            for (int col = 0; col < garden.GetLength(1); col++)
            {
                if (col != pointsCoord[1])
                {
                    garden[pointsCoord[0], col]++;
                }
            }
        }

        var output = new StringBuilder();
        for (int row = 0; row < garden.GetLength(0); row++)
        {
            for (int col = 0; col < garden.GetLength(1); col++)
            {
                output.Append(garden[row, col] + " ");
            }
            output.AppendLine();
        }

        Console.WriteLine(output);
    }
}