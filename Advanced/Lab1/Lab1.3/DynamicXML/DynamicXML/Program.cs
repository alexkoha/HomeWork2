using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace DynamicXML
{
    public class DynamicXElement : DynamicObject
    {
        private readonly XElement _element;

        //Constructor should be private
        public DynamicXElement(XElement element)
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

            //This condition will never be true, because if it is not an 'InvalidCastException' will be thrown by your casting
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

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            XElement getNode = _element.Element(binder.Name);

            if (getNode != null)
            {
                result = new DynamicXElement(getNode);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            XElement setNode = _element.Element(binder.Name);

            if (setNode != null)
            {
                setNode.SetValue(value);
            }
            else
            {
                if (value.GetType() == typeof(DynamicXElement))
                {
                    _element.Add(new XElement(binder.Name));
                }
                else
                {
                    _element.Add(new XElement(binder.Name,value));
                }
            }
            return true;
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type == typeof(string))
            {
                result = _element.Value;
                return true;
            }
            else
            {
                result = null;
                return false;
            }
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
                var myPlanet = planets["Planet", 4]; // mars second moon
                Console.WriteLine(myPlanet);

            }
            catch (Exception)
            {
                Console.WriteLine("File not exist!");
            }

            
        }
    }
}
