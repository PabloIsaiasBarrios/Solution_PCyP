using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.Biz
{
    public class Instructor: EntityBase
    {
        public String Alias { get; set; } //El alias esta conformado por la primer letra de cada nombre y el apellido
        public String FirstName { get; set; } //Primer Nombre
        public String MiddleName { get; set; } //Segundo Nombre
        public String LastName { get; set; } //Apellido
        public DateTime HireDate { get; set; } //Fecha de Contratacion
        public Boolean IsFulltime { get; set; } //Es a tiempo completo
        public Double Salary { get; set; } //Sueldo
        public DateTime DeletedOn { get; set; } 
        public int DeletedBy { get; set; }
        public Boolean IsDeleted { get; set; }

        public Instructor()
        {
            this.IsFulltime = false;
            this.IsDeleted = false;
        }

    }
}
