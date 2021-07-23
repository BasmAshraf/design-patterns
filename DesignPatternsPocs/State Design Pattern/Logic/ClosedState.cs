using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Design_Pattern.Logic
{
    public class ClosedState : BookingState
    {
        private string closedReason;
        public ClosedState(string reason)
        {
            closedReason = reason;
        }
        public override void Cancel(BookingContext booking)
        {
            booking.View.ShowError("Invalid action", "Closed Booking");
        }

        public override void DatePassed(BookingContext booking)
        {
            booking.View.ShowError("Invalid action", "Closed Booking");
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            booking.View.ShowError("Invalid action", "Closed Booking");
        }

        public override void EnterState(BookingContext booking)
        {
            booking.ShowState("Closed");
            booking.View.ShowStatusPage(closedReason);
        }
    }
}
