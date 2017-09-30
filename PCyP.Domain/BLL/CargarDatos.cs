using PCyP.Domain.Biz;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.BLL
{
    public class CargarDatos
    {
        public CargarDatos()
        {

        }

        public static void LeerArchivo()
        {
            ArrayList apellidos = new ArrayList();

            ArrayList nombre = new ArrayList();

            int counter = 0;
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\apellido.txt");
            while ((line = file.ReadLine()) != null)
            {
                apellidos.Add(line);
                counter++;
            }

            file.Close();


            counter = 0;
            file =
                new System.IO.StreamReader(@AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\nombres.txt");
            while ((line = file.ReadLine()) != null)
            {
                nombre.Add(line);
                counter++;
            }

            file.Close();



            for (int i = 0; i < apellidos.Count; i++)
            {
                for (int j = 0; j < nombre.Count; j++)
                {
                    Student s = new Student();
                    s.FirstName = (String)nombre[j];
                    s.LastName = (String)apellidos[i];
                    s.Email = "a@a.com";
                    s.City = "Jose C Paz";
                    s.DateOfBirth = DateTime.Now;
                    s.Gender = "Masculino";

                    StudentBusiness.Instance.Add(s);
                }
            }
        }

    }
}
