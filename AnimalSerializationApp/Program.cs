using System;
using System.IO;
using System.Xml.Serialization;
using AnimalLibrary;

class Program
{
    static void Main()
    {
        // Создание экземпляра животного (например, корова)
        Animal cow = new Cow("Буренка", "Россия", false, "Крупный рогатый скот");

        // Сериализация в XML
        XmlSerializer serializer = new XmlSerializer(typeof(Animal));
        using (FileStream fs = new FileStream("animal.xml", FileMode.Create))
        {
            serializer.Serialize(fs, cow);
            Console.WriteLine("Объект успешно сериализован в файл animal.xml");
        }

        // Десериализация из XML
        using (FileStream fs = new FileStream("animal.xml", FileMode.Open))
        {
            Animal deserializedAnimal = (Animal)serializer.Deserialize(fs);
            Console.WriteLine("Объект успешно десериализован:");
            Console.WriteLine($"Имя: {deserializedAnimal.Name}");
            Console.WriteLine($"Страна: {deserializedAnimal.Country}");
            Console.WriteLine($"Скрывается от других животных: {deserializedAnimal.HideFromOtherAnimals}");
            Console.WriteLine($"Тип: {deserializedAnimal.WhatAnimal}");
        }
    }
}
