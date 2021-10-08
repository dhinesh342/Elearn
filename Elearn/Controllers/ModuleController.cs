﻿using Elearn.KaniniModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        public elearnContext db = new elearnContext();

        [HttpGet]
        public async Task<IActionResult> GetAllModules()
        {
            return Ok(await db.Modules.ToListAsync());
        }
        [HttpGet]
        [Route("GetModuleByID")]
        public async Task<ActionResult<staff>> GetModuleById(int Id)
        {
            Module m = await db.Modules.FindAsync(Id);
            if (m == null)
            {
                return NotFound();
            }
            return Ok(m);
        }

        [HttpPost]
        public async Task<IActionResult> AddModule(Module m)
        {
            db.Modules.Add(m);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateModule(int Id, Module m)
        {
            using (var db = new elearnContext())
            {

                if (Id != m.Moduleid)
                {
                    return BadRequest();
                }

                db.Entry(m).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleExists(Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            Module m = db.Modules.Find(id);
            db.Modules.Remove(m);
            await db.SaveChangesAsync();
            return Ok();
        }

        private bool ModuleExists(int Id)
        {
            return db.Modules.Any(m => m.Moduleid == Id);
        }
    }
}
