﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UdemBank
{
    public class GrupoDeAhorro
    {
        [Key]
        public int Id { get; set; }

        public int idCreadorGrupo { get; set; }
        [ForeignKey(nameof(idCreadorGrupo))]

        public Usuario Usuario { get; set; }

        [Required]
        public double SaldoGrupo { get; set; }
    }
}
