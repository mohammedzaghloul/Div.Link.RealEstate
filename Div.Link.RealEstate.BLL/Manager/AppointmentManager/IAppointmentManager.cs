using Div.Link.RealEstate.BLL.DTO.AppointmentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.Manager.AppointmentManager
{
    public interface IAppointmentManager
    {
        public IEnumerable<AppointmentReadDto> Getall();
        public AppointmentReadDto GetById(int Id);
        public void Delete(int Id);
        public void Update(AppointmentUpdateDto entity);
        public void Add(AppointmentCreateDto entity);
    }
}
