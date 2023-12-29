using CultureCompass.Database;

namespace CultureCompass.Information
{
    public class DatabaseManager
    {
        private Database.Database database;

        public DatabaseManager()
        {
            database = new Database.Database();
 
        }

        public Waypoint GetWaypoint(int pointId)
        {
            WaypointTable waypointTable = database.ReadWaypoint(pointId);
            if (waypointTable != null)
            {
                return new Waypoint()
                {
                    ID = waypointTable.WaypointId,
                    X = waypointTable.XCoordinate,
                    Y = waypointTable.YCoordinate,
                    Name = waypointTable.Name,
                    Year = waypointTable.YearCreated,
                    ImagePath = waypointTable.PictureName,
                    InfoDutch = waypointTable.InfoDutch,
                    InfoEnglish = waypointTable.InfoEnglish,
                    InfoFrench = waypointTable.InfoFrench
                };
            }
            else return null;
        }

        public List<Waypoint> GetAllWaypoints()
        {
            return database.ReadWaypoints();
        }

        public void DeleteAllWaypoints()
        {
            database.DeleteAllWaypoints();
        }

        public int AddWaypoint(Waypoint point)
        {
            return database.CreateWaypoint(point);
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
