using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {

        List<Content> GetContents(string p);
        List<Content> GetContentsByWriter(int id);
        List<Content> GetContentsByHeadingId(int id);
        void ContentAdd(Content content);
        Content Getbyid(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
    }
}
