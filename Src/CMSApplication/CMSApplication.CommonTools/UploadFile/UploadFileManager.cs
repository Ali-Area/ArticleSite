using CMSApplication.CommonTools.Dtos;
using CMSApplication.CommonTools.UploadFile.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.CommonTools.UploadFile
{
    public static class UploadFileManager
    {


        public static async Task<ResultDto<UploadImageResultDto>> UploadImage(IFormFile image, IHostingEnvironment env, string branch)
        {
            string imagesFolder = @$"Images\{branch}\";
            var imageBasePath = Path.Combine(env.WebRootPath, imagesFolder);

            if(!Directory.Exists(imageBasePath))
            {
                Directory.CreateDirectory(imageBasePath);
            }

            if(image == null || image.Length == 0)
            {
                return Tools.ReturnResult(false, "There is Not image Selected.", new UploadImageResultDto()
                {
                    Url = ""
                });
            }

            var fileName = DateTime.Now.Ticks.ToString() + image.FileName;
            var finalImagePath = Path.Combine(imageBasePath, fileName);

            using (FileStream stream = new(finalImagePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return Tools.ReturnResult(true, "", new UploadImageResultDto()
            {
                Url = imagesFolder + fileName
            });

        }

    }
}
