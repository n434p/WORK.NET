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
    
    public partial class Libs
    {
        public Libs()
        {
            this.S_Cards = new HashSet<S_Cards>();
            this.T_Cards = new HashSet<T_Cards>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public virtual ICollection<S_Cards> S_Cards { get; set; }
        public virtual ICollection<T_Cards> T_Cards { get; set; }
    }
}