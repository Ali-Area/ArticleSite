using CMSApplication.Application.Dtos.Site.ArticleDtos;
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

        ResultDto AddArticle(AddArticleDto request);
        ResultDto EditArticle(EditArticleDto request);
        ResultDto DeleteArticle(string articleId);
        ResultDto<ShowArticleDetailsDto> ShowArticleDetails(string articleId);

    }
}
