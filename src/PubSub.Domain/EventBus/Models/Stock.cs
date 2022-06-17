namespace PubSub.Domain.EventBus.Models;

public abstract record Stock(int Price = 0, string Symbol = null, string Name = null)
{
    public int Price { get; set; } = Price;
    public string Symbol { get; set; } = Symbol;
    public string Name { get; set; } = Name;
}