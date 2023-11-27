using MedMartExpressApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace MedMartExpressApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AdminsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("addUpdateMedicine")]
        public Response addUpdateMedicine(Medicine medicine)
        {
            AppDbMangar _dbmang = new AppDbMangar();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("MedMartCS").ToString());
            return _dbmang.addUpdateMedicine(medicine, conn);
        }
        [HttpGet]
        [Route("allUsers")]
        public Response allUsers()
        {
            AppDbMangar _dbmang = new AppDbMangar();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("MedMartCS").ToString());
            return _dbmang.allUsers(conn);
        }
    }
}
