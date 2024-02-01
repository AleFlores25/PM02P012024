using PM02P012024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PM02P012024.Controllers
{
    public class PersonasController
    {
        SQLiteAsyncConnection _connection;
        
            //Constructor vacio
        public PersonasController() { }

        //Conexion a la base de datos

        async Task Init()
        {
            if(_connection is not null)
            {
                return;
            }

            SQLite.SQLiteOpenFlags extensiones = SQLite.SQLiteOpenFlags.ReadWrite |
                                                 SQLite.SQLiteOpenFlags.Create |
                                                 SQLite.SQLiteOpenFlags.SharedCache;

            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBPersonas.db3"));

            var creacion = await _connection.CreateTableAsync<Persona>();

        }

        //Crear los metodos Crud para la clase Personas
        //Create  //Update
        public async Task<int> StorePerson(Persona persona)
        {
            await Init();
            if(persona.Id == 0)
            {
                return await _connection.InsertAsync(persona);
            }
            else
            {
                return await _connection.UpdateAsync(persona);
            }
        }

        //Read
        public async Task<List<Persona>> GetListPersons()
        {
            await Init();
            return await _connection.Table<Persona>().ToListAsync();
        }

        //Read Elementos
        public async Task<Persona> GePersons(int pid)
        {
            await Init();
            return await _connection.Table<Persona>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        //Delete Elemento
        public async Task<int> DeletePerson(Persona persona)
        {
            await Init();
            return await _connection.DeleteAsync(persona);
        }

    }
}
