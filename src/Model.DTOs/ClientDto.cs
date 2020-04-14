using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    public class ClientCreateDto
    {
        [Required]
        public string Name { get; set; }
    }

    public class ClientUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }

    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
    }
}
