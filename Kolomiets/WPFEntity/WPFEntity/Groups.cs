//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Groups
    {
        public Groups()
        {
            this.Students = new HashSet<Students>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Id_Faculty { get; set; }
    
        public virtual Faculties Faculties { get; set; }
        public virtual ICollection<Students> Students { get; set; }
    }
}
