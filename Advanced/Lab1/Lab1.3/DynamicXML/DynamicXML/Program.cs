using DynamicXML;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicXML
{
    public class DynamicXElement : DynamicObject
    {
        private readonly XElement _element;

        private DynamicXElement(XElement element)
        {
            _element = element;
        }

        public static dynamic Create(XElement one)
        {
            dynamic newDynamic = new DynamicXElement(one);
            return newDynamic;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indx, out object obj)
        {
            string name = (string)indx[0];
            int index = (int)indx[1];
            bool isObjNotOk = name.GetType() != typeof(string) || index.GetType() != typeof(int);

            if (isObjNotOk)
            {
                obj = null;
                return false;
            }

            List<XElement> indexedElements = _element.Elements(name).ToList();
            obj = new DynamicXElement(indexedElements.ElementAt(index));
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object obj)
        {

            obj = new DynamicXElement(_element.Element(binder.Name));
            return true;
        }

        public override string ToString()
        {
            return _element.Value.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                dynamic planets = DynamicXElement.Create(XElement.Load(@"..\..\..\test.xml"));
                var mercury = planets.Planet;       // first planet
                Console.WriteLine(mercury);
                var venus = planets["Planet", 1];   // second planet 
                Console.WriteLine(venus);
                var ourMoon = planets["Planet", 2].Moons.Moon;
                Console.WriteLine(ourMoon);
                var marsMoon = planets["Planet", 3]["Moons", 0].Moon; // mars second moon
                Console.WriteLine(marsMoon);
            }
            catch (Exception)
            {
                Console.WriteLine("File not exist!");
            }

            
        }
    }
}
