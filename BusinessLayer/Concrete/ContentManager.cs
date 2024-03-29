﻿using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal=contentDal;
        }

        public void ContentAdd(Content content)
        {
           _contentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Content Getbyid(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetContents(string p)
        {
            return _contentDal.List(x=>x.ContentValue.Contains(p));
        }

    

        public List<Content> GetContentsByHeadingId(int id)
        {
            return _contentDal.List(x=>x.HeadingId == id);
        }

        public List<Content> GetContentsByWriter(int id)
        {
            return _contentDal.List(x => x.WriterId==id);
        }
    }
}
