namespace Awc.Dapr.Services.Company.API.Model.Person
{
    public class BusinessEntityContact
    {
        public int BusinessEntityID { get; set; }
        public int PersonID { get; set; }
        public int ContactTypeID { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }        
    }
}