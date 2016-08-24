using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicXml
{
    //Nice work
    class Program
    {
        static void Main(string[] args)
        {
            dynamic planets = DynamicXElement.Create(XElement.Load("Plantes.xml"));

            var mercury = planets.Planet;
            Console.WriteLine(mercury);

            var venus = planets["Planet", 1];
            Console.WriteLine(venus);

            var ourMoon = planets["Planet", 2].Moons.Moon;
            Console.WriteLine(ourMoon);

            var marsMoon = planets["Planet", 3]["Moons", 0].Moon;
            Console.WriteLine(marsMoon);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(planets.ToString());
            Console.WriteLine();
            Console.WriteLine();
            
            planets["Planet",0]["Name",0] = "Mercury1";
            planets["Planet", 1]["Name", 0] = "NewVenus";
            planets["Planet", 3]["Moons", 0]["Moon",0] = "NewPhobos";

            Console.WriteLine(planets.Planet);
            Console.WriteLine(planets["Planet", 1]);
            Console.WriteLine(planets["Planet", 3]["Moons", 0].Moon);

            Console.WriteLine();
            Console.WriteLine();
            
            planets.Planet.Name = "Abra";
            Console.WriteLine(planets["Planet", 0]["Name",0]);

            planets.Planet = "NewPlanet";
            Console.WriteLine(planets.ToString());
        }
    }
}
