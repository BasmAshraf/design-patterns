using System.Linq;

namespace MediatorDemo.Structure
{
    public class MediatorConcreate : Medicator
    {
        public override T CreateColleague<T>()
        {
            var c = new T();
            c.SetMediator(this);
            Colleagues.Add(c);
            return c;
        }

        public override void Send(string messagee, Colleague colleague)
        {
            Colleagues?.Where(c => c != colleague)
                             .ToList()
                             .ForEach(c => c.HandleNotification(messagee));
        }
    }
}
