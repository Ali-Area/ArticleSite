using CMSApplication.Application.Dtos.Site.AddArticleDtos;
using CMSApplication.CommonTools.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Contracts.Site
{
    public interface IFrontArticleService
    {

        Task<ResultDto> AddArticle(AddArticleDto request);
        ResultDto EditArticle(EditArticleDto request);
        ResultDto DeleteArticle(string articleId);

    }
}
