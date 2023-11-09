using System;

interface IBombPrototype
{
    IBombPrototype Clone();
}

class Bomb : IBombPrototype
{
    public int Power { get; set; }
    public int Timer { get; set; }

    public Bomb(int power, int timer)
    {
        Power = power;
        Timer = timer;
    }

    public IBombPrototype Clone()
    {
        return new Bomb(Power, Timer);
    }
}
    //static void Main()
    //{
    //    // Create prototype bomb objects
    //    IBombPrototype basicBomb = new Bomb(1, 3);
    //    IBombPrototype powerfulBomb = new Bomb(2, 5);

    //    // Clone the prototype bombs to create new bombs
    //    IBombPrototype newBasicBomb = basicBomb.Clone();
    //    newBasicBomb.Timer = 2;  // Modify the timer for the new bomb

    //    IBombPrototype newPowerfulBomb = powerfulBomb.Clone();
    //    newPowerfulBomb.Power = 3;  // Modify the power for the new bomb

    //    // Display the characteristics of the cloned bombs
    //    Console.WriteLine("Basic Bomb - Power: " + newBasicBomb.Power + " Timer: " + newBasicBomb.Timer);
    //    Console.WriteLine("Powerful Bomb - Power: " + newPowerfulBomb.Power + " Timer: " + newPowerfulBomb.Timer);
    //}
