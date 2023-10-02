using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Payment.Ultils.Extensions
{
    public static class DataTableExtension
    {
        public static T AsObject<T> (this DataRow row)
        {
			try
			{
				Type type = typeof(T);
				T obj = Activator.CreateInstance<T>();

				foreach(DataColumn column in row.Table.Columns)
				{
					foreach(PropertyInfo pro in type.GetProperties())
					{
						if(pro.Name == column.ColumnName && row[column.ColumnName]!= DBNull.Value)
						{
							try
							{
								pro.SetValue(obj, Convert.ChangeType(row[column.ColumnName], pro.PropertyType));

							}
							catch (Exception ex)
							{
								pro.SetValue(obj, null);
							}
						}
					}
				}
				return obj;
			}
			catch (Exception)
			{
				return default(T);
			}
        }

		public static List<T> AsListObject<T>(this DataTable table)
		{
			if (table == null)
				return null;
			var result = new List<T>();
			foreach (DataRow row in table.Rows)
			{
				var obj = row.AsObject<T>();
				result.Add(obj);
			}
				return result;
		}
    }
}
