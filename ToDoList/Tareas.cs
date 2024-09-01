using System;

public class Tareas
{
    public string Descripcion { get; set; }
    public DateTime? FechaLimite { get; set; }
    public bool Estado { get; set; }

    public Tareas(string descripcion, DateTime? fechaLimite = null)
    {
        Descripcion = descripcion;
        FechaLimite = fechaLimite;
        Estado = false;
    }

    public override string ToString()
    {
        return $"Descripción: {Descripcion}, Fecha Límite: {FechaLimite?.ToString("yyyy-MM-dd") ?? "No Especificada"}, Estado: {(Estado ? "Completada" : "Pendiente")}";
    }
}
