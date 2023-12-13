using CultureCompass.Database;

namespace CultureCompass.Information
{
    internal class DatabaseManager
    {
        public Database.Database database {  get; set; }

        public Waypoint GetWaypoint(int pointId)
        {
            return database.ReadWaypoint(pointId);
        }

        public List<Waypoint> GetAllWaypoints(int pointId)
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
