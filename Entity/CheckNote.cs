using Entity.Interfaces;

namespace Entity;

public class CheckNote : BaseNote , INote
{
    public bool IsChecked { get; set; }
}