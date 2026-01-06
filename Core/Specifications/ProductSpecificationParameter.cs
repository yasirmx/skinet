namespace Core.Specifications
{
    public class ProductSpecificationParameter
    {
        private List<string> _brands = new List<string>();

        private List<string> _types = new List<string>();

        public List<string> Brands 
        { 
            get => _brands; set
            {
                _brands = value.SelectMany(b => b.Split(',').Select(x => x.Trim())).ToList();
            }
        }

        public List<string> Types
        {
            get => _types; set
            {
                _types = value.SelectMany(b => b.Split(',').Select(x => x.Trim())).ToList();
            }
        }

        public string? Sort { get; set; }
    }
}
