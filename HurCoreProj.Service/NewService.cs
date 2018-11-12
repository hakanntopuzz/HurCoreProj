using System.Collections.Generic;
using System.Linq;
using Html2Amp;
using HurCoreProj.Core;
using HurCoreProj.Data.Models;
using HurCoreProj.Service.Abstract;
using HurCoreProj.Service.DTO;

namespace HurCoreProj.Service
{
    public class NewService: INewService
    {
        private readonly string _jsonString;

        public NewService(string contentRootPath)
        {
            _jsonString = System.IO.File.ReadAllText(contentRootPath + "/Json/news.json");
        }

        public IEnumerable<NewContentDto> GetNewList()
        {
            var data= JsonSerializer.ActiveInstance.DeserializeObject<IEnumerable<New>>(_jsonString);

            return data.Select(s => new NewContentDto
            {
                Id = s.Id,
                Baslik = s.Title
            }).AsEnumerable();
        }

        public NewDetailDto GetNewById(int id, bool useAmp = false)
        {
            var ampConverter = new HtmlToAmpConverter();
            var data = JsonSerializer.ActiveInstance.DeserializeObject<IEnumerable<New>>(_jsonString);

            return data.Where(q => q.Id == id).Select(s => new NewDetailDto
            {
                Id = s.Id,
                Baslik = s.Title,
                Tarih = s.StartDate,
                Icerik = useAmp ? ampConverter.ConvertFromHtml(s.Text).AmpHtml : s.Text
            }).FirstOrDefault();
        }
    }
}
