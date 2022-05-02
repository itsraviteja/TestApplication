using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Test.Repository
{
    public class DepartmentRepository:Repository
    {
        public DepartmentRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<DepartmemtModel> GetDepartmemtById()
        {
            DepartmemtModel dpmodel = new DepartmemtModel();
            try
            {
                using(SqlConnection connection = await OpenDBConnection())
                {
                    dpmodel = await connection.QueryFirstOrDefaultAsync<DepartmemtModel>(StoreProcedureList.GetDepartmentDetails,
                        new { dpmodel.Department }, commandType: CommandType.StoredProcedure);
                    if (dpmodel == null) dpmodel = new DepartmemtModel();
                }
            }
            catch(Exception ex)
            { }
            return dpmodel;
        }
        public async Task<DepartmemtModel> AddUpdateOrDeleteDepartmentDetailsAsync(DepartmemtModel updateDetailsRequest)
        {
            try
            {
                using (SqlConnection connection = await OpenDBConnection())
                {
                    int retval = await connection.ExecuteAsync(StoreProcedureList.AddUpdateOrDeleteDepartmentDetails,
                        new
                        {
                            id= updateDetailsRequest.Id,
                            actiontype=updateDetailsRequest.Action,
                            name=updateDetailsRequest.Name,
                            dept=updateDetailsRequest.Department
                        }, commandType:CommandType.StoredProcedure);
                    updateDetailsRequest.ReturnVal = retval;
                }
            }
            catch(SqlException ex) { }
            return updateDetailsRequest;
        }



    }
}
