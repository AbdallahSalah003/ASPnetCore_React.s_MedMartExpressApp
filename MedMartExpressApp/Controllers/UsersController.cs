using MedMartExpressApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System;

namespace MedMartExpressApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("registration")]
        public Response register(User user)
        {
            AppDbMangar _dbmang = new AppDbMangar();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("MedMartCS").ToString());
            return _dbmang.register(user, conn);
        }
        [HttpGet]
        [Route("login")]
        public Response login(User user)
        {
            AppDbMangar _dbmang = new AppDbMangar();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("MedMartCS").ToString());
            return _dbmang.Login(user, conn);
        }
        [HttpGet]
        [Route("viewProfile")]
        public Response viewProfile(User user)
        {
            AppDbMangar _dbmang = new AppDbMangar();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("MedMartCS").ToString());
            return _dbmang.viewProfile(user, conn);
        }

        [HttpPost]
        [Route("editProfile")]
        public Response editProfile(User user)
        {
            AppDbMangar _dbmang = new AppDbMangar();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("MedMartCS").ToString());
            return _dbmang.editProfile(user, conn);
        }
    }
}
