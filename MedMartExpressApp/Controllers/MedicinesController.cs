using MedMartExpressApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace MedMartExpressApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MedicinesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("addToCart")]
        public Response addToCart(Cart cart)
        {
            AppDbMangar _dbmang = new AppDbMangar();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("MedMartCS").ToString());
            return _dbmang.addToCart(cart, conn);
        }
        [HttpPost]
        [Route("addToCart")]
        public Response placeOrder(User usr)
        {
            AppDbMangar _dbmang = new AppDbMangar();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("MedMartCS").ToString());
            return _dbmang.placeOrder(usr, conn);
        }
        [HttpGet]
        [Route("viewOrders")]
        public Response viewOrders(User usr)
        {
            AppDbMangar _dbmang = new AppDbMangar();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("MedMartCS").ToString());
            return _dbmang.viewOrders(usr, conn);
        }
    }
}
