using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Temperature Converter");
            Console.WriteLine("--------------------");

            Console.Write("Please enter a temperature value and its unit of measurement (F or C): ");
            string temperatureInput = Console.ReadLine();

            if (temperatureInput.ToLower() == "exit")
            {
                Console.WriteLine("Program terminated.");
                break;
            }

            char temperatureUnit = temperatureInput[^1]; // Get the last character

            if (temperatureUnit != 'C' && temperatureUnit != 'c' && temperatureUnit != 'F' && temperatureUnit != 'f')
            {
                Console.WriteLine("Invalid temperature unit. Please enter either 'C' or 'F'.");
                continue;
            }

            double temperatureValue;
            if (!double.TryParse(temperatureInput.Substring(0, temperatureInput.Length - 1), out temperatureValue))
            {
                Console.WriteLine("Invalid input. Please enter a valid temperature value and its unit of measurement (F or C):");
                continue;
            }

            TemperatureScale scale = temperatureUnit == 'C' || temperatureUnit == 'c' ? TemperatureScale.Celsius : TemperatureScale.Fahrenheit;

            double convertedTemperature;
            switch (scale)
            {
                case TemperatureScale.Celsius:
                    convertedTemperature = TempConvert(temperatureValue, TemperatureScale.Celsius, TemperatureScale.Fahrenheit);
                    // Console.WriteLine($"{temperatureValue}°C is equal to {convertedTemperature}°F");
                     Console.WriteLine($"{temperatureValue}°C = {convertedTemperature}°F");
                    break;

                case TemperatureScale.Fahrenheit:
                    convertedTemperature = TempConvert(temperatureValue, TemperatureScale.Fahrenheit, TemperatureScale.Celsius);
                    // Console.WriteLine($"{temperatureValue}°F is equal to {convertedTemperature}°C");
                    Console.WriteLine($"{temperatureValue}°F = {convertedTemperature}°C");
                    break;
            }
        }
    }

    enum TemperatureScale
    {
        Celsius,
        Fahrenheit
    }

    static double TempConvert(double temperature, TemperatureScale fromScale, TemperatureScale toScale)
    {
        switch ((fromScale, toScale))
        {
            case (TemperatureScale.Celsius, TemperatureScale.Fahrenheit):
                return (temperature * 9 / 5) + 32;

            case (TemperatureScale.Fahrenheit, TemperatureScale.Celsius):
                return (temperature - 32) * 5 / 9;

            default:
                throw new ArgumentException("Invalid temperature conversion.");
        }
    }
}
