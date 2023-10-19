using OutSystems.ExternalLibraries.SDK;

namespace Ardo.ArdoHTTP.Structures
{
    /// <summary>
    /// The Iban struct represents an International Bank Account Number (IBAN)
    /// and its components. It's exposed as a structure to your ODC apps and
    /// libraries.
    /// </summary>
    [OSStructure]
    public struct HttpHeader
    {
        /// <summary>
        /// Header Name.
        /// </summary>
        [OSStructureField(DataType = OSDataType.Text, Description = "Header Name.", IsMandatory = true)]
        public string Name;

        /// <summary>
        /// Header Value.
        /// </summary>
        [OSStructureField(DataType = OSDataType.Text, Description = "Header Value.", IsMandatory = true)]
        public string Value;

        /// <summary>
        /// Constructs an Header object.
        /// </summary>
        public HttpHeader(string name, string value) : this()
        {
            Name = name;
            Value = value;
        }
    }

}