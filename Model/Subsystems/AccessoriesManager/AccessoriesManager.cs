using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RSSE
{
    public class AccessoriesManager : Subsystem
    {
        override public SubsystemTypeEnum SystemType
        {
            get { return SubsystemTypeEnum.AccessoriesManager; }
        }
        override public string SystemGroup { get { return "Others"; } }

        public List<Speaker> Speakers;
        public List<Seat> Seats;

        public AccessoriesManager()
        {
            Speakers = new List<Speaker>();
            Seats = new List<Seat>();
        }

        public AccessoriesManager(ShipTable table)
        {
            Seats = new List<Seat>();
            Speakers = new List<Speaker>();
            GetSeats(table);
            GetSpeakers(table);
        }

        #region Loading
        private void GetSeats(ShipTable table)
        {
            int i = 1;
            while (table.shipCoords["SEAT" + i].Count > 0)
            {
                Seats.Add(new Seat(table.shipCoords["SEAT" + i]));
                i++;
            }
        }

        private void GetSpeakers(ShipTable table)
        {
            int i = 1;
            while (table.shipCoords["iSPEAKERS"]["speaker" + i].Count > 0)
            {
                Speakers.Add(new Speaker(table.shipCoords["iSPEAKERS"]["speaker" + i]));
                i++;
            }
        }
        #endregion

        #region Saving
        override public void AddToTable(ShipTable table)
        {
            AddSeats(table);
            AddSpeakers(table);
        }

        private void AddSeats(ShipTable table)
        {
            table.ship["totalSEATS"].Value = Speakers.Count;
            int i = 1;
            foreach (Seat seat in Seats)
            {
                table.shipCoords["SEAT" + i] = seat.ToTable();
                i++;
            }
        }

        private void AddSpeakers(ShipTable table)
        {
            int i = 1;
            foreach (Speaker speaker in Speakers)
            {
                table.shipCoords["iSPEAKERS"]["speaker" + i] = speaker.ToTable();
            }
        }
        #endregion

        public void AddSeat()
        {
            Seats.Add(new Seat());
        }

        public void RemoveSeat(Seat seat)
        {
            Seats.Remove(seat);
        }

        
    }
}
