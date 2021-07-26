namespace MediatorDemo.Structure
{
    public abstract class Colleague
    {
        public Medicator Medicator { get; set; }
        public void SetMediator(Medicator medicator)
        {
            Medicator = medicator;
        }
        public void Send(string message)
        {
            Medicator.Send(message, this);
        }

        public abstract void HandleNotification(string message);
    }
}
