using System.ComponentModel.DataAnnotations;

namespace MedbaseHybrid.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a body")]
        public string Body { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a summary")]
        public string Summary { get; set; }
        [Required(ErrorMessage = "Please enter a writer")]
        public string Writer { get; set; }
        [Required(ErrorMessage = "Please enter a Date")]
        public DateTime DatePosted { get; set; }
        [Required(ErrorMessage = "Please enter an Image URL")]
        public string ImageURL { get; set; }
    }
}
