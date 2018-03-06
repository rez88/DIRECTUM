using meeting.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace meeting
{
    static class MyHelper
    {
        public static List<Meeting> meet=new List<Meeting>();
        public static DateTime dtnotif;
        private static TimeSpan ts;
        public static void add(Meeting item)
            
        {
            if (meet.Count == 0) { meet.Add(item); Console.WriteLine("Запись добавлена"); }
            else
            {
                var dt = meet
                     .Select(s => s.dtstart)
                     .LastOrDefault();
                    if (item.dtstart > dt)
                    {
                        meet.Add(item);
                        Console.WriteLine("Запись добавлена");
                    }
                    else
                    {
                        Console.WriteLine("Встречи пересекаются, укажите другое время и дату");
                    }

                
            }
        }
        public static void Display()
        {if (meet != null)
            {
                Console.WriteLine("| № |   Дата Начала встречи  |  Дата оканчания встречи  |  Примечание |");
                foreach (var item in meet)
                {
                   
                    Console.WriteLine("| "+item.id + " |    " + item.dtstart + "    |    " + item.dtend + "    |    " + item.name+ "    |");
                }
            }
        else { Console.WriteLine("Список встреч пустой"); }
        }
        public static void delete(int ind) {
            if (meet.Count >= ind)
                meet.RemoveAt(ind);
            else
                Console.WriteLine($"Встреча с номером {ind} не найдена");
            Console.WriteLine("Запись удалена");

        }
        public static void Edit(Meeting item) {
            meet.RemoveAt(item.id);
            meet.Add(item);
            Console.WriteLine(item.id + " " + item.dtstart + " " + item.dtend + " " + item.name);
            Console.WriteLine("Запись изменена");

        }
        public static void Export(DateTime dtexp)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("meeting.txt", true))
            {
                
                var mt = meet.Where(s => s.dtstart == dtexp);
                file.WriteLine("| № |   Дата Начала встречи  |  Дата оканчания встречи  |  Примечание |");
                foreach (var item in mt)
                {
                    file.WriteLine("| " + item.id.ToString() + " |    " + item.dtstart.ToString() + "    |    " + item.dtend.ToString() + "    |    " + item.name.ToString() + "    |");
                }
            }
        }
        public static void Display(int ind)
        {
            
            foreach (var item in meet)
            {
                item.id = ind;
                Console.WriteLine(item.id + " " + item.dtstart + " " + item.dtend + " " + item.name);
            }
        }

        public static void Notif(TimeSpan dt) {
            
            DateTime ind = meet
                .Where(s => s.dtstart >= DateTime.Now)
                .FirstOrDefault()
                .dtstart;
            dtnotif = ind.Date + ts;
            var not =dtnotif-DateTime.Now;
            Console.WriteLine("Уведомление о предстоящей встрече создано, будет отображено через"+not.ToString());
        }
        public static int count() { return meet.Count; }
       

    }
}
