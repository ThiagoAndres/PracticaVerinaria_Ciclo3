//Directivas
using System;
using Microsoft.EntityFrameworkCore;

// Esta clase implementa la interfaz IRepositorioPropietario

/* Contiene interfaces y clases que definen colecciones genéricas,
que permiten a los usuarios crear colecciones fuertemente tipadas 
y brindan una mejor seguridad y rendimiento.
*/
using System.Collections.Generic;

// Hacer referencia a la capa de dominio para acceder a las entidades
using PracticaVeterinaria.App.Dominio;

using PracticaVeterinaria.App.Persistencia;

/* LINQ(Language Integrated Query)
Es un conjunto de instrucciones integradas en el lenguaje C#, que nos
permite trabajar de manera flexible y rápida con colecciones de datos.
*/

using System.Linq;

//trazabilidad y jerarquia con namespace
namespace PracticaVeterinaria.App.Persistencia.AppRepositorios
{

    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        private readonly AppContext _appContext;

        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }

        Veterinario IRepositorioVeterinario.AddVeterinario(Veterinario veterinario)
        {
            var veterinarioAdicionado = _appContext.veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return veterinarioAdicionado.Entity;

        }
        Veterinario IRepositorioVeterinario.UpdateVeterinario(Veterinario veterinario)
        {
            var veterinarioActualizar = _appContext.veterinarios.SingleOrDefault(r => r.id == veterinario.id);
            if (veterinarioActualizar != null)
            {
                veterinarioActualizar.id = veterinario.id;
                veterinarioActualizar.nombre = veterinario.nombre;
                veterinarioActualizar.telefono = veterinario.telefono;
                veterinarioActualizar.tarjetaProfesional = veterinario.tarjetaProfesional;
                
                _appContext.SaveChanges();
            }
            return veterinarioActualizar;
        }

        void IRepositorioVeterinario.DeleteVeterinario(int idVeterinario)
        {
            var veterinarioEncontrado = _appContext.veterinarios.FirstOrDefault(c => c.id == idVeterinario);
            if (veterinarioEncontrado == null)
            {
                return;
            }
            _appContext.veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();

        }

        // IEnumerable - me permite retornar una lista de objetos

        IEnumerable<Veterinario> IRepositorioVeterinario.GetAllVeterinarios()
        {
            return _appContext.veterinarios;
        }

        Veterinario IRepositorioVeterinario.GetVeterinario(int idVeterinario)
        {
            return _appContext.veterinarios.FirstOrDefault(c => c.id == idVeterinario);
        }

    }
}