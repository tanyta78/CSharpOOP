using System;
using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Garage garage;
    private Dictionary<int, Car> allCars;
    private Dictionary<int, Race> allRaces;

    public CarManager()
    {
        this.garage = new Garage();
        this.allCars = new Dictionary<int, Car>();
        this.allRaces = new Dictionary<int, Race>();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        Car car = null;
        switch (type)
        {
            case "Performance": car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability); break;
            case "Show": car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability); break;
        }
        allCars[id] = car;
    }

    public string Check(int id)
    {
        var currentCar = allCars[id];
        return currentCar.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool, int extra)
    {
        Race race = null;
        switch (type)
        {
            case "Casual":
                race = new CasualRace(length, route, prizePool);
                break;

            case "Drag":
                race = new DragRace(length, route, prizePool);
                break;

            case "Drift":
                race = new DriftRace(length, route, prizePool);
                break;

            case "TimeLimit":
                race = new TimeLimitRace(length, route, prizePool, extra);
                break;

            case "Circuit":
                race = new CircuitRace(length, route, prizePool, extra);
                break;
        }
        allRaces[id] = race;
    }

    public void Participate(int carId, int raceId)
    {
        Race race = allRaces[raceId];
        Car car = allCars[carId];
        if (race != null && car != null && !garage.ParkedCars.ContainsKey(carId))
        {
            race.Participants[carId] = car;
            if (race.GetType().ToString() == "TimeLimitRace" && race.Participants.Count == 2)
            {
                race.Participants.Remove(carId);
            }
        }
    }

    public string Start(int id)
    {
        var race = allRaces[id];
        var typeRace = race.GetType().Name;

        if (race.Participants.Count == 0)
        {
            return $"Cannot start the race with zero participants.";
        }

        var winners = new List<Car>();
        if (typeRace == "CasualRace")
        {
            winners = race.Participants.Values.OrderByDescending(c => c.GetOverallPerformance()).Take(3).ToList();
        }
        else if (typeRace == "DragRace")
        {
            winners = race.Participants.Values.OrderByDescending(c => c.GetEnginePerformance()).Take(3).ToList();
        }
        else if (typeRace == "DriftRace")
        {
            winners = race.Participants.Values.OrderByDescending(c => c.GetSuspensionPerformance()).Take(3).ToList();
        }
        else if (typeRace == "TimeLimitRace" || typeRace == "CircuitRace")
        {
            return race.StartRace();
        }

        var result = $"{race.Route} - {race.Length}";
        int counter = 1;
        var performancePoints = 0;
        var moneyWon = 0;

        foreach (Car winner in winners)
        {
            result += Environment.NewLine;

            if (typeRace == "CasualRace" || typeRace == "CircuitRace")
            {
                performancePoints = winner.GetOverallPerformance();
            }
            else if (typeRace == "DragRace")
            {
                performancePoints = winner.GetEnginePerformance();
            }
            else if (typeRace == "DriftRace")
            {
                performancePoints = winner.GetSuspensionPerformance();
            }
            if (counter == 1)
            {
                moneyWon = (race.PrizePool * 50) / 100;
            }
            else if (counter == 2)
            {
                moneyWon = (race.PrizePool * 30) / 100;
            }
            else if (counter == 3)
            {
                moneyWon = (race.PrizePool * 20) / 100;
            }

            result += ($"{counter}. {winner.Brand} {winner.Model} {performancePoints}PP - ${moneyWon}");
            counter++;
        }
        this.allRaces.Remove(id);
        return result;
    }

    public void Park(int id)
    {
        var car = allCars[id];
        var carIsInRace = false;

        foreach (var race in allRaces.Values)
        {
            foreach (var ccar in race.Participants)
            {
                if (ccar.Key == id)
                {
                    carIsInRace = true;
                    break;
                }
            }
        }

        if (!carIsInRace)
        {
            this.garage.ParkedCars[id] = car;
        }
    }

    public void Unpark(int id)
    {
        if (this.garage.ParkedCars.ContainsKey(id))
        {
            this.garage.ParkedCars.Remove(id);
        }
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var car in this.garage.ParkedCars)
        {
            car.Value.Horsepower += tuneIndex;
            car.Value.Suspension += tuneIndex / 2;
            if (car.Value.GetType().Name == "ShowCar")
            {
                ShowCar show = (ShowCar)car.Value;
                show.Stars += tuneIndex;
            }
            else
            {
                PerformanceCar perf = (PerformanceCar)car.Value;
                perf.AddOns.Add(addOn);
            }
        }
    }
}