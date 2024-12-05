using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplication3_coffees.Models; //so that red squiguy lines go away at List<Coffee>
//need to say using APP NAME OF PROJECT


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3_coffees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeInfoController : ControllerBase
    {
        //need global variable
        List<Coffee> coffees = new List<Coffee>();

        public CoffeeInfoController()
        {
            coffees.Add(new Coffee
            {
                Id = 101,
                Flavorname = "White Chocolate Mocha",
                Sizeinoz = 12,
                Price = 3.50,
                Season = "ALL"
            });

            coffees.Add(new Coffee
            {
                Id = 105,
                Flavorname = "White Chocolate Mocha",
                Sizeinoz = 16,
                Price = 4.95,
                Season = "ALL"
            });

            coffees.Add(new Coffee
            {
                Id = 110,
                Flavorname = "Peppermint Mocha",
                Sizeinoz = 12,
                Price = 3.95,
                Season = "Holiday"
            });

            coffees.Add(new Coffee
            {
                Id = 112,
                Flavorname = "Peppermint Mocha",
                Sizeinoz = 16,
                Price = 4.95,
                Season = "Holiday"
            });

            coffees.Add(new Coffee
            {
                Id = 118,
                Flavorname = "Caramel Latte",
                Sizeinoz = 12,
                Price = 3.95,
                Season = "ALL"
            });

            coffees.Add(new Coffee
            {
                Id = 120,
                Flavorname = "Caramel Latte",
                Sizeinoz = 16,
                Price = 4.95,
                Season = "ALL"
            });

            coffees.Add(new Coffee
            {
                Id = 122,
                Flavorname = "Medium Roast",
                Sizeinoz = 12,
                Price = 3.25,
                Season = "ALL"
            });

            coffees.Add(new Coffee
            {
                Id = 128,
                Flavorname = "Medium Roast",
                Sizeinoz = 16,
                Price = 4.25,
                Season = "ALL"
            });

            coffees.Add(new Coffee
            {
                Id = 130,
                Flavorname = "Caramel Brulee",
                Sizeinoz = 12,
                Price = 3.95,
                Season = "Holiday"
            });

            coffees.Add(new Coffee
            {
                Id = 132,
                Flavorname = "Caramel Brulee",
                Sizeinoz = 16,
                Price = 4.95,
                Season = "Holiday"
            });

            coffees.Add(new Coffee
            {
                Id = 135,
                Flavorname = "Holiday Blend",
                Sizeinoz = 12,
                Price = 3.55,
                Season = "Holiday"
            });

            coffees.Add(new Coffee
            {
                Id = 138,
                Flavorname = "Gingerbread Latte",
                Sizeinoz = 12,
                Price = 3.75,
                Season = "Holiday"
            });

            coffees.Add(new Coffee
            {
                Id = 140,
                Flavorname = "Gingerbread Latte",
                Sizeinoz = 16,
                Price = 4.75,
                Season = "Holiday"
            });

            coffees.Add(new Coffee
            {
                Id = 142,
                Flavorname = "Lemon Bar Creme",
                Sizeinoz = 12,
                Price = 3.25,
                Season = "ALL"
            });

            coffees.Add(new Coffee
            {
                Id = 145,
                Flavorname = "Lemon Bar Creme",
                Sizeinoz = 16,
                Price = 3.95,
                Season = "ALL"
            });
        }


        // GET: api/<CoffeeInfoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CoffeeInfoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CoffeeInfoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CoffeeInfoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CoffeeInfoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //GET api/CoffeeInfo/GetSpecial/id
        //this is how i want JS or anyone using it to use it 
        [HttpGet, Route("GetSpecial/{id}")]

        public String GetSpecial(int id)
        {
            // id comes from async function from the html
            if(id < coffees.Count && id > 0)
            {
                return JsonSerializer.Serialize(coffees[id - 1]);
            }
            else
            {
                return JsonSerializer.Serialize(coffees[0]);
            }
           
        }

        // Get number of coffees
        [HttpGet, Route("GetNum")]

        public int GetNum()
        {

        return coffees.Count; 
        }

        [HttpGet, Route("GetAllFlavors")]

        public IEnumerable<Coffee> GetAllFlavors()
        {

        return coffees; 
        }
        [HttpGet, Route("GetHolidayFlavors")]
        public IEnumerable<Coffee> GetHolidayFlavors()
        {
            List<Coffee> returnCoffees = new List<Coffee>();

            // Walk through the coffees list and pick out the Holiday items
            foreach(Coffee coffee in coffees)
            {
                if (coffee.Season.Equals("Holiday"))
                {
                    returnCoffees.Add(coffee);
                }
            }

            return returnCoffees;
        }

    }
}
