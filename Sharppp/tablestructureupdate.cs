using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace SHARP_ACCOUNTING
{
    class tablestructureupdate
    {
        public static string temp_word, field_name, field_type;

        public static string mtbname;

        private bool TableExists(string database, string name)
        {
            string strCmd = null;
            //SqlCommand sqlCmd = null;

            try
            {
                strCmd = "select case when exists((select '['+SCHEMA_NAME(schema_id)+'].['+name+']' As name FROM [" + database + "].sys.tables WHERE name = '" + name + "')) then 1 else 0 end";
                //sqlCmd = new SqlCommand(strCmd, conn);

                return (int)ConnectionWithAccess.command.ExecuteScalar() == 1;
                //return (int)sqlCmd.ExecuteScalar() == 1;
            }
            catch { return false; }
        }

        public static void update_all_tables()
        {
            if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
            //ConnectionWithAccess.mtextfilename = mDRIVE + "acc\\table_structure.txt";
            //ConnectionWithAccess.mtextfilename = ConnectionWithAccess.data_drive + "visual studio\\projects\\sharp\\table_structure.txt";
            ConnectionWithAccess.mtextfilename = ConnectionWithAccess.setup_drive + "sharp\\table_structure.txt";
            if (File.Exists(ConnectionWithAccess.mtextfilename))
            {
                var lines = File.ReadAllLines(ConnectionWithAccess.mtextfilename);
                for (int i = 0; i < lines.Count(); i++)
                {
                    if (lines[i] != null)
                    {
                        temp_word = lines[i];
                        if (temp_word.Substring(0, 4) == "ADD_")
                        {
                            string struction_sintex, query;
                            int space_posi;
                            //mtbname = ConnectionWithAccess.mNIK + "_0001";
                            mtbname = ConnectionWithAccess.mNIK + temp_word;
                            mtbname = mtbname.Replace("ADD", "");
                            i++;
                            struction_sintex = lines[i];
                            var cellArray = struction_sintex.Split(new[] { ';' });
                            for ( int j = 0; j < cellArray.Length; j++)
                            {
                                temp_word = cellArray[j].Trim();
                                if (temp_word == "item_squ_id COUNTER")
                                    query = "";
                                if (temp_word.Contains(" "))
                                {
                                    space_posi = temp_word.IndexOf(" ");
                                    field_name = temp_word.Substring(0, space_posi);
                                    field_type = temp_word.Substring(space_posi, temp_word.Length - space_posi);
                                    //ConnectionWithAccess.query = "SELECT * FROM " + mtbname + " WHERE 1 = 0";
                                    //ConnectionWithAccess.command.CommandText = ConnectionWithAccess.query;
                                    ConnectionWithAccess.command.CommandText = "SELECT * FROM " + mtbname + " WHERE 1 = 0";
                                    try
                                    {
                                        ConnectionWithAccess.connection.Open();
                                        ConnectionWithAccess.command.ExecuteNonQuery();
                                        ConnectionWithAccess.connection.Close();
                                        if (field_type.Trim() == "bigint")
                                            field_type = "long";
                                        ConnectionWithAccess.query = "alter table " + mtbname + " alter column " + field_name + " " + field_type;
                                        try
                                        {
                                            if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
                                            ConnectionWithAccess.command.CommandText = ConnectionWithAccess.query;
                                            ConnectionWithAccess.connection.Open();
                                            ConnectionWithAccess.command.ExecuteNonQuery();
                                            ConnectionWithAccess.connection.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
                                            if (field_type.Trim() == "bigint")
                                                field_type = "long";
                                            ConnectionWithAccess.query = "alter table " + mtbname + " add " + field_name + " " + field_type;
                                            ConnectionWithAccess.command.CommandText = ConnectionWithAccess.query;
                                            ConnectionWithAccess.connection.Open();
                                            ConnectionWithAccess.command.ExecuteNonQuery();
                                            ConnectionWithAccess.connection.Close();
                                        }
                                    }
                                    catch
                                    {
                                        struction_sintex = struction_sintex.Replace(";", ",");
                                        struction_sintex = struction_sintex.Replace("bigint", "long");
                                        //struction_sintex = struction_sintex.Substring(0, struction_sintex.Length - 1);
                                        query = "create table " + mtbname + "(" + struction_sintex + ")";
                                        try
                                        {
                                            ConnectionWithAccess.query = query;
                                            ConnectionWithAccess.connectAndUseQuery();
                                            ConnectionWithAccess.connection.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                        finally
                                        {
                                            if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
                                        }
                                    }
                                }
                            }
                        }
                        else if (temp_word.Length > 9 && temp_word.Substring(0, 7) == "REMOVE_")
                        {
                            string struction_sintex;
                            int space_posi;
                            mtbname = ConnectionWithAccess.mNIK + temp_word;
                            mtbname = mtbname.Replace("REMOVE", "");
                            struction_sintex = lines[i + 1];
                            var cellArray = struction_sintex.Split(new[] { ';' });
                            for (int j = 0; j < cellArray.Length; j++)
                            {
                                temp_word = cellArray[j].Trim();
                                if (temp_word.Contains(" "))
                                {
                                    space_posi = temp_word.IndexOf(" ");
                                    field_name = temp_word.Substring(0, space_posi);
                                    field_type = temp_word.Substring(space_posi, temp_word.Length - space_posi);
                                    //ConnectionWithAccess.command.CommandText = "SELECT * FROM " + mtbname + " WHERE 1 = 0";
                                    try
                                    {
                                        //ConnectionWithAccess.connection.Open();
                                        //ConnectionWithAccess.command.ExecuteNonQuery();
                                        //ConnectionWithAccess.connection.Close();
                                        ConnectionWithAccess.query = "alter table " + mtbname + " drop column " + field_name;
                                        try
                                        {
                                            ConnectionWithAccess.command.CommandText = ConnectionWithAccess.query;
                                            ConnectionWithAccess.connection.Open();
                                            ConnectionWithAccess.command.ExecuteNonQuery();
                                            ConnectionWithAccess.connection.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                    if (ConnectionWithAccess.connection.State == ConnectionState.Open) { ConnectionWithAccess.connection.Close(); }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
