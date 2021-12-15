using System;

using R5T.T0101;


namespace R5T.T0100
{
    public class ExtensionMethodBaseToProjectMapping : IIdentityMapping
    {
        public Guid ExtensionMethodBaseIdentity { get; set; }
        public Guid ProjectIdentity { get; set; }

        Guid ITypedIdentityMapping<Guid, Guid>.LocalIdentity
        {
            get
            {
                return this.ExtensionMethodBaseIdentity;
            }
            set
            {
                this.ExtensionMethodBaseIdentity = value;
            }
        }

        Guid ITypedIdentityMapping<Guid, Guid>.ExternalIdentity
        {
            get
            {
                return this.ProjectIdentity;
            }
            set
            {
                this.ProjectIdentity = value;
            }
        }
    }
}
