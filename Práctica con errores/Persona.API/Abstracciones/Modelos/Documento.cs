using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Documento
    {
        public required string Nombre { get; set; }
    }
    public class DocumentoContenido:Documento
    {        
        public required byte[] Contenido { get; set; }        
    }
    public class DocumentoSinContenido:Documento
    {
        public Guid Id { get; set; }
        public required string Ruta { get; set; }
        public required string Tipo { get; set; }
    }
    public class DocumentoConContenido:DocumentoContenido
    {
        public Guid Id { get; set; }
        public required string Tipo { get; set; }
    }

}
