using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove
{
    internal class MoveCrud
    {
        SqlConnection sqlCon;

        public MoveCrud(string connectionString)
        {
            sqlCon = new SqlConnection(connectionString);
        }

        public List<Move> selectExercises()
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

        public void insert(Move move)
        {
            string queryStatement = "INSERT INTO dbo.move VALUES " +
                                    "(" + move.name + ", " + move.description + ", " + move.sweatRate + ")";

            SqlCommand command = new SqlCommand(queryStatement, sqlCon);
            sqlCon.Open();
            command.ExecuteNonQuery();
            sqlCon.Close();
        }

        // TODO update function
        // TODO delete function
    }
}
