using Microsoft.EntityFrameworkCore;
using Project.Domain.Doctors;
using Project.Shared.Doctors;
using Project.Persistence.Data;

namespace Project.Services.Doctors

{
    public class DoctorService : IDoctorService
    {
        private readonly OogArtsDbContext _context;
        private readonly DbSet<Doctor> _doctors;

        public DoctorService(OogArtsDbContext dataContext)
        {
            _context = dataContext;
            _doctors = dataContext.Doctors;
        }

        private IQueryable<Doctor> GetDoctorById(int id)
        {
            return _doctors.AsNoTracking().Where(c => c.Id == id);
        }

        public async Task<DoctorResponse.Create> CreateAsync(DoctorRequest.Create request)
        {
            DoctorResponse.Create response = new();
            var doctor = _doctors.Add(
                new Doctor(
                    request.Doctor.FirstName,
                    request.Doctor.LastName,
                    request.Doctor.Specialization,
                    request.Doctor.Image));

            await _context.SaveChangesAsync();
            response.DoctorId = doctor.Entity.Id;
            return response;
        }

        public Task DeleteAsync(DoctorRequest.Delete request)
        {
            var doctor = _doctors.First(p => p.Id == request.DoctorId);
            _context.Remove(doctor);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<DoctorResponse.Edit> EditAsync(DoctorRequest.Edit request)
        {
            DoctorResponse.Edit response = new();
            var doctor = await GetDoctorById(request.DoctorId).SingleOrDefaultAsync();
            if (doctor is not null)
            {
                var model = request.Doctor;
                doctor.FirstName = model.FirstName ?? doctor.FirstName;
                doctor.LastName = model.LastName ?? doctor.LastName;
                doctor.Specialization = model.Specialization ?? doctor.Specialization;
                doctor.Image = model.Image ?? doctor.Image;

                _context.Entry(doctor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                response.DoctorId = doctor.Id;
            }
            return response;
        }

        public async Task<DoctorResponse.GetDetail> GetDetailAsync(DoctorRequest.GetDetail request)
        {
            DoctorResponse.GetDetail response = new();
            response.Doctor = await GetDoctorById(request.DoctorId).Select(x => new DoctorDTO.Detail
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Specialization = x.Specialization,
                Image = x.Image
            }).SingleOrDefaultAsync();
            return response;
        }

        public async Task<DoctorResponse.GetIndex> GetIndexAsync(DoctorRequest.GetIndex request)
        {
            DoctorResponse.GetIndex response = new();
            var query = _doctors.AsQueryable().AsNoTracking();
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(x => x.FirstName.Contains(request.SearchTerm) || x.LastName.Contains(request.SearchTerm));
            }
            query = query.Take(request.Amount);
            query = query.Skip(request.Amount * request.Page);
            query = query.OrderBy(x => x.FirstName);

            response.Doctors = await query.Select(x => new DoctorDTO.Index
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Image = x.Image,
                Specialization = x.Specialization,
            }).ToListAsync();
            return response;
        }
    }
}
