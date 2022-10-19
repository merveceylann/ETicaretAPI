using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions
{
    public interface IProductService
    {
        //yapilan islem vt islemi ise bu interfacein somutu persistanceta olusturmali, dis serviceler ile alakali ise (vt ile ilgili olmayan) onu da infrastructure
        List<Product> GetProducts();
    }
}
