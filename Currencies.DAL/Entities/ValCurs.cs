using System.Xml.Serialization;

namespace Currencies.DAL.Entities
{
    [Serializable]
    [XmlRoot("ValCurs")]
    public class ValCurs
    {
        [XmlIgnore]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; } 

        [XmlAttribute("Date")]
        public string Date { get; set; }

        [XmlElement("Valute")]
        public List<Currency> Valutes { get; set; }
    }
}