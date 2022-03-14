using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace Practice_Coding.DAL
{
    public static class DALBase
    {
        private static string CONN_STRING = "Data Source=DESKTOP-TU5VCFH\\SQLEXPRESS;Initial Catalog=FinancialTracking;user id=Jack;password=password;";
        public static T ExecuteObject<T>(string SPName, List<SqlParameter> Params) where T : class
        {
            XmlReader reader = null;
            string resultXml = "";

            using (SqlConnection connection = new SqlConnection(CONN_STRING))
            {
                //setup the SQL Command Object
                SqlCommand command = new SqlCommand(SPName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(Params.ToArray());

                // open the connection (closed when 'using' goes out of scope)
                connection.Open();
                reader = command.ExecuteXmlReader();

                if (reader != null)
                {
                    StringWriter stringWriter = new StringWriter();
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);

                    while (!reader.EOF)
                    {
                        reader.MoveToContent();
                        xmlTextWriter.WriteNode(reader, false);
                    }

                    resultXml = stringWriter.ToString();
                }
            }

            if (!string.IsNullOrEmpty(resultXml))
            {
                return DeserializeXML<T>(resultXml);
            }
            else
            {
                return null;
            }
        }

        public static void ExecuteSQL(string SPName, List<SqlParameter> Params)
        {
            using (SqlConnection connection = new SqlConnection(CONN_STRING))
            {
                //setup the SQL Command Object
                SqlCommand command = new SqlCommand(SPName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(Params.ToArray());

                // open the connection (closed when 'using' goes out of scope)
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static T DeserializeXML<T>(string xml) where T : class
        {
            if (!string.IsNullOrEmpty(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (StringReader reader = new StringReader(xml))
                {
                    return (T)serializer.Deserialize(reader);

                }
            }

            return null;
        }
    }
}
