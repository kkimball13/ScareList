using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models.Requests.Haunts;
using System.Data;
using WebApplication1.Services;
using Sabio.Data;
using WebApplication1.Domain;

namespace WebApplication1.Services.Haunts
{
    public class HauntService : BaseService
    {
        public static int Insert(HauntAddRequest model)
        {
            int uid = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Haunts_Insert",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)

                {
                    paramCollection.AddWithValue("@Name", model.Name);
                    paramCollection.AddWithValue("@AddressLine1", model.AddressLine1);
                    paramCollection.AddWithValue("@AddressLine2", model.AddressLine2);
                    paramCollection.AddWithValue("@City", model.City);
                    paramCollection.AddWithValue("@State", model.State);
                    paramCollection.AddWithValue("@Zipcode", model.Zipcode);
                    paramCollection.AddWithValue("@URL", model.URL);
                    paramCollection.AddWithValue("@Description", model.Description);

                    SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    p.Direction = System.Data.ParameterDirection.Output;

                    paramCollection.Add(p);
 
                }, returnParameters: delegate (SqlParameterCollection param)
                {
                    int.TryParse(param["@Id"].Value.ToString(), out uid);

                }
                
                );

            return uid;

        }

        public static List<Haunt> GetAll()
        {

            List<Haunt> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Haunts_SelectAll"
                , inputParamMapper: null
                , map: delegate (IDataReader reader, short set)
                {
                    Haunt p = new Domain.Haunt();
                    int startingIndex = 0;

                    p.Id = reader.GetSafeInt32(startingIndex++);
                    p.Name = reader.GetSafeString(startingIndex++);
                    p.AddressLine1 = reader.GetSafeString(startingIndex++);
                    p.AddressLine2 = reader.GetSafeString(startingIndex++);
                    p.City = reader.GetSafeString(startingIndex++);
                    p.State = reader.GetSafeString(startingIndex++);
                    p.Zipcode = reader.GetSafeString(startingIndex++);
                    p.URL = reader.GetSafeString(startingIndex++);
                    p.Description = reader.GetSafeString(startingIndex++);

                    if (list == null)
                    {
                        list = new List<Haunt>();
                    }

                    list.Add(p);

                }

                );

            return list;

        }



    }
}