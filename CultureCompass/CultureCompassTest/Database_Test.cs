using CultureCompass.Database;
using CultureCompass.Information;

namespace CultureCompassTest
{
    public class Database_Test
    {
        private DatabaseManager _databaseManager;

        public Database_Test() 
        {
            _databaseManager = new DatabaseManager();
        }

        [Fact]
        public void TestDeleteAllWaypoints()
        {
            _databaseManager.DeleteAllWaypoints();
            Assert.Empty(_databaseManager.GetAllWaypoints());
        }

        [Fact]
        public void TestCreateWaypoint()
        {
            Waypoint waypoint = new Waypoint
            {
                ID = 1,
                Name = "Test",
                Year = 2024,
                ImagePath = "test.jpg",
                InfoEnglish = "info in English",
                InfoDutch = "info in Dutch",
                InfoFrench = "info in French",
                X = 51.58905,
                Y = 4.774812
            };
            int id = _databaseManager.AddWaypoint(waypoint);

            Waypoint newWaypoint = _databaseManager.GetWaypoint(id);
            Assert.NotNull(newWaypoint);
            Assert.Equal(id, newWaypoint.ID);
        }

        [Fact]
        public void TestReadWaypoints()
        {
            Waypoint waypoint = new Waypoint
            {
                ID = 1,
                Name = "Test",
                Year = 2024,
                ImagePath = "test.jpg",
                InfoEnglish = "info in English",
                InfoDutch = "info in Dutch",
                InfoFrench = "info in French",
                X = 51.58905,
                Y = 4.774812
            }; 
            int id = _databaseManager.AddWaypoint(waypoint);
            var result = _databaseManager.GetWaypoint(id);
            Assert.NotNull(result);
            Assert.IsType<Waypoint>(result);
        }

        [Fact]
        public void TestUpdateWaypoint()
        {
            Waypoint waypoint = new Waypoint
            {
                ID = 1,
                Name = "Test",
                Year = 2024,
                ImagePath = "test.jpg",
                InfoEnglish = "info in English",
                InfoDutch = "info in Dutch",
                InfoFrench = "info in French",
                X = 51.58905,
                Y = 4.774812
            };
            int id = _databaseManager.AddWaypoint(waypoint);
            Waypoint updatedPoint = new Waypoint
            {
                ID = id,
                Name = "Updated Test",
                Year = 2024,
                ImagePath = "updated_test.jpg",
                InfoEnglish = "Updated info in English",
                InfoDutch = "Updated info in Dutch",
                InfoFrench = "Updated info in French",
                X = 51.58905,
                Y = 4.774812
            };
            _databaseManager.UpdateWaypoint(updatedPoint);

            Waypoint waypointTable = _databaseManager.GetWaypoint(id);
            Assert.NotNull(waypointTable);
            Assert.NotEqual(waypoint.Name, waypointTable.Name);
        }

        [Fact]
        public void TestDeleteWaypoint()
        {
            Waypoint waypoint = new Waypoint
            {
                ID = 1,
                Name = "Test",
                Year = 2024,
                ImagePath = "test.jpg",
                InfoEnglish = "info in English",
                InfoDutch = "info in Dutch",
                InfoFrench = "info in French",
                X = 51.58905,
                Y = 4.774812
            };
            int id = _databaseManager.AddWaypoint(waypoint);
            waypoint.ID = id;
            _databaseManager.DeleteWaypoint(waypoint);

            var result = _databaseManager.GetWaypoint(id);
            Assert.Null(result);
        }
    }
}
