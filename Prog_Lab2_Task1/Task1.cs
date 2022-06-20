namespace Prog_Lab2_Task1
{
    internal class Task1
    {
        public static void Main(string[] args)
        {
            SolarSystem solarSystem = new SolarSystem("Solar system");
            Planet planet = new Planet("Earth",2342, Planet.PlanetType.SolidPlanet, solarSystem);
            Satellite satellite = new Satellite("Moon", 123, Planet.PlanetType.SatellitePlanet, planet, solarSystem);
            Star star = new Star("Sun", 34264563, Star.StarType.Default, solarSystem);
            Console.WriteLine(solarSystem.ToString());
            Console.WriteLine(planet.ToString());
            Console.WriteLine(satellite.ToString());
            Console.WriteLine(star.ToString());
            Console.WriteLine($"В {solarSystem.Name} - {solarSystem.PlanetCount()} планет");
            Console.Write($"В {solarSystem.Name} - {solarSystem.StarName()} зiрка");
        }
    }
    
    public class SolarSystem
    {
        public List<SpaceObject> Planets = new List<SpaceObject>();
        
        public Star Star { set; get; }
        public string Name { set; get; }
        public SolarSystem(string name)
        {
            Name = name;
        }
        public void AddPlanet(SpaceObject planet)
        {
            Planets.Add(planet);
            Console.WriteLine($"{Name}: додано {planet.Name}");
        }

        public int PlanetCount()
        {
            return Planets.Count;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            SolarSystem m = obj as SolarSystem;
            if (m as SolarSystem == null)
                return false;

            return m.Name == this.Name && m.Planets.Equals(this.Planets);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Planets, Name);
        }

        public string StarName()
        {
            return Star.Name;
        }
        
        public override string ToString()
        {
            return "SolarSystem: " + Name + " " + Planets.Count;
        }
    }

    public abstract class SpaceObject
    {
        public string Name { set; get; }
        public int Mass { set; get; }
        public SolarSystem System { set; get; }
        public SpaceObject(string name, int mass, SolarSystem system)
        {
            Name = name;
            Mass = mass;
            System = system;
        }
        
        public override string ToString()
        {
            return "SpaceObject: " + Name + " " + Mass + " " + System.Name;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            SpaceObject m = obj as SpaceObject;
            if (m as SpaceObject == null)
                return false;

            return m.Name == this.Name && m.Mass == this.Mass && m.System.Equals(this.System);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Mass, System);
        }
    }

    public class Star:SpaceObject
    {
        public enum StarType
        {
            Default,
            BlackHole
        }
        public StarType Type { set; get; }
        
        public Star(string name, int mass, StarType type, SolarSystem system) : base(name, mass,system)
        {
            Type = type;
            System = system;
            system.Star = this;
        }
        
        public override string ToString()
        {
            return "SpaceObject: " + Name + " " + Mass + " "+ Type + " "+ System.Name;
        }
        
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            Star m = obj as Star;
            if (m as Star == null)
                return false;

            return base.Equals(m) && m.Type == this.Type && m.System.Equals(this.System);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), (int) Type);
        }
    }

    public class Planet:SpaceObject
    {
        public enum PlanetType
        {
            SolidPlanet,
            GasGiant,
            SatellitePlanet,
        }
        public PlanetType Type { set; get; }
        public Planet(string name, int mass, PlanetType type, SolarSystem system):base(name, mass,system)
        {
            Type = type;
            System = system;
            system.AddPlanet(this);
        }
        
        public override string ToString()
        {
            return "SpaceObject: " + Name + " " + Mass + " "+ Type + " "+ System.Name;
        }
        
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            Planet m = obj as Planet;
            if (m as Planet == null)
                return false;

            return base.Equals(m) && m.Type == this.Type;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), (int) Type);
        }
    }

    public class Satellite : Planet
    {
        public Planet Parent { set; get; }
        
        public Satellite(string name, int mass, PlanetType type, Planet parent, SolarSystem system)
            : base(name, mass, type, system)
        {
            Parent = parent;
        }
        
        public override string ToString()
        {
            return "SpaceObject: " + Name + " " + Mass + " "+ Type + " " + Parent.Name + " " + System.Name;
        }
        
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            Satellite m = obj as Satellite;
            if (m == null)
                return false;

            return base.Equals(m) && this.Parent.Equals(Parent);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Parent);
        }
    }

}

