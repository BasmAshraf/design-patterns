using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Design_Pattern.Logic
{
    public class BookedState : BookingState
    {
        public override void Cancel(BookingContext booking)
        {
            booking.TransationToState(new ClosedState("Booking canceled: Expect a refund"));
        }

        public override void DatePassed(BookingContext booking)
        {
            booking.TransationToState(new ClosedState("Hope you enjoyed the event"));
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            booking.View.ShowError("Invalid action", "Booked Event");
        }

        public override void EnterState(BookingContext booking)
        {
            booking.ShowState("Booked");
            booking.View.ShowStatusPage("Enjoy the Event");
        }
    }
}
