using System;
using System.Collections.Generic;
using NUnit.Framework;

class Passenger
{
    int    _id;
    string _firstName;
    string _lastName;
    string _typeOfTicket;

    static Dictionary<int, Passenger> AllPassengers = new Dictionary<int,Passenger>();

    /// <summary>
    /// Инициализирует пассажира по номеру паспорта, имени, фамилии и типу билета.
    /// </summary>
    /// <param name="ID">Номер паспорта.</param>
    /// <param name="FirstName">Имя.</param>
    /// <param name="LastName">Фамилия.</param>
    /// <param name="TypeOfTicket">Тип билета.</param>
    public Passenger(int ID, string FirstName, string LastName,  string TypeOfTicket)
    {
        this.ID           = ID;
        this.FirstName    = FirstName;
        this.LastName     = LastName;
        this.TypeOfTicket = TypeOfTicket;
    }

    /// <summary>
    /// Добавляет пассажира в статический словарь AllPassengers.
    /// </summary>
    /// <param name="ID">Номер паспорта.</param>
    /// <param name="ThePassenger">Пассажир.</param>
    public void Add()
    {
        AllPassengers.Add(this.ID, this);
    }

    /// <summary>
    /// Выводит на консоль информацию о всех пассажирах.
    /// </summary>
    public static void Print()
    {
        Console.WriteLine("\n**********Начало**********");
        foreach (KeyValuePair<int, Passenger> kvp in AllPassengers)
        {
            Console.WriteLine("Номер паспорта: {0}", kvp.Key);
            Console.WriteLine("Имя:            {0}",kvp.Value.FirstName);
            Console.WriteLine("Фамилия:        {0}",kvp.Value.LastName);
            Console.WriteLine("Тип билета:     {0}",kvp.Value.TypeOfTicket);
            Console.WriteLine("------------------------------");
        }
        Console.WriteLine("**********Конец***********\n");
    }

    /// <summary>
    /// Возвращает номер паспорта
    /// </summary>
    public int ID
    {
        get { return _id; }
        set { if ((value >= 1000) && (value <= 9999)) _id = value; }
    }

    /// <summary>
    /// Возвращает имя пассажира.
    /// </summary>
    public string FirstName
    {  
        get { return _firstName; }
        set { if (value.Length != 0) _firstName = value; }
    }

    /// <summary>
    /// Возвращает фамилию пассажира.
    /// </summary>
    public string LastName
    {  
        get { return _lastName; }
        set { if (value.Length != 0) _lastName = value; }
    }

    /// <summary>
    /// Возвращает тип билета.
    /// </summary>
    public string TypeOfTicket
    {  
        get { return _typeOfTicket; }
        set { if (value.Length != 0) _typeOfTicket = value; }
    }
}

/// <summary>
/// Класс с тестами для конструктора и свойств класса Passenger.
/// </summary>
class TestPassenger
{
    [Test]
    public static void TPassengerConstructor([Random(1000, 2000, 50)]                       int TNumber, 
                                             [Values("Алёшина", "Румянцева", "Трофименко")] string TFirstName,
                                             [Values("Анастасия", "Ксения", "Дарья")]       string TLastName,
                                             [Values("Плацкарт", "Купе")]                   string TType)
    {
        Passenger TPassenger = new Passenger(TNumber, TFirstName, TLastName, TType);
        
        Assert.IsInstanceOf<Passenger>(TPassenger);
        Assert.AreEqual(TNumber, TPassenger.ID);
        Assert.AreEqual(TFirstName, TPassenger.FirstName);
        Assert.AreEqual(TLastName, TPassenger.LastName);
        Assert.AreEqual(TType, TPassenger.TypeOfTicket);
    }

    [Test]
    public static void TPassengerPropety([Random(-1000, 11000, 100)]                    int TNumber, 
                                         [Values("Алёшина", "Румянцева", "Трофименко")] string TFirstName,
                                         [Values("Анастасия", "Ксения", "Дарья")]       string TLastName,
                                         [Values("Плацкарт", "Купе")]                   string TType)
    {
        Passenger TPassenger = new Passenger(TNumber, TFirstName, TLastName, TType);
        
        if ((TNumber >= 1000) && (TNumber <=9999))
        { Assert.AreEqual(TNumber, TPassenger.ID); }
        else
        { Assert.AreEqual(0, TPassenger.ID); }
    }
}