using System.Numerics;
using System.Runtime.CompilerServices;

class Program
{
    static List<string> nameEmployee = new List<string>() { "Евгений", "Михаил", "Екатерина", "Елизавета", "Пётр", "Ольга", "Иван", "Олег", "Артур" };
    static int[] numOfVacDays = new int[nameEmployee.Count];
    static Random random = new Random();
    static List<DateTime> dayList = new List<DateTime>();
    static void Main(string[] args)
    {
        SetNumberOfVacationDays();
        DateOfVacation();
        SetVacationDays();
    }

    static void SetNumberOfVacationDays()
    {
        for (int i = 0; i < numOfVacDays.Length; i++)
        {
            if (i % 2 == 0) numOfVacDays[i] = 7;
            else numOfVacDays[i] = 14;
        }
    }
    static DateTime DateOfVacation()
    {
        DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
        DateTime end = new DateTime(DateTime.Now.Year, 12, 31);
        int range = (end - start).Days;
        DateTime day = start.AddDays(random.Next(range));
        if (day.DayOfWeek == DayOfWeek.Saturday)
            day = day.AddDays(2);
        else if (day.DayOfWeek == DayOfWeek.Sunday)
            day = day.AddDays(1);
        return day;
    }

    static void SetVacationDays()
    {   
        DateTime datStart = new DateTime();
        DateTime datEnd = new DateTime();
        for (int i = 0;i<nameEmployee.Count;i++)
        {
            datStart = DateOfVacation();
            datEnd = datStart.AddDays(numOfVacDays[i]);
            while (dayList.Any(s => s.AddDays(14) >= datStart))
            {
                datStart = datStart.AddDays(1);
                datEnd = datStart.AddDays(numOfVacDays[i]);
            }
            dayList.Add(datStart);
            Console.WriteLine($"{nameEmployee[i]} с {dayList[i]} по {datEnd}");
        }
        Console.ReadLine();
    }
}

    

