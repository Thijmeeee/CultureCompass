using CultureCompass.Database;

namespace CultureCompass.Information
{
    internal class DatabaseManager
    {
        private Database.Database database;

        public DatabaseManager()
        {
            database = new Database.Database();
        }

        public Waypoint GetWaypoint(int pointId)
        {
            return database.ReadWaypoint(pointId);
        }

        public List<Waypoint> GetAllWaypoints()
        {
            return database.ReadWaypoints();
        }

        public void AddWaypoint(Waypoint point)
        {
            database.CreateWaypoint(point);
        }

        public void DeleteWaypoint(Waypoint point)
        {
            database.DeleteWaypoint(point);
        }

        public void UpdateWaypoint(Waypoint updatedWaypoint)
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
