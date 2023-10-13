using System.Globalization;
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
        public string Name { get; set; } = string.Empty;

        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlAttribute("Date")]
        public string DateString
        {
            get => Date.ToString("dd.MM.yyyy");
            set => Date = DateTime.ParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }

        [XmlElement("Valute")]
        public List<Valute> Valutes { get; set; } = new();

        public ValCurs() { }
    }
}