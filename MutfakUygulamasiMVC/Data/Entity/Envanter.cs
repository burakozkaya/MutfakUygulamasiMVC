namespace MutfakUygulamasiMVC.Data.Entity;

public class Envanter
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int AppUserId { get; set; }

    //Nav Property
    public AppUser AppUser { get; set; }
    public List<Urun> Urunler { get; set; }
}