﻿using App.Core.DataAccess;
using App.Core.Entities;
using App.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Abstract
{
    public interface IFollowerDal : IEntityRepository<Follower>
    {
    }
}
