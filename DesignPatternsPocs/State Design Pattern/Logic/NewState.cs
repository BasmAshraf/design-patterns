using System;

namespace State_Design_Pattern.Logic
{
    public class NewState : BookingState
    {
        public override void Cancel(BookingContext booking)
        {
            booking.TransationToState(new ClosedState("Event is canceled by user"));
        }

        public override void DatePassed(BookingContext booking)
        {
            booking.TransationToState(new ClosedState("Event is expired"));
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            booking.Attendee = attendee;
            booking.TicketCount = ticketCount;
            booking.TransationToState(new PendingState());
        }

        public override void EnterState(BookingContext booking)
        {
            booking.BookingID = new Random().Next();
            booking.ShowState("New");
            booking.View.ShowEntryPage();
        }
    }
}
