namespace richmindale_app.Server.Helpers
{
    public static class QueryBuilder
    {

        public static string SelectAllSQL(string tbl, string? cond, string order)
        {
            var sql = $@"SELECT * FROM " + tbl + " ";
            if(cond != string.Empty)
            {
                sql = sql + cond + " ";
            }
            if(order != string.Empty)
            {
                sql = sql + order + " ";
            }
            else
            {
                sql = sql + " ";
            }
            return sql;
        }
        public static string SelectSQL(string tbl, string[] columns, string? cond, string order)
        {
            string sql ="SELECT ";
            for(var i = 0;i < columns.Length;i ++)
            {
                sql = sql + columns[i] + (i == columns.Length - 1 ? " " : ", ");
            }                

            sql = sql + tbl + " ";

            if(cond != string.Empty)
            {
                sql = sql + "WHERE " + cond + " ";
            }

            if(order != string.Empty)
            {
                sql = sql + order + " ";
            }
            else
            {
                sql = sql +" ";
            }
            return sql;
        }
        public static string InsertSQL(string tbl, string[] columns)
        {
            var sql = "INSERT INTO " + tbl + "(";
            for(var i = 0;i < columns.Length;i++)
            {
                sql = sql + columns[i] + (i == columns.Length -1 ? " ) VALUES (" : ",");
            }
            for(var j = 0;j < columns.Length;j++)
            {
                sql = sql + "@" + columns[j] + (j == columns.Length -1 ? ") " : ", "); 
            }
            
            return sql;
        }
        public static string UpdateSQL(string tbl, string[] columns, string? cond)
        {
            var sql = "UPDATE " + tbl + " SET ";
            for(var i = 0;i < columns.Length;i++)
            {
                sql = sql + columns[i] + "=" + "@" + columns[i] + (i == columns.Length -1 ? " " : ",");
            }
            sql = sql + (cond != string.Empty ? " " : "WHERE " + cond + " ");
            return sql;
        }
    }
}
