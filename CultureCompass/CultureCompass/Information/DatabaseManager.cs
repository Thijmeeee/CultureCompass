using CultureCompass.Database;

namespace CultureCompass.Information
{
    internal class DatabaseManager
    {
        private Database.Database database;

        public DatabaseManager(Database.Database database)
        {
            this.database = database;
        }
        private Waypoint GetWaypoint(string name)
        {
            return database.ReadWaypoint(name);
        }

        private List<Waypoint> GetAllWaypoints(int pointId)
        {
            return database.ReadWaypoints();
        }

        private void AddWaypoint(Waypoint point)
        {
            database.CreateWaypoint(point);
        }

        private void DeleteWaypoint(Waypoint point)
        {
            database.DeleteWaypoint(point);
        }

        private void UpdateWaypoint(Waypoint updatedWaypoint)
        {
            WaypointTable updatedReceived = new WaypointTable()
            {
                WaypointId = updatedWaypoint.ID,
                Name = updatedWaypoint.Name,
                YearCreated = 6969,
                PictureName = updatedWaypoint.ImagePath,
                InfoEnglish = updatedWaypoint.InfoEnglish,
                InfoDutch = updatedWaypoint.InfoDutch,
                InfoFrench = updatedWaypoint.InfoFrench,
                XCoordinate = updatedWaypoint.X,
                YCoordinate = updatedWaypoint.Y
            };
            database.UpdateWaypoint(updatedReceived);
        }

        

    }
}
