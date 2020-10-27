using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShapeUpp.Api.Models;
using ShapeUpp.Domain.Models;
using ShapeUpp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShapeUpp.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly ActivityContext _activityContext;
        private readonly IMapper _mapper;

        public ExerciseController(ActivityContext activityContext, IMapper mapper)
        {
            _activityContext = activityContext;
            _mapper = mapper;
        }

        [HttpGet("Categories")]
        [ResponseCache(Duration = 60)]
        public async Task<IEnumerable<ActivityType>> GetCategories()
        {
            return await _activityContext.Set<ActivityType>().ToListAsync();
        }

        [HttpGet("Muscles")]
        [ResponseCache(Duration = 60)]
        public async Task<IDictionary<string, List<MuscleGroup>>> GetMusclesPerBodyPart()
        {
            var muscles = await _activityContext.Set<MuscleGroup>()
                .OrderBy(x => x.IsSecondary)
                .ToListAsync();

            return muscles
                .GroupBy(x => x.BodyPart)
                .ToDictionary(
                    x => x.Key.ToString(),
                    x => x.ToList());
        }


        [HttpGet("Equipment")]
        [ResponseCache(Duration = 60)]
        public async Task<IDictionary<string, List<Equipment>>> GetEquipmentPerCategory()
        {
            var equipment = await _activityContext.Set<Equipment>()
                .ToListAsync();

            return equipment
                .GroupBy(x => x.Category)
                .ToDictionary(
                    x => x.Key,
                    x => x.ToList());
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public async Task<IEnumerable<Exercise>> Get()
        {
            return await _activityContext.Set<Exercise>().ToListAsync();
        }


        [HttpGet("{id}")]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<Exercise>> Get(int id)
        {
            var exercise = await _activityContext.Set<Exercise>().FindAsync(id);

            if (exercise == null)
            {
                return NotFound(id);
            }

            await _activityContext.Set<ActivityType>().LoadAsync();
            await _activityContext.Set<MuscleGroup>().LoadAsync();
            await _activityContext.Set<Equipment>().LoadAsync();

            return Ok(exercise);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExerciseDto exercise)
        {
            var exerciseEntity = _mapper.Map<Exercise>(exercise);

            var category = await _activityContext.Set<ActivityType>()
                .FindAsync(exercise.Activity);

            var muscles = await _activityContext.Set<MuscleGroup>()
                .Where(x => exercise.Muscles.Contains(x.Id))
                .ToListAsync();

            var equipment = await _activityContext.Set<Equipment>()
                .Where(x => exercise.Equipment.Contains(x.Id))
                .ToListAsync();

            // TODO: validate if not null
            exerciseEntity.Category = category;
            exerciseEntity.MuscleGroups = muscles;
            exerciseEntity.Equipment = equipment;

            _activityContext.Set<Exercise>().Add(exerciseEntity);
            await _activityContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = exerciseEntity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ExerciseDto exercise)
        {
            if (exercise == null || exercise.Id == default)
            {
                return BadRequest();
            }

            var exerciseEntity = await _activityContext.Set<Exercise>().FindAsync(exercise.Id);

            if (exerciseEntity == null)
            {
                return NotFound(new { id = exercise.Id });
            }

            exerciseEntity.Name = exercise.Name;
            exerciseEntity.Description = exercise.Description;

            await _activityContext.Set<ActivityType>().LoadAsync();
            if (exercise.Activity != exerciseEntity.Category.Id)
            {
                var category = await _activityContext.Set<ActivityType>().FindAsync(exercise.Activity);
                exerciseEntity.Category = category;
            }

            var muscles = await _activityContext.Set<MuscleGroup>()
                .Where(x => exercise.Muscles.Contains(x.Id))
                .ToListAsync();
            exerciseEntity.MuscleGroups = muscles;

            var equipment = await _activityContext.Set<Equipment>()
                .Where(x => exercise.Equipment.Contains(x.Id))
                .ToListAsync();
            exerciseEntity.Equipment = equipment;

            await _activityContext.SaveChangesAsync();

            return Ok(new { id = exerciseEntity.Id });
        }
    }
}
