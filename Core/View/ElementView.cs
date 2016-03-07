using Structurizr.Model;
using System;
using System.Runtime.Serialization;

namespace Structurizr.View
{

    /// <summary>
    /// An instance of a model element (Person, Software System, Container or Component) in a View.
    /// </summary>
    [DataContract]
    public class ElementView : IEquatable<ElementView>
    {

        public Element Element { get; set; }

        private string id;

        /// <summary>
        /// The ID of the element.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id {
            get
            {
                if (this.Element != null)
                {
                    return this.Element.Id;
                } else
                {
                    return this.id;
                }
            }

            set
            {
                this.id = value;
            }
        }
  
        /// <summary>
        /// The horizontal position of the element when rendered.
        /// </summary>
        [DataMember(Name="x", EmitDefaultValue=false)]
        public int X { get; set; }
  
        /// <summary>
        /// The vertical position of the element when rendered.
        /// </summary>
        [DataMember(Name="y", EmitDefaultValue=false)]
        public int Y { get; set; }
  
        internal ElementView(Element element)
        {
            this.Element = element;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ElementView);
        }

        public bool Equals(ElementView elementView)
        {
            if (elementView == null)
            {
                return false;
            }
            if (elementView == this)
            {
                return true;
            }

            return this.Id == elementView.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            if (this.Element != null) {
                return this.Element.ToString();
            }
            else
            {
                return this.Id;
            }
        }

    }
}
