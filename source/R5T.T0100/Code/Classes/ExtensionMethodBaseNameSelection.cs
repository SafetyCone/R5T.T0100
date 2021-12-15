using System;

using R5T.T0092;
using R5T.T0092.X001;


namespace R5T.T0100
{
    public class ExtensionMethodBaseNameSelection : INamedIdentified
    {
        public Guid ExtensionMethodBaseIdentity { get; set; }
        public string ExtensionMethodBaseNamespacedTypeName { get; set; }

        string INamed.Name => this.ExtensionMethodBaseNamespacedTypeName;
        Guid IIdentified.Identity => this.ExtensionMethodBaseIdentity;


        public override string ToString()
        {
            var representation = this.ToStringRepresentation();
            return representation;
        }
    }
}
