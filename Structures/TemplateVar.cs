using OutSystems.ExternalLibraries.SDK;

namespace Ardo.ArdoHTTP.Structures
{
    /// <summary>
    /// The Iban struct represents an International Bank Account Number (IBAN)
    /// and its components. It's exposed as a structure to your ODC apps and
    /// libraries.
    /// </summary>
    [OSStructure]
    public struct TemplateVar
    {
        /// <summary>
        /// Header Name.
        /// </summary>
        [OSStructureField(DataType = OSDataType.Text, Description = "Name of the variable on the template to be replaced.", IsMandatory = true)]
        public string Name;

        /// <summary>
        /// Header Value.
        /// </summary>
        [OSStructureField(DataType = OSDataType.Text, Description = "Value to be replaced on the template", IsMandatory = true)]
        public string Value;

        /// <summary>
        /// Constructs an Header object.
        /// </summary>
        public TemplateVar(string name, string value) : this()
        {
            Name = name;
            Value = value;
        }
    }

}