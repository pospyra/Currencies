using System.Xml.Serialization;

namespace Currencies.DAL.Entities
{
    [Serializable]
    [XmlRoot("Valute")]
    public class Valute
    {
        [XmlAttribute(AttributeName = "ID")]
        public string? ID { get; set; } 

        public int NumCode { get; set; }

        public string? CharCode { get; set; }

        public int Nominal { get; set; }

        public string? Name { get; set; }

        public string? Value { get; set; }

        public string? VunitRate { get; set; }

        public int ValCursId { get; set; }
        public ValCurs? ValCurs { get; set; }

        public Valute() { }
        public Valute(string id, string charCode, string name)
        {
            ID = id;
            CharCode = charCode;
            Name = name;
        }
    }
}
