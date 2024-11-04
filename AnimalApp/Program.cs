using System;
using System.Reflection;
using System.Xml.Linq;
using AnimalLibrary; // Импорт библиотеки классов

class Program
{
    static void Main()
    {
        Assembly assembly = Assembly.LoadFrom("../AnimalLibrary/bin/Debug/net8.0/AnimalLibrary.dll");
        XElement xmlRoot = new XElement("Classes");

        foreach (Type type in assembly.GetTypes())
        {
            XElement classElement = new XElement("Class", new XAttribute("Name", type.Name));

            var customCommentAttribute = type.GetCustomAttribute<CustomCommentAttribute>();
            if (customCommentAttribute != null)
            {
                classElement.Add(new XAttribute("Comment", customCommentAttribute.Comment));
            }

            xmlRoot.Add(classElement);
        }

        XDocument doc = new XDocument(xmlRoot);
        doc.Save("ClassDiagram.xml");
        Console.WriteLine("XML файл ClassDiagram.xml успешно создан!");
    }
}

