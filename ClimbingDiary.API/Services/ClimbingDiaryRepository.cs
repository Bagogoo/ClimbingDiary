using ClimbingDiary.API.DbContexts;
using ClimbingDiary.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingDiary.API.Services
{
    public class ClimbingDiaryRepository : IClimbingDiaryRepository, IDisposable
    {
        private readonly ClimbingDiaryContext _context;
        public ClimbingDiaryRepository(ClimbingDiaryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddRoute(Guid sectorId, Route route)
        {
            if (sectorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(sectorId));
            }
            if (route == null)
            {
                throw new ArgumentNullException(nameof(route));
            }
            route.SectorId = sectorId;
            _context.Routes.Add(route);
        }

        public void AddSector(Sector sector)
        {
            if (sector == null)
            {
                throw new ArgumentNullException(nameof(sector));
            }
            sector.Id = Guid.NewGuid();
            foreach (var route in sector.Routes)
            {
                route.Id = Guid.NewGuid();
            }
            _context.Sectors.Add(sector);
        }

        public void DeleteRoute(Route route)
        {
            _context.Routes.Remove(route);
        }

        public void DeleteSector(Sector sector)
        {
            if (sector == null)
            {
                throw new ArgumentNullException(nameof(sector));
            }
            _context.Sectors.Remove(sector);
        }


        public Route GetRoute(Guid sectorId, Guid routeId)
        {
            if (sectorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(sectorId));
            }
            if (routeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(routeId));
            }
            return _context.Routes
                .Where(c => c.SectorId == sectorId && c.Id == routeId).FirstOrDefault();
        }

        public IEnumerable<Route> GetRoutes(Guid sectorId)
        {
            if (sectorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(sectorId));
            }
            return _context.Routes
                .Where(c => c.SectorId == sectorId).OrderBy(c => c.Name).ToList();
        }

        public Sector GetSector(Guid sectorId)
        {
            if (sectorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(sectorId));
            }
            return _context.Sectors.FirstOrDefault(c => c.Id == sectorId);
        }

        public IEnumerable<Sector> GetSectors()
        {
            return _context.Sectors.ToList<Sector>();
        }

        public IEnumerable<Sector> GetSectors(IEnumerable<Guid> sectorIds)
        {
            if (sectorIds == null)
            {
                throw new ArgumentNullException(nameof(sectorIds));
            }
            return _context.Sectors
                .Where(c => sectorIds.Contains(c.Id)).OrderBy(c => c.Name).ToList();
        }
        public bool SectorExists(Guid sectorId)
        {
            if (sectorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(sectorId));
            }
            return _context.Sectors.Any(c => c.Id == sectorId);
        }

        public void UpdateRoute(Route route)
        {
            // no code in this implementation
        }

        public void UpdateSector(Sector sector)
        {
            // no code in this implementation
        }
        public void GetClimber(Guid climberId)
        {
            if (climberId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(climberId));
            }
            _context.Climbers.FirstOrDefault(c => c.Id == climberId);
        }

        public void AddClimber(Climber climber)
        {
            if (climber == null)
            {
                throw new ArgumentNullException(nameof(climber));
            }
            _context.Climbers.Add(climber);
        }

        public void UpdateClimber(Climber climber)
        {
            // no code in this implementation
        }

        public IEnumerable<Climber> GetClimbers()
        {
            return _context.Climbers.ToList<Climber>();
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //dispose resources when needed
            }
        }

       
    }
}
