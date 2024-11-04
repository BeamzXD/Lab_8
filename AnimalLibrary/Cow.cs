namespace AnimalLibrary;

[CustomComment("Этот класс представляет корову.")]
public class Cow : Animal
{
    public Cow() : base() { } // Конструктор по умолчанию
    public Cow(string name, string country, bool hide, string whatAnimal)
        : base(name, country, hide, whatAnimal, eClassificationAnimal.Herbivores) { }

    public override eFavoriteFood GetFavouriteFood() => eFavoriteFood.Plants;

    public override void SayHello() => Console.WriteLine("Муу!");
}
