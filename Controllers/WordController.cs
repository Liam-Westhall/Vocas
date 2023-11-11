using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Vocas.Data;
using Vocas.Models;

namespace Vocas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly VocasContext _context;

        public WordController(VocasContext context)
        {
            _context = context;
        }

        public WordController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                               select WordId, Term, Def from 
                               dbo.Words
                                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("VocabAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon=new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand=new SqlCommand(query,myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WordId,Text,Meaning,Example")] Word word)
        {
            if (ModelState.IsValid)
            {
                _context.Add(word);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(word);
        }



    }
}
