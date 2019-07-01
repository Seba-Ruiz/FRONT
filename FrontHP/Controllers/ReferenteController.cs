using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicio.DTO;
using Servicio.Servicio;
using Dominio;
using Modelo;

namespace FrontHP.Controllers
{
    public class ReferenteController : Controller
    {
        // GET: Referente
       
        public ActionResult Index()
        {
            servicio_subordinados_por_referente serv_ref = new servicio_subordinados_por_referente();
            servicio_servicio serv = new servicio_servicio();
            var sr = serv_ref.Sub_X_Referente();

            if (sr.Count() == 0)
            {
                return Redirect("Error");
            }

            List<DTO_Subordinado> dto = new List<DTO_Subordinado>();

            foreach (var item in sr)
            {
                DTO_Subordinado dto_sub = new DTO_Subordinado();
                dto_sub.apellido = item.apellido;
                dto_sub.nombre = item.nombre;
                dto_sub.mail = item.mail;
                dto_sub.nombre_servicio = serv.NombreServicio(item.servicio_id);
                dto_sub.estado = item.estado;
                dto_sub.dni = item.dni;
                dto.Add(dto_sub);
            }


            return View(dto);
        }

        public ActionResult Error()
        {
            return View();
        }
        
         public ActionResult CrearLegajo(int? id)
        {
            dominio_subordinado srv = new dominio_subordinado();
            var coso = srv.ObtenerPorDNI(id);

            return View(coso); 
        }

        public ActionResult ModificarLegajo(int? id)
        {
            dominio_subordinado dom_sub = new dominio_subordinado();
            var subordinado = dom_sub.ObtenerPorDNI(id);

            dominio_solicitud dom_sol = new dominio_solicitud();
            var solicitud = dom_sol.ObtenerPorID(subordinado.id_subordinado);

            DTO_Solicitud_Guardar dto = new DTO_Solicitud_Guardar();

            dto.nombre_sub = subordinado.nombre;
            dto.apellido = subordinado.apellido;
            dto.id_solicitud = solicitud.id_solicitud;
            dto.h_personal = solicitud.home_personal;
            dto.internet = solicitud.internet;
            dto.h_grupal = solicitud.home_grupal;
            dto.escritura = solicitud.escritura_home;

            dto.impresora = solicitud.impresora;
            dto.laboratorio = solicitud.laboratorio;

            dto.wifi = solicitud.wifi;
            servicio_equipo srv_eq = new servicio_equipo();
            servicio_tipo_equipo srv_tipo = new servicio_tipo_equipo();
            var equipo = srv_eq.ObtenerPorIdSubordinado(solicitud.subordinado_id);
            dto.mac = equipo.mac;
            var tipo = srv_tipo.ObtenerPorId(equipo.tipo_id);

            if (tipo != null)
            {
                dto.tipo_equipo = tipo.nombre;
            }
            

            dto.rayos = solicitud.rayos;
            dto.vpn = solicitud.acceso_remoto;

           
            return View(dto);
        }

        [HttpPost]
        public ActionResult ModificarLegajo(DTO_Solicitud_Guardar dto)
        {

            return View();
        }


            public PartialViewResult MostrarCheckHomeGrupal(int id)
        {
            if (id==1)
            {
                return PartialView("_MostrarCheckHomeGrupal");
            }
            else
            {
                return PartialView("_SinSeleccion");
            }

        }


        public PartialViewResult Wifi(int id)
        {
            if (id == 1)
            {
                tipo_equipo_dominio tipo = new tipo_equipo_dominio();
                var tipos = tipo.Listar();
                return PartialView("_Wifi", tipos);
            }
            else
            {
                return PartialView("_SinSeleccion");
            }

        }
        [HttpPost]
        public ActionResult GuardarLegajo(int? internet, int? h_personal, int? h_grupal, int? laboratorio, int? rayos, int? impresora, int? wifi, int? tipoEquipo, string mac, int? vpn, string escritura, int id_subordinado)
        {

            servicio_solicitud serv_solicitud= new servicio_solicitud();
            DTO_Solicitud_Guardar dto = new DTO_Solicitud_Guardar();

            
            dto.internet = internet==1 ? true : false;
            dto.h_personal = h_personal == 1 ? true : false;
            dto.h_grupal = h_grupal == 1 ? true : false;
            dto.laboratorio = laboratorio == 1 ? true : false;
            dto.rayos = rayos == 1 ? true : false;
            dto.impresora = impresora == 1 ? true : false;
            dto.wifi = wifi == 1 ? true : false;
            dto.vpn = vpn == 1 ? true : false;
            dto.escritura = escritura == "SI"? true: false;
            dto.id_subordinado = id_subordinado;

            serv_solicitud.Guardar(dto);


            servicio_equipo serv_equipo = new servicio_equipo();
            DTO_Equipo_Guardar dto_equipo = new DTO_Equipo_Guardar();


            dto_equipo.id_subordinado = id_subordinado;
            dto_equipo.mac = mac;
            dto_equipo.tipo_equipo = tipoEquipo;

            serv_equipo.Guardar(dto_equipo);


            servicio_subordinado sub = new servicio_subordinado();
            sub.ActualizarEstado(id_subordinado);


            //--AUDITORIO SOLICITUD--//
            WEB_AuditoriaSolicitud auditoria = new WEB_AuditoriaSolicitud();
            dominio_auditoria_solicitud dom_sol = new dominio_auditoria_solicitud();
            dominio_solicitud sol = new dominio_solicitud();
            auditoria.estado = "ALTA LEGAJO";
            auditoria.fecha_realizado = DateTime.Now;
            auditoria.revisado_por = User.Identity.Name;
            auditoria.id_solicitud = sol.ObtenerUltimo();

            dom_sol.Guardar(auditoria);

            return View();
        }

    }
}