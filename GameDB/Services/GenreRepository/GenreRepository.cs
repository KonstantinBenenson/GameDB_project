using AutoMapper;
using GameDB.Data;
using GameDB.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameDB.Services
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(GameDbContext context) : base(context)
        {
        }
    }       
}
