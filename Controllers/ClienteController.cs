using Instituto.Models;
using Microsoft.AspNetCore.Mvc;
namespace Instituto.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic ListarCliente()
        {

            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    id = "1",
                    correo = "Bernanrdogoogle@gmail.com",
                    edad = "19",
                    nombre = "Bernardo Peña"
                },
                new Cliente
                {
                    id = "2",
                    correo = "Miguelgoogle@gmail.com",
                    edad = "23",
                    nombre = "Miguel mantilla"
                }
            };
            return clientes;

        }


        [HttpGet]
        [Route("listarxid")]
        public dynamic ListarClientexid(int codigo)
        {
            //obtienes el cliente de la db
        
            
                return new Cliente

                {
                    id = codigo.ToString(),
                    correo = "Bernanrdogoogle@gmail.com",
                    edad = "19",
                    nombre = "Bernardo Peña"
                };
            }


    

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {


            cliente.id = "3";
            return new
            {
                success = true,
                message = "cliente registrado",
                result = cliente
            };
        }
        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarCliente(Cliente cliente)
        {
            string token = Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;

            //Eliminas en la db
            if (token != "marco123.")
            {
                return new
                {
                    success = false,
                    message = "token incorrecto",
                    result = ""
                };
            }


            return new
            {
                success = true,
                message = "cliente eliminado",
                result = cliente
            };
        }
    }


   
}