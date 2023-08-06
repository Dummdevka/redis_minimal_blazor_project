using System;
namespace Domain.Entities;

public class Product
{
	public int Id {
		get; set;
	}

	public string Title {
		get; set;
	}

	public int Price {
		get; set;
	}

	public int Availability {
		get; set;
	}
}

