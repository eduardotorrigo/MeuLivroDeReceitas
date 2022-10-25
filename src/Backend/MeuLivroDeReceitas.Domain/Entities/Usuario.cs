using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entities
{
    public class Usuario : EntitieBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}