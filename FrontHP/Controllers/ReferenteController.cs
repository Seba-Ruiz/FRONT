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

            dominio_opciones dom_op = new dominio_opciones();

            ViewBag.Opciones = dom_op.Listar();


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
            dto.id_subordinado = solicitud.subordinado_id;
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

            dominio_opciones dom_op = new dominio_opciones();
            ViewBag.opciones = dom_op.Listar();

            //ViewBag.internet = new SelectList(dom_op.Listar(), "valor","nombre",solicitud.internet);
            //ViewBag.h_personal = new SelectList(dom_op.Listar(), "valor", "nombre", solicitud.home_personal);
            //ViewBag.h_grupal = new SelectList(dom_op.Listar(), "valor", "nombre", solicitud.home_grupal);
            //ViewBag.laboratorio = new SelectList(dom_op.Listar(), "valor", "nombre", solicitud.laboratorio);
            //ViewBag.rayos = new SelectList(dom_op.Listar(), "valor", "nombre", solicitud.rayos);
            //ViewBag.impresora = new SelectList(dom_op.Listar(), "valor", "nombre", solicitud.impresora);
            //ViewBag.wifi = new SelectList(dom_op.Listar(), "valor", "nombre", solicitud.wifi);
            //ViewBag.vpn = new SelectList(dom_op.Listar(), "valor", "nombre", solicitud.acceso_remoto);

            

           
            return View(dto);
        }

        [HttpPost]
        public ActionResult ModificarL(DTO_Solicitud_Guardar dto, int? tipoEquipo, string escritura)
        {

            servicio_solicitud serv_solicitud = new servicio_solicitud();
            var solicitud = serv_solicitud.ObtenerPorId(dto.id_solicitud);

            dto.escritura = escritura == "SI" ? true : false;

            servicio_tipo_equipo serv_tipo = new servicio_tipo_equipo();

            dominio_solicitud dom_sol = new dominio_solicitud();

            servicio_equipo serv_equipo = new servicio_equipo();
            var equipo = serv_equipo.ObtenerPorIdSubordinado(dto.id_subordinado);

            solicitud.home_grupal = dto.h_grupal;

            if (dto.h_grupal)
            {
                solicitud.escritura_home = dto.escritura;
            }
            else
            {
                solicitud.escritura_home = false;
            }


            solicitud.home_personal = dto.h_personal;
            solicitud.impresora = dto.impresora;
            solicitud.internet = dto.internet;
            solicitud.laboratorio = dto.laboratorio;
            solicitud.rayos = dto.rayos;
            solicitud.wifi = dto.wifi;
            solicitud.acceso_remoto = dto.vpn;

            dom_sol.Guardar(solicitud);

            if (dto.wifi & dto.mac != null & tipoEquipo != null)
            {
                
                equipo.mac = dto.mac;
                //var tipo_equipo = serv_tipo.ObtenerPorNombre(dto.tipo_equipo);
                equipo.tipo_id = tipoEquipo;
                dominio_equipo dom_equipo = new dominio_equipo();
                dom_equipo.Guardar(equipo);
            }

            //--AUDITORIO SOLICITUD--//
            WEB_AuditoriaSolicitud auditoria = new WEB_AuditoriaSolicitud();
            dominio_auditoria_solicitud dom_soli = new dominio_auditoria_solicitud();
            dominio_solicitud sol = new dominio_solicitud();
            auditoria.estado = "MODIFICACION";
            auditoria.fecha_realizado = DateTime.Now;
            auditoria.revisado_por = User.Identity.Name;
            auditoria.id_solicitud = sol.ObtenerUltimo();

            dom_soli.Guardar(auditoria);


            return Redirect("Exito");
        }

        public ActionResult Exito() {

            return View();
        }


            public PartialViewResult MostrarCheckHomeGrupal(bool id)
        {
            if (id)
            {
                return PartialView("_MostrarCheckHomeGrupal");
            }
            else
            {
                return PartialView("_SinSeleccion");
            }

        }


        public PartialViewResult Wifi(bool id)
        {
            if (id)
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
        public ActionResult GuardarLegajo( bool internet, bool h_personal, bool h_grupal, bool laboratorio, bool rayos, bool impresora, bool wifi, int? tipoEquipo, string mac, bool vpn, string escritura, int id_subordinado)
        {

            servicio_solicitud serv_solicitud= new servicio_solicitud();
            DTO_Solicitud_Guardar dto = new DTO_Solicitud_Guardar();
            servicio_equipo serv_equipo = new servicio_equipo();

            if (mac != null)
            {
                var existe = serv_equipo.Existe_Mac(mac);
                return Redirect("");
            }

            dto.internet = internet;
            dto.h_personal = h_personal;
            dto.h_grupal = h_grupal;
            dto.laboratorio = laboratorio;
            dto.rayos = rayos;
            dto.impresora = impresora;
            dto.wifi = wifi;
            dto.vpn = vpn;
            dto.escritura = escritura == "SI"? true: false;
            dto.id_subordinado = id_subordinado;

            serv_solicitud.Guardar(dto);


            
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

        //[HttpPost]
        //public JsonResult ExisteMAC(string mac)
        //{
        //    servicio_equipo srv = new servicio_equipo();
        //    var resul = srv.Existe_Mac(mac);
        //    return Json(resul ? string.Format("La mac ingresada ya existe en el sistema") : "true");

        //}


        //public PartialViewResult ExisteMAC(string id)
        //{
        //    servicio_equipo srv = new servicio_equipo();
        //    var resul = srv.Existe_Mac(id);

        //    if (resul)
        //    {
        //        return PartialView("_ExisteMac");
        //    }
        //    else
        //    {
        //        return PartialView("_ConfirmarMac");
        //    }

            
        //}

    }
}