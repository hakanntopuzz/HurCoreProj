using System;
using System.Collections.Generic;
using System.Text;
using HurCoreProj.Data.Models;
using HurCoreProj.Service.DTO;

namespace HurCoreProj.Service.Abstract
{
    public interface INewService
    {
        IEnumerable<NewContentDto> GetNewList();
        NewDetailDto GetNewById(int id, bool useAmp = false);
    }
}
