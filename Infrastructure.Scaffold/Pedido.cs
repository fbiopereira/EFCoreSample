using System;
using System.Collections.Generic;

namespace Infrastructure.Scaffold;

public partial class Pedido
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public int IdLivro { get; set; }

    public DateTime DataCriacao { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Livro IdLivroNavigation { get; set; } = null!;
}
