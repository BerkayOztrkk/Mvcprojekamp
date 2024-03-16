using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageManager : IImageService
    {
        IImagesDal _ımagesDal;

        public ImageManager(IImagesDal ımagesDal)
        {
            _ımagesDal=ımagesDal;
        }

        public List<ImageFile> GetImageFiles()
        {
           return _ımagesDal.List();
        }
    }
}
