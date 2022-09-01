using System;
namespace PracticaVeterinaria.App.Dominio
{
    public class HistoriaClinica
    {
        public int id{get; set;}
        public string fechaApertura{get; set;}
        public Mascota mascota{get;set;}
        
    }
}