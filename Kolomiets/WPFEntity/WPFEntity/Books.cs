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
    
    public partial class Books
    {
        public Books()
        {
            this.S_Cards = new HashSet<S_Cards>();
            this.T_Cards = new HashSet<T_Cards>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public int YearPress { get; set; }
        public int Id_Themes { get; set; }
        public int Id_Category { get; set; }
        public int Id_Author { get; set; }
        public int Id_Press { get; set; }
        public string Comment { get; set; }
        public int Quantity { get; set; }
    
        public virtual Authors Authors { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual Press Press { get; set; }
        public virtual Themes Themes { get; set; }
        public virtual ICollection<S_Cards> S_Cards { get; set; }
        public virtual ICollection<T_Cards> T_Cards { get; set; }
    }
}
