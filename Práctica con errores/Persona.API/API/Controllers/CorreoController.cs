﻿using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorreoController : ControllerBase, ICorreoController
    {
        private ICorreoFlujo _documentoFlujo;

        public CorreoController(ICorreoFlujo documentoFlujo)
        {
            _documentoFlujo = documentoFlujo;
        }
        [HttpPost]
        public IActionResult Enviar([FromBody] Correo correo)
        {
            var resultado = _documentoFlujo.Enviar(correo);
            return Ok();
        }

        Task<IActionResult> ICorreoController.Enviar(Correo correo)
        {
            throw new NotImplementedException();
        }
    }
}
