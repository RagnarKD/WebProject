

using CsvHelper.Configuration.Attributes;

namespace WebProject.Model {
    public class Translation {
        public long TranslationId { get; set; }
        
        [Index(0)]
        public required string English { get; set; }

        [Index(1)]
        public required string Faroese { get; set; }

        public long? Approval { get; set; }
    }
}