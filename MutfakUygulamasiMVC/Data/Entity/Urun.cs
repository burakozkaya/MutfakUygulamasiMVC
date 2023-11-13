namespace MutfakUygulamasiMVC.Data.Entity;

public class Urun
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int EnvanterId { get; set; }
    //Nav Property
    public Envanter Envanter { get; set; }
}