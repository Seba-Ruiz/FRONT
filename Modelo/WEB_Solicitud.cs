//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class WEB_Solicitud
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WEB_Solicitud()
        {
            this.WEB_AuditoriaSolicitud = new HashSet<WEB_AuditoriaSolicitud>();
        }
    
        public int id_solicitud { get; set; }
        public int subordinado_id { get; set; }
        public System.DateTime fecha_solicitud { get; set; }
        public bool wifi { get; set; }
        public bool home_personal { get; set; }
        public bool home_grupal { get; set; }
        public bool internet { get; set; }
        public bool laboratorio { get; set; }
        public bool rayos { get; set; }
        public bool impresora { get; set; }
        public bool acceso_remoto { get; set; }
        public bool escritura_home { get; set; }
        public string estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WEB_AuditoriaSolicitud> WEB_AuditoriaSolicitud { get; set; }
        public virtual WEB_Subordinado WEB_Subordinado { get; set; }
    }
}
