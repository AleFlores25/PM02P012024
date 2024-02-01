
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PM02P012024.Models
{
    [Table("Personas")]
    public class Persona
    {
        
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nombres { get; set; }

        [MaxLength(100)]
        public string Apellidos { get; set; }

        public DateTime FechaNac { get; set; }

        [Unique]
        public string telefono { get; set; }
    }

}
