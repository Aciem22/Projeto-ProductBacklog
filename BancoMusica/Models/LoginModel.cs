using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace BancoMusica.Models
{
	public class LoginModel
	{
		public int Id { get; set; }

		[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
		[StringLength(60, MinimumLength = 3)]
		[Required(ErrorMessage = "Campo obrigatório - Digite seu nome de usuário")]
		public string Nome { get; set; }

		
		[StringLength(500, MinimumLength = 2)]
		[Required(ErrorMessage = "Campo obrigatório - Digite sua senha")]
		public string Senha { get; set; }
	
	
		public bool SenhaValida(string Senha)
		{
			return this.Senha == Senha;
		}

	}
}
