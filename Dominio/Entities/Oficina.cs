﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;

public partial class Oficina
{
    [Key]
    public string CodigoOficina { get; set; }

    public string Ciudad { get; set; }

    public string Pais { get; set; }

    public string Region { get; set; }

    public string CodigoPostal { get; set; }

    public string Telefono { get; set; }

    public string LineaDireccion1 { get; set; }

    public string LineaDireccion2 { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
