using System;
using System.Text;

public class NMS
{
    public static void Main()
    {
        var input = new StringBuilder();
        string inputLine;

        while ((inputLine = Console.ReadLine()) != "---NMS SEND---")
        {
            input.Append(inputLine);
        }

        var delimiter = Console.ReadLine();
        var message = input.ToString();

        var result = new StringBuilder();
        result.Append(message[0]);
        for (int i = 1; i < message.Length; i++)
        {
            if (char.ToLower(message[i]) >= char.ToLower(message[i -1]))
            {
                result.Append(message[i]);
            }
            else
            {
                result.Append(delimiter);
                result.Append(message[i]);
            }
        }

        Console.WriteLine(result);
    }
}
