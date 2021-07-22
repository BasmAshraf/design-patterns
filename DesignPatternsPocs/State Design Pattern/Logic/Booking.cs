using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using State_Design_Pattern.UI;

namespace State_Design_Pattern.Logic
{
    public class Booking
    {
        private MainWindow View { get; set; }
        public string Attendee { get; set; }
        public int TicketCount { get; set; }
        public int BookingID { get; set; }
        private bool isNew;
        private bool isPending;
        private bool isBooked;

        private CancellationTokenSource cancelToken;

        public Booking(MainWindow view)
        {
            View = view;
            BookingID = new Random().Next();
            view.ShowEntryPage();
            ShowState("New");
            isNew = true;
        }

        public void SubmitDetails(string attendee, int ticketCount)
        {
            isNew = false;
            isPending = true;
            Attendee = attendee;
            TicketCount = ticketCount;
            cancelToken = new CancellationTokenSource();
            StaticFunctions.ProcessBooking(this, ProcessingComplete, cancelToken);
            ShowState("Pending");
            View.ShowStatusPage("Processing booking");
        }

        public void Cancel()
        {
            if (isNew)
            {
                ShowState("Closed");
                View.ShowStatusPage("Canceled by user");
                isNew = false;
            }
            else if (isPending)
            {
                cancelToken.Cancel();
            }
            else if (isBooked)
            {
                ShowState("Closed");
                View.ShowStatusPage("Booking canceled: Expect a refund");
                isBooked = false;
            }
            else
            {
                View.ShowError("Closed bookings can't be canceled");
            }
        }

        public void DatePassed()
        {
            if (isNew)
            {
                ShowState("Closed");
                View.ShowStatusPage("Booking is expired");
                isNew = false;
            }
            else if(isBooked)
            {
                ShowState("Closed");
                View.ShowStatusPage("Hope you enjoyed the event");
                isBooked = false;
            }
        }

        public void ProcessingComplete(Booking booking, ProcessingResult result)
        {
            isPending = false;
            switch (result)
            {
                case ProcessingResult.Sucess:
                    isBooked = true;
                    ShowState("Booked");
                    View.ShowStatusPage("Enjoy the Event");
                    break;
                case ProcessingResult.Fail:
                    View.ShowProcessingError();
                    Attendee = string.Empty;
                    BookingID = new Random().Next();
                    isNew = true;
                    ShowState("New");
                    View.ShowEntryPage();
                    break;
                case ProcessingResult.Cancel:
                    ShowState("Closed");
                    View.ShowStatusPage("Processing Canceled");
                    break;
            }
        }

        public void ShowState(string stateName)
        {
            View.grdDetails.Visibility = System.Windows.Visibility.Visible;
            View.lblCurrentState.Content = stateName;
            View.lblTicketCount.Content = TicketCount;
            View.lblAttendee.Content = Attendee;
            View.lblBookingID.Content = BookingID;
        }



    }
}


