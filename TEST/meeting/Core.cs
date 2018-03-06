using meeting.Interfaces;
using meeting.Model;
using meeting.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace meeting
{
    public class Core
    {
        private IList<IOperation> oper { get; set; }
        public Core()
        {
            oper = new List<IOperation>();
            LoadOperation(Assembly.GetExecutingAssembly());
        }
        private void LoadOperation(Assembly assembly)
        {
            var types = assembly.GetTypes();
            var typeOperation = typeof(IOperation);

            foreach (var item in types.Where(t => !t.IsAbstract && !t.IsInterface))
            {
                var interfaces = item.GetInterfaces();

                var isOperation = interfaces.Any(it => it == typeOperation);

                if (isOperation)
                {
                    // создаем эксземпляр объекта
                    var obj = Activator.CreateInstance(item);
                    // пытаемся превратить его в операцию
                    var operation = obj as IOperation;
                    // если удалось
                    if (operation != null)
                    {
                        // добавляем в список операций
                        oper.Add(operation);
                    }
                }

            }
        }
        public IOperation[] GetOpers()
        {
            oper = new List<IOperation>();
            return oper.ToArray();
        }
        public string[] GetOperNames()
        {
            return oper.Select(it => it.id + " "+it.name).ToArray();
        }
       
           }
}
