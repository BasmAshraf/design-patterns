using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace State_Design_Pattern.Logic
{
    public class PendingState : BookingState
    {
        private CancellationTokenSource cancellationToken;
        public override void Cancel(BookingContext booking)
        {
            cancellationToken.Cancel();
        }

        public override void DatePassed(BookingContext booking)
        {
            booking.TransationToState(new ClosedState("Event is expired"));
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            booking.View.ShowError("Invalid action", "Pending Booking");
        }

        public override void EnterState(BookingContext booking)
        {
            cancellationToken = new CancellationTokenSource();
            booking.ShowState("Pending");
            booking.View.ShowStatusPage("Processing booking");
            StaticFunctions.ProcessBooking(booking, ProcessingComplete, cancellationToken);
        }

        private void ProcessingComplete(BookingContext booking, ProcessingResult result)
        {
            switch (result)
            {
                case ProcessingResult.Sucess:
                    booking.TransationToState(new BookedState());
                    break;
                case ProcessingResult.Fail:
                    booking.View.ShowProcessingError();
                    booking.TransationToState(new NewState());
                    break;
                case ProcessingResult.Cancel:
                    booking.TransationToState(new ClosedState("Processing Canceled"));
                    break;
            }
        }
    }
}
