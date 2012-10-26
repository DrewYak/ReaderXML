using System;
using System.Xml;
using System.Collections.Generic;
using NUnit.Framework;

/// <summary>
/// Класс с тестами для конструктора и свойств класса Passenger.
/// </summary>
class TestPassenger
{
    [Test]
    public static void TPassengerConstructor([Random(1000, 2000, 50)]                       int     TNumber, 
                                             [Values("Алёшина", "Румянцева", "Трофименко")] string  TFirstName,
                                             [Values("Анастасия", "Ксения", "Дарья")]       string  TLastName,
                                             [Values("Плацкарт", "Купе")]                   string  TType)
    {
        Passenger TPassenger = new Passenger(TNumber, TFirstName, TLastName, TType);
        
        Assert.IsInstanceOf<Passenger>(TPassenger);
        Assert.AreEqual(TNumber, TPassenger.ID);
        Assert.AreEqual(TFirstName, TPassenger.FirstName);
        Assert.AreEqual(TLastName, TPassenger.LastName);
        Assert.AreEqual(TType, TPassenger.TypeOfTicket);
    }

    [Test]
    public static void TPassengerConstructorWithoutParam()
    {
        Passenger TPassenger = new Passenger();
        
        Assert.IsInstanceOf<Passenger>(TPassenger);
        Assert.AreEqual(9999, TPassenger.ID);
        Assert.AreEqual("Иван", TPassenger.FirstName);
        Assert.AreEqual("Иванов", TPassenger.LastName);
        Assert.AreEqual("Плацкарт", TPassenger.TypeOfTicket);

    }

    [Test]
    public static void TPassengerPropety([Random(-1000, 11000, 100)]                    int     TNumber, 
                                         [Values("Алёшина", "Румянцева", "Трофименко")] string  TFirstName,
                                         [Values("Анастасия", "Ксения", "Дарья")]       string  TLastName,
                                         [Values("Плацкарт", "Купе")]                   string  TType)
    {
        Passenger TPassenger = new Passenger(TNumber, TFirstName, TLastName, TType);
        
        if ((TNumber >= 1000) && (TNumber <=9999))
        { Assert.AreEqual(TNumber, TPassenger.ID); }
        else
        { Assert.AreEqual(0, TPassenger.ID); }
    }
}