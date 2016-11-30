using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models.Requests.Haunts;
using System.Data;
using WebApplication1.Services;
using Sabio.Data;

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





    }
}