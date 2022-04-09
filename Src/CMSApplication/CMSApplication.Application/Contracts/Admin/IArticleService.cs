using CMSApplication.Application.Dtos.Admin.ArticleServiceDtos;
using CMSApplication.CommonTools.Dtos;
using CMSApplication.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Application.Contracts.Admin
{
    public interface IArticleService
    {
        GetArticleListResultDto GetArticleList(GetArticleListRequestDto request);
        ResultDto DeleteArticle(string articleId);
        ResultDto ChangeBeingSpecial(string articleId);
    }
}
