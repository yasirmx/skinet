namespace Core.Specifications
{
    public class ProductSpecificationParameter
    {
        private readonly int MaxPageSize = 50;

        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;

        public int PageSize 
        { 
            get => _pageSize; 
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        private List<string> _brands = new List<string>();

        private List<string> _types = new List<string>();

        private string? _search;

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

        public string? Search { get => _search ?? string.Empty; set => _search = value.ToLower(); }
    }
}
