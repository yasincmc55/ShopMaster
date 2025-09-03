using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaster.DataAccess.Repository.IRepository
{
    //generic arayüzü sadeve class tipinde olanlara implemente edeceğiz 
    //burada şunu yapıyoruz herhangi bir tablo yani entity için ortak bir CRUD arayüzü oluşturuyoruz
    //bu şekilde T yerine Catagory de gelebelir Product da gelebilir tek bir arayüz üzerinden hepsi için ortak
    //bir çatı oluşturuyoruz
    internal interface IRepository<T> where T : class
    {
        //T-Category
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        //void Update(T entity); updata mantığı entityler arasında değiştiği için bunu arayüze eklemeyelim
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}

/*
 *  Burada:

    T → Category

    entity → cat (yani new Category() { Id=1, Name="Elektronik" })

    Yani entity parametresine eklemek istediğin nesneyi gönderiyorsun.
 */
