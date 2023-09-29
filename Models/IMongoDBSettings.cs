namespace WebApplication1.Models
{
    public interface IMongoDBSettings {

        public string ConnectionURI { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName1 { get; set; }
        public string CollectionName2{get; set;}
        public string CollectionName3{get; set;}

    }   
}