using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicio.DTO;
using Modelo;


namespace Servicio.Servicio
{
    public class servicio_subordinado
    {
        public string GuardarSubordinado(DTO_Subordinado dto , string usuario)
        {
            dominio_subordinado sub = new dominio_subordinado();
            WEB_Subordinado modelo_sub = new WEB_Subordinado();
            string resultado;
            modelo_sub.estado = false;
            modelo_sub.dni = dto.dni;
            modelo_sub.apellido = dto.apellido;
            modelo_sub.nombre = dto.nombre;
            modelo_sub.servicio_id = dto.servicio;
            modelo_sub.mail = dto.mail;
            modelo_sub.registrado_por = usuario;
            modelo_sub.fecha_registro = DateTime.Now;



            var comparar = sub.ListarSinEstado();

            foreach (var item in comparar)
            {
                if (item.dni == dto.dni)
                {
                    resultado = "DNI existente";
                    return resultado;
                }
            }

            sub.Guardar(modelo_sub);

            return resultado = null;
        }

        public bool Existe_Dni(int dni)
        {
            dominio_subordinado sub = new dominio_subordinado();
            var comparar = sub.ListarSinEstado();
            bool result = false;

            foreach (var item in comparar)
            {
                if (item.dni == dni)
                {
                    result = true;
                    return result;
                }
            }

            return result;
        }

        public bool Existe_Mail(string mail)
        {
            dominio_subordinado sub = new dominio_subordinado();
            var comparar = sub.ListarSinEstado();
            bool result = false;

            foreach (var item in comparar)
            {
                if (item.mail == mail)
                {
                    result = true;
                    return result;
                }
            }

            return result;
        }


    }




}
