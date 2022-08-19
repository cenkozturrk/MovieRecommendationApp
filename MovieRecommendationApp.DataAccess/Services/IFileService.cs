﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.DataAccess.Services
{
    public interface IFileService
    {
        Task UploadAsync(string patch, IFormFileCollection files);  
    }
}
