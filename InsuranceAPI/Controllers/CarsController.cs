using InsuranceAPI.Data;
using InsuranceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InsuranceAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : Controller
    {

        private readonly CustomerDbContext carDbContext;
        public CarsController(CustomerDbContext carDbContext)
        {
            this.carDbContext = carDbContext;
        }



        //get all cars
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await carDbContext.Cars.ToListAsync();
            return Ok(cars);
        }

        //get a single car
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCars")]
        public async Task<IActionResult> GetCars([FromRoute] Guid id)
        {
            var cars = await carDbContext.Cars.FirstOrDefaultAsync(x => x.policy_id == id);
            if (cars != null)
            {
                return Ok(cars);
            }
            return NotFound("Car Policy not found");
        }


        //get a single car
        [HttpPost]

        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            car.policy_id = Guid.NewGuid();
            await carDbContext.Cars.AddAsync(car);
            await carDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCars), new { id = car.policy_id }, car);
        }


        //Updating a car

        [HttpPut]
        [Route("{id:guid}")]
       
        public async Task<IActionResult> UpdateCar([FromRoute] Guid id,[FromBody] Car car)
        {
            var existingCar = await carDbContext.Cars.FirstOrDefaultAsync(x => x.policy_id == id);
            if (existingCar != null)
            {
                existingCar.policy_type = car.policy_type;
                existingCar.end_date = car.end_date;
                existingCar.start_date= car.start_date;
                existingCar.model_no = car.model_no;
                await carDbContext.SaveChangesAsync();
                return Ok(existingCar);
            }
           return NotFound("CarPolicy not found");
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteCar([FromRoute] Guid id)
        {
            var existingCar = await carDbContext.Cars.FirstOrDefaultAsync(x => x.policy_id == id);
            if (existingCar != null)
            {
               carDbContext.Remove(existingCar);
                await carDbContext.SaveChangesAsync();
                return Ok(existingCar);
            }
            return NotFound("CarPolicy not found");
        }


    }
}
