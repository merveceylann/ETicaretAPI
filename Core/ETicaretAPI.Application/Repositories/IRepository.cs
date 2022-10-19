﻿using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity // class  //burada class yazmak yerine BaseEntity yazmak mantiklidir. cunku zaten BaseEntity bir classtir. bu duruma marker pattern denir.
    {
        DbSet<T> Table { get; }
    }
}
