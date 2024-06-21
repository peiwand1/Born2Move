using System.Data.SqlClient;

namespace BornToMove
{
    public sealed class MoveCrud
    {
        private static MoveCrud? _instance = null;
        SqlConnection sqlCon;

        private MoveCrud()
        {
            sqlCon = new SqlConnection("server=(localdb)\\ProjectModels;database=born2move;");
        }

        public static MoveCrud GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MoveCrud();
            }
            return _instance;
        }

        /**
         * returns move table from db as List of Move objects
         */
        public List<Move> SelectExercises()
        {
            string queryStatement = "SELECT * " +
                                    "FROM dbo.move " +
                                    "ORDER BY id ASC";

            List<Move> result = new List<Move>();

            SqlCommand command = new SqlCommand(queryStatement, sqlCon);
            sqlCon.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Move(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetInt32(3)));
                }
            }
            sqlCon.Close();

            return result;
        }

        /**
         * adds new move to move table
         */
        public void Insert(Move move)
        {
            string queryStatement = "INSERT INTO dbo.move VALUES " +
                                    "('" + move.name + "', '" + move.description + "', '" + move.sweatRate + "')";

            SqlCommand command = new SqlCommand(queryStatement, sqlCon);
            sqlCon.Open();
            command.ExecuteNonQuery();
            sqlCon.Close();
        }

        // TODO update function
        // TODO delete function
    }
}
