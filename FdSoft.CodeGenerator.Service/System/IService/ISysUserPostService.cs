﻿using System.Collections.Generic;
using FdSoft.CodeGenerator.Model.System;

namespace FdSoft.CodeGenerator.Service.System.IService
{
    public interface ISysUserPostService
    {
        public void InsertUserPost(SysUser user);

        public List<long> GetUserPostsByUserId(long userId);

        public string GetPostsStrByUserId(long userId);
        bool Delete(long userId);
    }
}
