using System.Collections.Generic;

namespace MediatorDemo.Structure
{
    public abstract class Medicator
    {
        public List<Colleague> Colleagues { get; set; } = new List<Colleague>();
        public abstract void Send(string messagee, Colleague colleague);
        public abstract T CreateColleague<T>() where T : Colleague, new();
    }
}
