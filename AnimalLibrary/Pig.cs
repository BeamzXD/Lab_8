namespace AnimalLibrary;

[CustomComment("Этот класс представляет свинью.")]
public class Pig : Animal
{
    public Pig() : base() { } // Конструктор по умолчанию
    public Pig(string name, string country, bool hide, string whatAnimal)
        : base(name, country, hide, whatAnimal, eClassificationAnimal.Omnivores) { }

    public override eFavoriteFood GetFavouriteFood() => eFavoriteFood.Everything;

    public override void SayHello() => Console.WriteLine("Хрю!");
}
