using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicXml
{
    public class DynamicXElement: DynamicObject
    {

        private readonly XElement _element;

        //The constructor is not private.
        public DynamicXElement(XElement element)
        {
            _element = element;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {

            XElement getElement = _element.Element(binder.Name);

            if (getElement != null)
            {
                result = new DynamicXElement(getElement);
                return true;
            }

            else
            {
                result = null;
                return false;
            }
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            result = null;
            bool found = false;

            //Nice
            if (indexes.Length == 2 && indexes[0] is string && indexes[1] is int)
            {
                var allNodes = _element.Elements(indexes[0].ToString());

                int index = (int) indexes[1];

                if (index < allNodes.Count())
                {
                    result = new DynamicXElement(allNodes.ElementAt(index));
                }

                else
                {
                    result = new DynamicXElement(null);
                    found = false;
                    return found;
                }

                found = true;
            }

            return found;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            XElement setNode = _element.Element(binder.Name);
            if (setNode != null)
                setNode.SetValue(value);

            else
            {
                if (value.GetType() == typeof(DynamicXElement))
                    _element.Add(new XElement(binder.Name));

                else
                    _element.Add(new XElement(binder.Name, value));
            }

            return true;
        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            if (indexes.Length == 2 && indexes[0] is string && indexes[1] is int)
            {
                var allNodes = _element.Elements(indexes[0].ToString());

                int index = (int)indexes[1];

                allNodes.ElementAt(index).SetValue(value);

                return true;
            }

            else
                return false;
        }



        public override string ToString()
        {
            if (_element != null)
                return _element.Value;

            else
                return string.Empty;
        }

        public static dynamic Create(XElement element)
        {
            DynamicXElement dynamicXElement = new DynamicXElement(element);
            return dynamicXElement;
        }
    }
}
