namespace JPSEMWebApp.Models
{
    public class BusinessPackage
    {
        public int BusinessPackageId { get; set; }
        public int Speed { get; set; }
        public string Description { get; set; }
        public string Capacity { get; set; }
        public double Price { get; set; }
        public double RedundancyPrice { get; set; }
        public double InstallationPrice { get; set; }
    }
}
