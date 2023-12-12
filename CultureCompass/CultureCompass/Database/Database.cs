using CultureCompass.Information;
using SQLite;

namespace CultureCompass.Database
{
    internal class Database
    {
        private SQLiteConnection _connection;
        public Database()
        {
            string filename = Environment.CurrentDirectory + "/database.db";
            _connection = new SQLiteConnection(filename);
        }

        private void AddWaypoint(Waypoint point)
        {
            if (point != null)
            {
                WaypointTable waypoint = new WaypointTable()
                {
                    WaypointId = point.WaypointId,
                    Name = point.Name,
                    YearCreated = point.YearCreated,
                    PictureName = point.PictureName,
                    InfoEnglish = point.InfoEnglish,
                    InfoDutch = point.InfoDutch,
                    InfoFrench = point.InfoFrench,
                    XCoordinate = point.XCoordinate,
                    YCoordinate = point.YCoordinate
                };
                _connection.Insert(waypoint);
            }
        }

        private void DeleteWaypoint(Waypoint point)
        {
            if (point != null)
            {
                WaypointTable waypoint = new WaypointTable()
                {
                    WaypointId = point.WaypointId,
                    Name = point.Name,
                    YearCreated = point.YearCreated,
                    PictureName = point.PictureName,
                    InfoEnglish = point.InfoEnglish,
                    InfoDutch = point.InfoDutch,
                    InfoFrench = point.InfoFrench,
                    XCoordinate = point.XCoordinate,
                    YCoordinate = point.YCoordinate
                };
                _connection.Delete<WaypointTable>(waypoint.WaypointId);
            }
        }

        private void UpdateWaypoint(Waypoint updatedPoint, int oldPointId)
        {
            
        }
    }

}
