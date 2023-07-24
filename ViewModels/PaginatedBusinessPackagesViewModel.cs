using JPSEMWebApp.Models;

namespace JPSEMWebApp.ViewModels
{
    public class PaginatedBusinessPackagesViewModel
    {
        public IEnumerable<BusinessPackage> BusinessPackages { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int BusinessPackageId { get; set; }
        public int Speed { get; set; }
        public string Description { get; set; }
        public string Capacity { get; set; }
        public double Price { get; set; }
        public double RedundancyPrice { get; set; }
        public double InstallationPrice { get; set; }
    }
}
