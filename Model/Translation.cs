

namespace WebApp.Models {
    public class Translation {
        public long TranslationId { get; set; }
        public required string English { get; set; }
        public required string Faroese { get; set; }

        public long? Approval { get; set; }
    }
}