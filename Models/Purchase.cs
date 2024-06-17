namespace Backend.Models{
    public class Purchase{
        public int? Id { get; set;}
        public DateOnly? Date {get; set;}
        public int? Amount {get; set;}
        public int? UserId {get; set;}
        public Usuario? Usuario {get; set;}
    }
}