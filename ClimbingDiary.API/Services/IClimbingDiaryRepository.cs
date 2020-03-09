using ClimbingDiary.API.Entities;
using ClimbingDiary.API.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingDiary.API.Services
{
    public interface IClimbingDiaryRepository
    {
        IEnumerable<Route> GetRoutes(Guid sectorId);
        Route GetRoute(Guid sectorId, Guid routeId);
        void AddRoute(Guid sectorId, Route route);
        void UpdateRoute(Route route);
        void DeleteRoute(Route route);
        IEnumerable<Sector> GetSectors();
        Sector GetSector(Guid sectorId);
        IEnumerable<Sector> GetSectors(IEnumerable<Guid> sectorIds);
        IEnumerable<Sector> GetSectors(SectorsResourceParameters sectorResourceParameters);
        Climber GetClimber(Guid climberId);
        void AddSector(Sector sector);
        void DeleteSector(Sector sector);
        void UpdateSector(Sector sector);
        
        void AddClimber(Climber climber);
        void UpdateClimber(Climber climber);
        IEnumerable<Climber> GetClimbers();
        bool SectorExists(Guid sectorId);
        bool Save();

    }
}
