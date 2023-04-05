﻿using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace BancoMusica.Models
{
    public class Musica
    {
        public int Id { get; set; }

        [StringLength(60,MinimumLength = 2)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string? Title { get; set; }

		[StringLength(500, MinimumLength = 2)]
		[Required(ErrorMessage = "Campo obrigatório")]
		public string? Descricao { get; set; }

		[Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(30)]
        public String? Genre { get; set; }
        
        public String? Video { get; set; }
       

    }
}
