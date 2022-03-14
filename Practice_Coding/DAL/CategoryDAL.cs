using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Practice_Coding.Models;

namespace Practice_Coding.DAL
{
	public static class CategoryDAL
	{
		public static Categories GetAll()
		{
			List<SqlParameter> Params = new List<SqlParameter>();
			return DALBase.ExecuteObject<Categories>("Categories_Get", Params);
		}
		public static Categories Amounts()
		{
			List<SqlParameter> Params = new List<SqlParameter>();
			return DALBase.ExecuteObject<Categories>("Categories_Current_Totals", Params);
		}

		public static void Save(Category SaveObj)
		{
			List<SqlParameter> Params = new List<SqlParameter>();
			if (SaveObj.CategoryID > 0) {
				Params.Add(new SqlParameter() { ParameterName = "CategoryID", DbType = System.Data.DbType.Int32, Value = SaveObj.CategoryID });
			}
			Params.Add(new SqlParameter() { ParameterName = "CategoryName", DbType = System.Data.DbType.String, Value = SaveObj.CategoryName });
			Params.Add(new SqlParameter() { ParameterName = "Active", DbType = System.Data.DbType.Boolean, Value = SaveObj.Active });
			DALBase.ExecuteSQL("Categories_Save", Params);
		}
				
	}
}