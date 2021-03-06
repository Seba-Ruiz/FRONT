﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Servicio.DTO
{
    public class DTO_Solicitud_Guardar
    {
        public bool internet { get; set; }
        public bool h_personal { get; set; }
        public bool h_grupal { get; set; }
        public bool laboratorio { get; set; }
        public bool impresora { get; set; }
        public bool rayos { get; set; }
        public bool wifi { get; set; }
        public string tipo_equipo { get; set; }
        public string mac { get; set; }
        public bool vpn { get; set; }
        public bool escritura { get; set; }
        public int id_subordinado { get; set; }
        public string nombre_sub { get; set; }
        public string apellido { get; set; }
        public int id_solicitud { get; set; }
    }
}
