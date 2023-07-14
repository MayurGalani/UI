namespace NEw
{
    internal class SqlCommand
    {
        private string query;
        private SqlConnection connection;

        public SqlCommand(string query, SqlConnection connection)
        {
            this.query = query;
            this.connection = connection;
        }
    }
}