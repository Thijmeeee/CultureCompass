using CultureCompass.Information;
using SQLite;

namespace CultureCompass.Database
{
    internal class Database
    {
        public Database()
        {
            string filename = Environment.CurrentDirectory + "/database.db";
            SQLiteConnection connection = new SQLiteConnection(filename);
        }

        private void AddWaypoint(Waypoint point)
        {

        }

        private void DeleteWaypoint(int pointId)
        {

        }

        private void UpdateWaypoint(Waypoint updatedPoint, int oldPointId)
        {

        }
    }

}
