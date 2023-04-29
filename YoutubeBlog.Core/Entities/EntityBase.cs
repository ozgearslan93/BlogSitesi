using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeBlog.Core.Entities
{
    public abstract class EntityBase :IEntityBase
    {


        public virtual Guid Id { get; set; } = Guid.NewGuid(); //int sectigimizde birer artıyor Guid olunca öyle bir durum olmuyor.ondan Guid.NewGuid();
        public virtual string CreatedBy { get; set; } = "UndeFined"; 
        public virtual string? ModifiedBy { get; set; }
        public virtual string? DeletedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual bool IsDeleted { get; set; } = false; 
        //entity olusturuldugunda create date now isdeleted de false yani silinmemiş olarak gelecek.
      
        //save delete işlemi yaparken isdeleted i true ya cekersek o sekilde anlayacagız silme işleminin yapıldıgını . kim tarafından ne zaman silindiginide görebilicez.
        //silinmiş makaleler içinde ayrı bir alan olusturucaz çöpkutusu adında onları burda tutacagız.



        //soru işareti koyarak nullable oldugunu belirtiyoruz . örn string bir deger string yerine null degeride alabilir mantıgı
    }
}
