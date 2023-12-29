using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace Repository_Pattern_Template.Models
{
    [Collection("students")]
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required(ErrorMessage ="You must provide the First name filed")]
        public  string? FirstName { get; set; }

        [Required(ErrorMessage = "You must provide the Last name filed")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "You must provide the Age filed")]
        public int Age { get; set; }
        public string? Email { get; set; }
    }
}
