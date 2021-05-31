using System;
using System.ComponentModel.DataAnnotations;

namespace IBISGlossary.Model
{
    public class Glossary
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Term { get; set; }

        public string Definition { get; set; }
    }
}
