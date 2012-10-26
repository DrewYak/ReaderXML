using System;
using System.Collections.Generic;
using System.Xml;
using NUnit.Framework;

/// <summary>
/// Предоставляет методы работы с данными о пассажирах.
/// </summary>
[TestFixture]
class Passenger
{
    int    _id;
    string _firstName;
    string _lastName;
    string _typeOfTicket;

    /// <summary>
    /// Статический словарь класса Passenger, хранящий информацию обо всех пассажирах.
    /// </summary>
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
    /// Инициализирует пассажира "Иван" "Иванов" с номером паспорта 9999 и типом билета "Плацкарт".
    /// </summary>
    public Passenger()
    {
        this.ID             = 9999;
        this.FirstName      = "Иван";
        this.LastName       = "Иванов";
        this.TypeOfTicket   = "Плацкарт";
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
        Console.WriteLine("\n**********Начало**********\n");
        if (AllPassengers.Count == 0)
        {
            Console.WriteLine("       Словарь пуст!       \n");
        }
        else
        {
            foreach (KeyValuePair<int, Passenger> kvp in AllPassengers)
            {
                Console.WriteLine("Номер паспорта: {0}", kvp.Key);
                Console.WriteLine("Имя:            {0}",kvp.Value.FirstName);
                Console.WriteLine("Фамилия:        {0}",kvp.Value.LastName);
                Console.WriteLine("Тип билета:     {0}\n",kvp.Value.TypeOfTicket);
                //Console.WriteLine("------------------------------");
            }
        }
        Console.WriteLine("**********Конец***********\n");
    }

    /// <summary>
    /// Добавляет данные из XML-файла в статический словарь AllPassengers класса Passenger.
    /// </summary>
    /// <param name="FileName">Имя XML-файла.</param>
    
    public static void AddDataFromFile(string FileName)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(FileName);

        XmlNodeList ListID              = doc.GetElementsByTagName("ID");
        XmlNodeList ListFName           = doc.GetElementsByTagName("FName");
        XmlNodeList ListLName           = doc.GetElementsByTagName("LName");
        XmlNodeList ListTipeOfTicket    = doc.GetElementsByTagName("TypeOfTicket");

        for (int i = 0; i < ListID.Count; i++)
        {
            Passenger ThePassenger      = new Passenger();

            ThePassenger.ID             = Convert.ToInt32(ListID[i].InnerText);
            ThePassenger.FirstName      = ListFName[i].InnerText;
            ThePassenger.LastName       = ListLName[i].InnerText;
            ThePassenger.TypeOfTicket   = ListTipeOfTicket[i].InnerText;

            ThePassenger.Add();
        }
    }

    /// <summary>
    /// Возвращает номер паспорта.
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