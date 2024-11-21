using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Servicios
{
    public class DocumentoServicio : IDocumentoServicio
    {
        private IConfiguration _configuracion;


        public DocumentoServicio(IConfiguration configuracion)
        {
            _configuracion = configuracion;
        }

        public bool Agregar(DocumentoContenido documento, Guid id)
        {
            var ruta = ObtenerRuta();
            try
            {
                File.WriteAllBytes($"{ruta}{id}", documento.Contenido);
                return true;
            }
            catch (Exception ex)
            {
                new Exception("Error al guardar el documento", ex);
                return false;
            }
        }

        public async Task<byte[]?> Obtener(Guid? id)
        {
            var archivo= Directory.EnumerateFiles(ObtenerRuta(), id.ToString(),SearchOption.AllDirectories).FirstOrDefault();
            if (archivo == null)
                return null;
            return await File.ReadAllBytesAsync(archivo);            
        }

        public Task<byte[]> Obtener(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDocumentoServicio.Agregar(DocumentoContenido documento, Guid id)
        {
            throw new NotImplementedException();
        }

        private string ObtenerRuta()
        {
            return _configuracion.GetSection("RutaDocumentos").Value;
        }
    }
}
