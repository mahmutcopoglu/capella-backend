using Application.Repositories;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Persistence.Services
{

    public class MediaService : IMediaService
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private readonly IConfiguration _config;
        private readonly IMediaWriteRepository _mediaWriteRepository;
        public MediaService(IConfiguration config, IMediaWriteRepository mediaWriteRepository)
        {
            _config = config;
            _mediaWriteRepository = mediaWriteRepository;
        }
        public async Task<Media> storage(IFormFile formFile, bool secure)
        { 
            
            try
            {
                var todayDate = DateTime.Now.ToString("yyyyMMdd");
                var todayTime = DateTime.Now.ToString("HHmmss");
                var rootPath = _config["MediaStorage:FileRootPath"];
                var isSecure = secure ? _config["MediaStorage:SecurePath"] : _config["MediaStorage:PublicPath"];
                var filePath = $"{isSecure}capella/{todayDate}/{todayTime}";
                var fullPath = $"{rootPath}/{filePath}";        
                var filenamehash =  new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());

                Directory.CreateDirectory(fullPath);
                using (var stream = new FileStream(Path.Combine(fullPath, formFile.FileName), FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

                Media media = new();
                media.RealFilename = formFile.FileName;
                media.EncodedFilename = filenamehash;
                media.Extension = Path.GetExtension(formFile.FileName);
                media.FilePath = filePath;
                media.RootPath = rootPath;
                media.Size = formFile.Length;
                media.Mime = formFile.ContentType;
                media.Secure = secure;
                var absolutePath = $"{filePath}/{filenamehash}{Path.GetExtension(formFile.FileName)}";
                media.AbsolutePath = absolutePath;
                media.ServePath = absolutePath;
                media.Code = Guid.NewGuid().ToString();
                await _mediaWriteRepository.AddAsync(media);
                return media;
                
            }
            catch (IOException exception)
            {

                throw exception;
            }
        }
    }
}
