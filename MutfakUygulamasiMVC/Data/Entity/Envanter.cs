namespace MutfakUygulamasiMVC.Data.Entity;

public class Envanter
{
    public int Id { get; set; }
    public int AppUserId { get; set; }
    public int UrunId { get; set; }
    public int Quantity { get; set; }

    //Nav Property
    public Urun Urun { get; set; }
}