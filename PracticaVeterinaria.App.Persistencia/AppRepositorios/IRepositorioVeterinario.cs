//Directivas
using System;
using System.Collections.Generic;
using System.Linq;
using PracticaVeterinaria.App.Dominio;
using PracticaVeterinaria.App.Persistencia;

namespace PracticaVeterinaria.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
        // Implementar la firma de los métodos del CRUD
        Veterinario AddVeterinario(Veterinario veterinario);
        Veterinario UpdateVeterinario(Veterinario veterinario);

        void DeleteVeterinario(int idVeterinario);

        // IEnumerable - me permite retornar una lista de objetos

        IEnumerable<Veterinario> GetAllVeterinarios();

        Veterinario GetVeterinario(int idVeterinario);
    }
}