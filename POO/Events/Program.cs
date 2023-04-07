namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var room = new Room(3);
            room.RoomSoudOutEvent += OnRoomSoudOut;
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();
        }

        static void OnRoomSoudOut(object sender, EventArgs e)
        {
            Console.WriteLine("Sala lotada");
        }
    }

    class Room
    {
        public Room(int seats)
        {
            Seats = seats;
            seatsInUse = 0;
            RoomSoudOutEvent = null;
        }

        private int seatsInUse = 0;

        public int Seats { get; set; }

        public void ReserveSeat()
        {
            seatsInUse++;
            if (seatsInUse >= Seats)
            {
                OnRoomSoudOut(EventArgs.Empty);
            }
            else
            {
                Console.WriteLine("Assento reservado");
            }
        }

        public event EventHandler? RoomSoudOutEvent;

        protected virtual void OnRoomSoudOut(EventArgs e)
        {
            EventHandler? handler = RoomSoudOutEvent;
            handler?.Invoke(this, e);
        }
    }
}