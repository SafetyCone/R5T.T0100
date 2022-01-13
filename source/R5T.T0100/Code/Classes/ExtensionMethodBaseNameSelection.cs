using System;

using R5T.T0092;
using R5T.T0092.X001;


namespace R5T.T0100
{
    public class ExtensionMethodBaseNameSelection : IMutableNamedIdentified
    {
        public Guid ExtensionMethodBaseIdentity { get; set; }
        public string ExtensionMethodBaseNamespacedTypeName { get; set; }

        string INamed.Name => this.ExtensionMethodBaseNamespacedTypeName;
        string IMutableNamed.Name { get => this.ExtensionMethodBaseNamespacedTypeName; set => this.ExtensionMethodBaseNamespacedTypeName = value; }
        Guid IIdentified.Identity => this.ExtensionMethodBaseIdentity;
        Guid IMutableIdentified.Identity { get => this.ExtensionMethodBaseIdentity; set => this.ExtensionMethodBaseIdentity = value; }


        public override string ToString()
        {
            var representation = this.ToStringRepresentation();
            return representation;
        }
    }
}
