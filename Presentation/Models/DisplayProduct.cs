using System;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models;

public class DisplayProduct
{
	[Required]
	[MinLength(3,ErrorMessage = "Mintitle length is 3.")]
	public string Title {
		get; set;
	}

	[Required]
	public int Price {
		get; set;
	}

	[Required]
	public int Availability {
		get; set;
	}
}

