using System.Xml.Serialization;
namespace AnimalLibrary;

public enum eClassificationAnimal
{
    Herbivores,
    Carnivores,
    Omnivores
}

public enum eFavoriteFood
{
    Meat,
    Plants,
    Everything
}

[Serializable]
[XmlInclude(typeof(Cow))]
[XmlInclude(typeof(Lion))]
[XmlInclude(typeof(Pig))]
public abstract class Animal
{

    public string Country { get; set; }
    public bool HideFromOtherAnimals { get; set; }
    public string Name { get; set; }
    public string WhatAnimal { get; set; }
    public eClassificationAnimal Classification { get; set; }

    public Animal() { } // Конструктор по умолчанию для сериализации

    public Animal(string name, string country, bool hide, string whatAnimal, eClassificationAnimal classification)
    {
        Name = name;
        Country = country;
        HideFromOtherAnimals = hide;
        WhatAnimal = whatAnimal;
        Classification = classification;
    }

    public abstract eFavoriteFood GetFavouriteFood();
    public abstract void SayHello();
}

[AttributeUsage(AttributeTargets.Class)]
public class CustomCommentAttribute : Attribute
{
    public string Comment { get; }

    public CustomCommentAttribute(string comment)
    {
        Comment = comment;
    }
}