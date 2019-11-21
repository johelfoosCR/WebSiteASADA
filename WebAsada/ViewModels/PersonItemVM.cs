namespace WebAsada.ViewModels
{
    public class PersonItemVM
    {
        public PersonItemVM()
        {
        }

        public int Id { get; set; }
        public string DisplayValue { get; set; }
    }


    public class SelectItemDefaultVM: SelectItemVM<int>
    { 
        public new static SelectItemVM<int> Create(int value, string text)
        {
            return SelectItemVM<int>.Create(value,text); 
        }
         
    }

    public class SelectItemVM<T>
    {
        public static SelectItemVM<T> Create(T value, string text)
        {
            return new SelectItemVM<T>()
            {
                Value = value,
                Text = text
            };

        } 
        
        public T Value { get; set; }
        public string Text { get; set; }
    }

}
