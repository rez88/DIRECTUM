using meeting.Interfaces;
using meeting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meeting
{
    

    class Program
    {
        public static void Main(string[] args)
        {
            if (DateTime.Now == MyHelper.dtnotif)
            {
                var mt = MyHelper.meet
                    .Where(s => s.dtstart >= DateTime.Now)
                    .FirstOrDefault()
                    .name;
                    Console.WriteLine("Ожидается встреча "+mt);
            }
            Label:
            var core = new Core();
            var oper = core.GetOperNames();
            Console.WriteLine("Встреча");
            Console.WriteLine("Выберите действие: ");
            foreach (var item in oper)
            {
                Console.WriteLine(item);
            }
            int op = Convert.ToInt32(Console.ReadLine());

            switch (op) {
                case 1: {
                        Console.Clear();
                        MyHelper.Display();
                        Console.ReadKey();
                    }; break;

                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Номер встречи №"+MyHelper.count());
                        Console.WriteLine("Введите дату и время начала встречи");
                dtstart:DateTime dtsatrt = Convert.ToDateTime(Console.ReadLine());
                        if (dtsatrt <= DateTime.Now) { Console.WriteLine("Запланируйте встречи только на будущее"); goto dtstart; }
                        Console.WriteLine("Введите дату и время оканчания встречи");
                  dtend:DateTime dtend = Convert.ToDateTime(Console.ReadLine());
                        if (dtend <= dtsatrt) { Console.WriteLine("ЭЭЭ, укажите правильно дату оканчанния встречи"); goto dtend; }
                        Console.WriteLine("Введите название встречи");
                        string name = Console.ReadLine();
                        var item = new Meeting();
                        item.id = MyHelper.count();
                        item.dtstart = dtsatrt;
                        item.dtend = dtend;
                        item.name = name;
                        MyHelper.add(item);
                        MyHelper.Display();
                }; break;
                case 3:
                    {   if (MyHelper.meet.Count == 0)
                        {
                            Console.WriteLine("Нет записей для удаления");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Укажите индекс записи, которую хотите удалить");
                            int ind = Convert.ToInt32(Console.ReadLine());
                            MyHelper.delete(ind);
                        }
                    }; break;
                case 4: {
                            if (MyHelper.meet.Count == 0)
                            {
                                Console.WriteLine("Нет записей");
                            }
                            else
                            {
                                Console.Clear();
                                MyHelper.Display();
                                Console.WriteLine("Укажите номер встречи, который хотите отредактировать");
                                int ind = Convert.ToInt32(Console.ReadLine());
                                var it = new Meeting();
                                var mt = MyHelper.meet.Where(s => s.id == ind);
                                foreach (var item in mt.ToArray())
                                {
                                    Console.WriteLine("Номер встречи №" + item.id);
                                    it.id = item.id;
                                    Console.WriteLine("Измените дату и время начала встречи" + "\n" + item.dtstart);
                                    it.dtstart = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("Измените дату и время оканчания встречи" + "\n" + item.dtend);
                                    it.dtend = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("Измените название встречи " + "\n" + item.name);
                                    it.name = Console.ReadLine();

                                    MyHelper.Edit(it);
                                }
                            }
                    }; break;
                case 5: {

                        if (MyHelper.meet.Count == 0)
                        {
                            Console.WriteLine("Нет записей");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Экспортировать в текстовый файл\n" + "Укажите дату, за который необходимо экспортировать встречи");
                            DateTime dtexp = Convert.ToDateTime(Console.ReadLine());
                            MyHelper.Export(dtexp);
                        }
                    };break;
                case 6: {
                        if (MyHelper.meet.Count == 0)
                        {
                            Console.WriteLine("Нет записей");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Укажите время уведомления о встрече");
                            TimeSpan dt = TimeSpan.Parse(Console.ReadLine());
                            MyHelper.Notif(dt);
                        }
                    };break;
            }
            
            goto Label;
        }  

    }
}
