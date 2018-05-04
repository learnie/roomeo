namespace Roomeo.Reservation
{
    public interface IReservationRepository
    {
        void Delete(int roomId);
        bool Exists(int roomId);
    }
}